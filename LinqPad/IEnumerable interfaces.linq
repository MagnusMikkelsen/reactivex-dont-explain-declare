<Query Kind="Program">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

void Main()
{
	new MyEnumerable()
		.Dump();	
}

public class MyEnumerable : IEnumerable<int>
{
	public IEnumerator<int> GetEnumerator()
	{
		return new MyEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new MyEnumerator();
	}
}

public class MyEnumerator : IEnumerator<int>
{
	int i = -1;
	int[] source = [1,2,3,4,5,6,7,8,9];	
	
	public int Current => source[i];

	object IEnumerator.Current => Current;

	public void Dispose() {	}

	public bool MoveNext()
	{	
		i++;
		return (i < source.Length);
	}

	public void Reset()
	{
		i = 0;
	}
}
