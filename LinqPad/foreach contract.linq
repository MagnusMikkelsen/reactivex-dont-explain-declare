<Query Kind="Program">
  <Output>DataGrids</Output>
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

void Main()
{
	foreach (var x in new Foo())
	//foreach(var x in Baz())
	{
		x.Dump();
	}
}

#region contract
public class Foo
{
	public Bar GetEnumerator() => new Bar();	
}

public class Bar
{
	private int i = -1;
	
	public int Current => i;

	public bool MoveNext()
	{
		i++;
		return i < 10;
	}	
}
#endregion

#region yield return
IEnumerable<int> Baz()
{
	yield return 42;
	yield return 25;
}

//Generates:
//https://sharplab.io/#v2:EYLgZgpghgLgrgJwgZwLQAUoKgW2QYQHsAbYiAYxgEtCA7ZAHwFgAoVgAQAYACdgRgAsAblYc+AZgA8VWjAB83AGKFCACgCUrAN6tue3nz68A7NwEAmES30Gj7U+YCsVgL6sgA==



#endregion
