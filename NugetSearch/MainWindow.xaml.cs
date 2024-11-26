using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Accessibility;
using RestSharp;
using WpfApp1.Annotations;

namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new ViewModel();
        

        var konami = this
            .WhenKeyUp()
            .Konami()
            .SelectMany(Observable
                .Timer(TimeSpan.FromMilliseconds(1000))
                .Select(_ => false)
                .StartWith(true));

        konami
            .Select(x => x ? "Snydekode aktiveret" : "")
            .ObserveOn(SynchronizationContext.Current!)
            .Subscribe(x => CallingOrTypingText.Content = x);

        konami
            .Select(x => x ? Visibility.Visible : Visibility.Hidden)
            .ObserveOn(SynchronizationContext.Current!)
            .Subscribe(x => CallingOrTypingText.Visibility = x);
    }
}

public class ViewModel : INotifyPropertyChanged
{
    RestClient _client = new("https://api-v2v3search-0.nuget.org");

    public ViewModel()
    {
        // User types en search field
        var whenTyping = WhenTyping();

        // Wait for user to stop typing
        var input = whenTyping
            .Throttle(TimeSpan.FromMilliseconds(500))
            .Select(x => (term: x, longEnough: x.Length >= 3));

        var validInput = input
            .Where(s => s.longEnough)
            .DistinctUntilChanged();

        // use search term to get autocomplete
        var results = validInput
            .Select(s => GetAutocomplete(s.term))
            .Switch() // cancel search if user starts typing again
            .Publish().RefCount(); // share results observable. If we don't do we would do the web request once for each subscriber

        results
            .Subscribe(r => SearchResult = r);

        // Clear results if next search term to short
        input
            .Where(s => !s.longEnough)
            .Subscribe(_ => SearchResult = Array.Empty<string>());

        // Overlay text
        Observable
            .Merge(
                whenTyping.Select(_ => "Typing..."),
                validInput.Select(_ => "Calling..."),
                input.Where(s => !s.longEnough).Select(_ => "Type at least 3 letters"))
            .DistinctUntilChanged()
            .Subscribe(t => CallingOrTypingText = t);

        // Overlay visibility
        Observable
            .Merge(
                whenTyping.Select(_ => Visibility.Visible),
                input.Select(_ => Visibility.Hidden),
                validInput.Select(_ => Visibility.Visible),
                results.Select(_ => Visibility.Hidden))
            .Throttle(TimeSpan.FromMilliseconds(10))
            .DistinctUntilChanged()
            .Subscribe(v => IsCalling = v);
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

    private IObservable<string[]> GetAutocomplete(string searchTerm)
    {
        return Observable.FromAsync(async ct =>
        {
            Debug.WriteLine(searchTerm);
            var req =
                new RestRequest("autocomplete")
                    .AddQueryParameter("q", SearchTerm);
            try
            {
                var result = await _client.GetAsync<AutoComplete>(req, ct);
                var resultData = result?.Data ?? Array.Empty<string>();
                Debug.WriteLine($"received {resultData.Length} autocomplete suggestions");
                return resultData;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Autocomplete exception {e.Message}");
                return Array.Empty<string>();
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

    private string[] _searchResult = Array.Empty<string>();

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
            .Window(10,1)
            .Do(async x =>
            {
                var y = await x.FirstAsync();
                var l = $"{y}";
            })
            .SelectMany(x => x.SequenceEqual(konamiCode))
            .Where(isKonami => isKonami)
            .Select(_ => Unit.Default);
    }
}