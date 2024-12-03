<Query Kind="Statements">
  <NuGetReference>System.Reactive.Linq</NuGetReference>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

Observable
	.Range(0, 10)
	.Subscribe(x => Console.WriteLine(x));