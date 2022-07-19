/*
	FIFO - so queue
	Only dogs and cats, but consider more generic
	oldest = first queued
	partitioned by type - dog or cat

	ideas:
		- Dedicated queue variables for dog and cat, including the time received
		- HashMap<string, Queue<(Animal animal, DateTime received)>>		
*/
public class AnimalShelter
{	
	public int Count { get; private set; } = 0;

	private readonly HashMap<AnimalType, Queue<AnimalReceipt>> _animals = new();
	
	public Animal? DequeueAny()
	{
		AnimalReceipt? oldestReceipt = null;
		foreach(var queue in _animals)
		{
			if (queue.Any())
			{
				var oldestOfType = queue.Peek();
				if (oldestReceipt == null || oldestOfType.ReceivedAt < oldestReceipt.ReceivedAt)
					oldestReceipt = oldestOfType;
			}
		}
		
		if (oldestReceipt == null)
			return null;
		
		return Dequeue(oldestReceipt.Type);
	}
	
	public Animal? Dequeue(AnimalType type)
	{
		var queue = GetAvailableAnimalsOfType(type);
		if (!queue.Any())
			return null;
		
		return queue.Dequeue().Animal;
	}
	
	public void Enqueue(Animal animal)
	{
		if (animal == null) throw new NullArgumentException();

		var receipt = new AnimalReceipt(animal, DateTime.UtcNow);
		var queue = GetAvailableAnimalsOfType(animal.Type);
		queue.Add(receipt);
	}
	
	private Queue<AnimalReceipt> GetAvailableAnimalsOfType(AnimalType type)
	{
		if (_animals.TryGetValue(type, out var result))
			return result;
		
		var newQueue = new Queue<AnimalReceipt>();
		_animals.Add(newQueue);
		return newQueue;
	}
}

public record Animal(string Name, AnimalType Type);
public record AnimalReceipt(Animal Animal, DateTime ReceivedAt);
public enum AnimalType { Dog, Cat };