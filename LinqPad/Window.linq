<Query Kind="Statements">
  <NuGetReference>System.Reactive.Linq</NuGetReference>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

long[] seq = [2,3,4];

Observable
	.Interval(TimeSpan.FromMilliseconds(500))
	.Take(10)
	//.Window(3, 1)
	//.Select(x => x.SequenceEqual(seq))
	.Dump();