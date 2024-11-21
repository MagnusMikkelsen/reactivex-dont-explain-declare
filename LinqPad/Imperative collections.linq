<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

List<int> source = [1,2,3,4,5,6,7,8,9];
List<int> filtered = [];

// Only include even numbers
for (int i = 0; i < source.Count; i++)
{
	var current = source[i];
	if (current % 2 == 0)
		filtered.Add(current);
}

filtered.Dump("Filtered items: ");

// Calculate the sum
var sum = 0;
foreach (var element in filtered)
{
	sum += element;
}

sum.Dump("The sum:");