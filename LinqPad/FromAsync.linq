<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <NuGetReference>System.Reactive.Linq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>


async Task<string> Foo()
{
	"Foo called".Dump();
	await Task.Delay(500);
	"Foo completed".Dump();
	return "Hej";
}


var fooObservable = Observable.FromAsync(Foo);

"Before subscribe".Dump();

fooObservable.Dump();