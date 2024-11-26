using System.Reactive;
using System.Reactive.Linq;

namespace _2._Declarative;

public partial class Form1 : Form
{
    enum State
    {
        Ready,
        Testing,
        TestDone,
        Controlling,
        ControlDone
    }

    public Form1()
    {
        InitializeComponent();
        var initialState = Observable.Return(State.Ready);

        var testClicks = GetClicks(buttonTest)
            .Select(_ => State.Testing);

        var controlClicks = GetClicks(buttonControl)
            .Select(_ => State.Controlling);

        // Run test on test button click
        var test = testClicks
            .SelectMany(_ => Observable.FromAsync(Test))
            .Select(_ => State.TestDone)
            .Publish().RefCount(); // Makes sure test only runs once by sharing the subscription

        // Run control on control button click
        var control = controlClicks
            .SelectMany(_ => Observable.FromAsync(Control))
            .Select(_ => State.ControlDone)
            .Publish().RefCount();

        // Small delay before resetting state
        var delay = control
            .Delay(TimeSpan.FromSeconds(1))
            .Select(_ => State.Ready);

        // Create one observable all above
        var state = Observable
            .Merge(
                initialState,
                testClicks,
                controlClicks,
                test,
                control,
                delay)
            .ObserveOn(SynchronizationContext.Current!); // Ensure we can update GUI

        // first subscription to the state observable starts the 'pipeline'
        // update status
        state.Select(s => s switch
            {
                State.Ready => "Ready",
                State.Testing => "Testing...",
                State.TestDone => "Ready for control",
                State.Controlling => "Controlling...",
                State.ControlDone => "OK",
                _ => "???"
            })
            .Subscribe(t => labelStatus.Text = t);

        // update status color
        state.Select(s => s switch
        {
            State.Ready => DefaultBackColor,
            State.ControlDone => Color.GreenYellow,
            _ => Color.Yellow
        })
        .Subscribe(c => labelStatus.BackColor = c);

        // update Test Button Enabled
        state.Select(s => s switch
        {
            State.Ready => true,
            _ => false
        })
        .Subscribe(e => buttonTest.Enabled = e);

        // update Control Button Enabled
        state.Select(s => s switch
            {
                State.TestDone => true,
                _ => false
            })
            .Subscribe(e => buttonControl.Enabled = e);
    }

    private async Task Test()
    {
        await Task.Delay(1000);
    }

    private async Task Control()
    {
        await Task.Delay(1000);
    }

    #region ButtonClickObservables

    private IObservable<Unit> GetClicks(Button button) =>
        Observable
            .FromEventPattern<EventHandler, EventArgs>(
                h => button.Click += h,
                h => button.Click -= h)
            .Select(_ => Unit.Default);

    #endregion
}