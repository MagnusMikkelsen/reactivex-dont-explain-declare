<Query Kind="Program">
  <NuGetReference>morelinq</NuGetReference>
  <NuGetReference>System.Reactive</NuGetReference>
  <Namespace>LINQPad.Controls</Namespace>
  <Namespace>MoreLinq</Namespace>
  <Namespace>System.Reactive.Disposables</Namespace>
</Query>

void Main()
{
	new MyObservable()
		//.Subscribe(new MyObserver())
		.Dump()
		;	
}


public class MyObservable : IObservable<int>
{
	public IDisposable Subscribe(IObserver<int> observer)
	{	
		var i = 0;
		var next = new Button(
			"On Next",
			_ => observer.OnNext(i++)).Dump();
			
		var complete = new Button(
			"Complete", 
			_ => observer.OnCompleted()).Dump();
			
		var error = new Button(
			"Error", 
			_ => observer.OnError(new Exception("error"))).Dump();
			
		return Disposable.Empty;
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
