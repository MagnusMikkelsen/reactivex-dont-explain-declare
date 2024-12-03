<Query Kind="Expression">
  <NuGetReference>System.Reactive.Linq</NuGetReference>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

Observable
	.Timer(TimeSpan.Zero, TimeSpan.FromMilliseconds(100))
	.Take(10)
	//.Where(x => x % 2 == 0)
	//.Sum()