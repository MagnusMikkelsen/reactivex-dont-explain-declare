<Query Kind="Statements">
  <NuGetReference>System.Reactive.Linq</NuGetReference>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>


#region async method
var sw = Stopwatch.StartNew();
async Task Foo(long i, CancellationToken ct)
{	
	$"{i} start @{sw.ElapsedMilliseconds}".Dump();	
	try
	{	   
		
		await Task.Delay(1000, ct);
		$"    {i} done @{sw.ElapsedMilliseconds}".Dump();	
	}
	catch (OperationCanceledException)
	{
		$"    {i} cancel @{sw.ElapsedMilliseconds}".Dump();	
	}
}
#endregion

Observable
	.Timer(TimeSpan.Zero, TimeSpan.FromMilliseconds(500))
	.Take(3)
	.Select(i => 
		Observable.FromAsync(
			ct => Foo(i, ct)))
	.Switch()
	//.Merge()
	.Dump();
	
	