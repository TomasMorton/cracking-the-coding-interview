/*
	Given a set, return all subsets
	Set means distinct
	Assumptions:
		a set is a subset of itself
		The empty set is a subset of all sets
	
	
	
	ideas:
		Brute force:
			iterate on each value and take increasingly larger chunks until the end of the set is reached
			
		Recursive:
			building from the empty set, combine one element in the initial set with the results of the previous recurion level.
		
*/
public class PowerSetter
{
	public List<Set<T>> GetPowerSetOf(Set<T> set)
	{
		if (set == null)
			return CreateEmptySetResult();
		
		return Powerify(set).ToList();
	}
	
	private IEnumerable<Set<T>> Powerify(Set<T> set)
	{
		if (!set.Any())
			return CreateEmptySetResult();
		
		var permutations = Powerify(set.Tail);
		var newSets =
			permutations
			.Select(x => x.Add(set.Head));
			
		return permutations.Concat(newSets);
	}

	private List<Set<T>> CreateEmptySetResult()
		=> new List<Set<T>>(new Set<T>());
	
}