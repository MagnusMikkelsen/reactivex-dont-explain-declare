<Query Kind="Statements">
  <NuGetReference>System.Reactive.Linq</NuGetReference>
  <Namespace>LINQPad.Controls</Namespace>
</Query>

using System.Reactive.Linq;


IObservable<long> ticks = Observable.Timer(
	dueTime: TimeSpan.Zero,
	period: TimeSpan.FromSeconds(1));


var subscription = 
	ticks
		.Subscribe(tick => Console.WriteLine($"Tick {tick}"));
	
new Button(
	"Dispose", 
	onClick: _ => subscription.Dispose())
	.Dump();