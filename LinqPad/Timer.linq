<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <NuGetReference>System.Reactive.Linq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
  <Namespace>LINQPad.Controls</Namespace>
</Query>

using System.Reactive.Linq;

IObservable<long> ticks = Observable.Timer(
	dueTime: TimeSpan.Zero,
	period: TimeSpan.FromSeconds(1));
	
var subscription = ticks.Subscribe(
	tick => Console.WriteLine($"Tick {tick}"));
	
new Button("Stop", _ => subscription.Dispose()).Dump();