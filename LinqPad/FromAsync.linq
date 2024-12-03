<Query Kind="Statements">
  <NuGetReference>System.Reactive.Linq</NuGetReference>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>


async Task<string> Foo()
{	
	await Task.Delay(500);
	return "Hej";
}


var fooObservable = Observable.FromAsync(Foo);

fooObservable.Dump();