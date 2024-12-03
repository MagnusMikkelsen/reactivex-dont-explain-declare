using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Annotations;

namespace NugetSearch;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        DataContext = new ViewModel(this.WhenKeyUp());
    }
}

public class ViewModel : INotifyPropertyChanged
{
    private enum State
    {
        Idle,
        Typing,
        ToShort,
        Calling,
        NoResults,
        Konami
    }


    public ViewModel(IObservable<KeyEventArgs> whenKeyUp)
    {
        #region Konami

        var konami = whenKeyUp
            .Konami()
            .SelectMany(Observable
                .Timer(TimeSpan.FromMilliseconds(2500))
                .Select(_ => false)
                .StartWith(true))
            .StartWith(false);

        #endregion


        #region user input
        // User types en search field
        var whenTyping = WhenTyping();

        // Wait for user to stop typing
        var input = whenTyping
            .Throttle(TimeSpan.FromMilliseconds(500));

        var longEnough = input
            .Where(x => x.Length >= 3);

        var validInput = longEnough
            .DistinctUntilChanged();
        #endregion

        #region call api
        // use search term to get autocomplete
        var results = validInput
            .Select(GetAutocomplete)
            .Switch() // cancel search if user starts typing again
            .Publish().RefCount(); // share results observable. If we don't do we would do the web request once for each subscriber
        #endregion

        #region state
        var toShort = input
            .Where(x => x.Length < 3);

        var notChanged = longEnough
            .Buffer(2, 1)
            .Where(b => b.Distinct().Count() == 1);

        var emptyResult = results
            .Where(r => r.Length == 0);

        var gotResults = results
            .Where(r => r.Length > 0);

        var state = Observable.Merge(
            whenTyping.Select(_ => State.Typing),
            toShort.Select(_ => State.ToShort),
            notChanged.Select(_ => State.Idle),
            validInput.Select(_ => State.Calling),
            emptyResult.Select(_ => State.NoResults),
            gotResults.Select(_ => State.Idle))
            .DistinctUntilChanged()
            .CombineLatest(konami)
            .Select(x => x.Second ? State.Konami : x.First);
        #endregion

        #region update gui
        // results
        results
            // clear results when input to short
            .Merge(toShort
                .Select(_ => Array.Empty<string>()))
            .Subscribe(r => SearchResult = r);

        // Overlay text
        state
            .CombineLatest(validInput.StartWith(""))
            .Select(s => s.First switch
            {
                State.Typing => "Typing...",
                State.ToShort => "Type at least 3 letters",
                State.Calling => "Calling...",
                State.NoResults => $"No match for {s.Second}",
                State.Konami => "Snydekoder aktiveret",
                State.Idle => "",
                _ => ""
            })
            .Subscribe(t => CallingOrTypingText = t);

        state.Select(x => x switch
        {
            State.Idle => Visibility.Hidden,
            State.Typing => Visibility.Visible,
            State.ToShort => Visibility.Visible,
            State.Calling => Visibility.Visible,
            State.NoResults => Visibility.Visible,
            State.Konami => Visibility.Visible,
            _ => Visibility.Hidden
        })
        //.Throttle(TimeSpan.FromMilliseconds(10))
        .DistinctUntilChanged()
        .Subscribe(v => IsCalling = v);
        #endregion
    }

    private IObservable<string> WhenTyping()
    {
        return Observable
            .FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                h => PropertyChanged += h,
                h => PropertyChanged -= h)
            .Where(x => x.EventArgs.PropertyName == nameof(SearchTerm))
            .Select(_ => SearchTerm);
    }

    private readonly HttpClient _client = new()
    {
        BaseAddress = new("https://api-v2v3search-0.nuget.org")
    };

    private IObservable<string[]> GetAutocomplete(string searchTerm)
    {
        return Observable.FromAsync(async ct =>
        {
            Debug.WriteLine(searchTerm);

            try
            {
                var result = await _client.GetFromJsonAsync<AutoComplete>($"autocomplete?q={searchTerm}", ct);
                var resultData = result?.Data ?? [];
                Debug.WriteLine($"received {resultData.Length} autocomplete suggestions");
                return resultData;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Autocomplete exception {e.Message}");
                return [];
            }
        });
    }


    #region properties and notifychanged

    private Visibility _isCalling = Visibility.Hidden;

    private string _callingOrTypingText = "";

    public string CallingOrTypingText
    {
        get => _callingOrTypingText;
        set
        {
            if (value == _callingOrTypingText) return;
            _callingOrTypingText = value;
            OnPropertyChanged();
        }
    }

    public Visibility IsCalling
    {
        get => _isCalling;
        set
        {
            _isCalling = value;
            OnPropertyChanged();
        }
    }

    private string _searchTerm;

    public string SearchTerm
    {
        get => _searchTerm;
        set
        {
            _searchTerm = value;
            OnPropertyChanged();
        }
    }

    private string[] _searchResult = [];

    public string[] SearchResult
    {
        get => _searchResult;
        set
        {
            _searchResult = value;
            OnPropertyChanged();
        }
    }


    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}

public record AutoComplete(string[] Data);

public static class Exensions
{
    public static IObservable<KeyEventArgs> WhenKeyUp(this UIElement element)
    {
        return Observable
            .FromEventPattern<KeyEventHandler, KeyEventArgs>(
                h => element.KeyUp += h,
                h => element.KeyUp -= h)
            .Select(k => k.EventArgs);
    }

    public static IObservable<Unit> Konami(this IObservable<KeyEventArgs> source)
    {
        var konamiCode = new[] { Key.Up, Key.Up, Key.Down, Key.Down, Key.Left, Key.Right, Key.Left, Key.Right, Key.B, Key.A };

        return source
            .Select(x => x.Key)
            .Window(10, 1)
            .SelectMany(x => x.SequenceEqual(konamiCode))
            .Where(isKonami => isKonami)
            .Select(_ => Unit.Default);
    }
}