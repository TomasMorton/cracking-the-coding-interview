//to push, always send to _pusher
//to pop, take from _popper if exists. If not, flip from pusher

public class MyQueue<T>
{
  private readonly Stack<T> _pusher = new();
  private readonly Stack<T> _popper = new();

  public T Dequeue() //or remove
  {
    if (!_popper.Any())
        MoveItemsForDequeueing();

    return _popper.Pop();
  }

  public void Enqueue(T data) //or add
  {
    _pusher.Push(data);
  }

  private void MoveItemsForDequeueing()
  {
    if (!_pusher.Any())
      throw new EmptyQueueException();

    while (_pusher.Any())
      _popper.Push(_pusher.Pop());
  }

  //todo: size
  //todo: peek
}
