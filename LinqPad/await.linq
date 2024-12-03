<Query Kind="Statements">
  <NuGetReference>System.Reactive.Linq</NuGetReference>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

var result = await Observable.Interval(TimeSpan.FromMilliseconds(10)).Take(100);

result.Dump();