<Query Kind="Statements">
  <NuGetReference>System.Reactive.Linq</NuGetReference>
  <Namespace>System.Reactive.Disposables</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var obs = Observable
	.Range(0, 1)
	.SelectMany(x => Observable.FromAsync(async () =>
	{
		"Called".Dump();
		await Task.Yield();
	}))
	.Publish().RefCount()
	;
	
using var s1 = obs.Subscribe();
using var s2 = obs.Subscribe();
using var s3 = obs.Subscribe();
using var s4 = obs.Subscribe();
using var s5 = obs.Subscribe();


