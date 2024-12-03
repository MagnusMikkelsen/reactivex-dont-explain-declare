<Query Kind="Statements">
  <NuGetReference>System.Reactive.Linq</NuGetReference>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

#region another observable
IObservable<double> AnotherObservable(int x) => Observable
		.Interval(TimeSpan.FromMilliseconds(500))
		.Select(y => y * Math.Pow(10, x))
		.Delay(TimeSpan.FromMilliseconds(100 * x))
		.Take(5);
#endregion


Observable
	.Range(0,3)
	.Select(x => AnotherObservable(x))
	//.Merge()
	.Dump();