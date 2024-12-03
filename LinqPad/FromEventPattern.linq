<Query Kind="Statements">
  <NuGetReference>System.Reactive.Linq</NuGetReference>
  <Namespace>LINQPad.Controls</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

var button = new Button("Click");

var observable = Observable.FromEventPattern<EventHandler, EventArgs>(
	h => button.Click += h,
	h => button.Click -= h)
	.Select(_ => "Click!");	
	
button.Dump();
observable.Dump();


