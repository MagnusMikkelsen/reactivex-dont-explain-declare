<Query Kind="Program">
  <NuGetReference>System.Reactive</NuGetReference>
  <Namespace>LINQPad.Controls</Namespace>
  <Namespace>System.Reactive.Disposables</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	#region buttons
	var onNextButton = new Button("Next");
	var onCompleteButton = new Button("Complete");
	var onErrorButton = new Button("OnError");
	Util.HorizontalRun(true, onNextButton, onCompleteButton, onErrorButton).Dump();
	#endregion
	
	// foo.Event += (s,e) => {}	
	
	var obs = new MyObservable(onNextButton, onCompleteButton, onErrorButton)
		//.Subscribe(new MyObserver())
		.Dump()
		;
}

public class MyObservable : IObservable<int>
{
	#region fields and ctor
	private Button _onNextButton;
	private Button _onCompleteButton;
	private Button _onErrorButton;

	public MyObservable(Button onNextButton, Button onCompleteButton, Button onErrorButton)
	{
		_onNextButton = onNextButton;
		_onCompleteButton = onCompleteButton;
		_onErrorButton = onErrorButton;
	}
	#endregion

	public IDisposable Subscribe(IObserver<int> observer)
	{	
		var i = 0;
		
		// Needs more logic to dissallow several oncompleted or onerror
		// and following onnext calls.
		
		#region subscribe
		EventHandler onNext = 
			(_, _) =>  observer.OnNext(i++);
		_onNextButton.Click += onNext;
		
		EventHandler onCompleted = 
			(_, _) =>  observer.OnCompleted();
		_onCompleteButton.Click += onCompleted;
		
		EventHandler onError = 
			(_, _) => observer.OnError(new Exception("error"));
		_onErrorButton.Click += onError;
		#endregion
		
		#region unsubscribe
		var unsubscribe = Disposable.Create(() =>
		{
			_onNextButton.Click -= onNext;
			_onCompleteButton.Click -= onCompleted;
			_onErrorButton.Click -= onError;
		});
		#endregion
		
		return unsubscribe;
	}
}

public class MyObserver : IObserver<int>
{
	public void OnCompleted()
	{
		"COMPLETED".Dump();
	}

	public void OnError(Exception error)
	{
		error.Dump();
	}

	public void OnNext(int value)
	{
		value.Dump();
	}
}
