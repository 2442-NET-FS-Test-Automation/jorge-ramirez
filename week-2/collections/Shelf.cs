namespace LibraryKata.Domain;

// Generics
// T is the standard placeholder for .. "Some type" that we will determine later
public class Shelf<T>
{
    private readonly T[] _slots;
    private int _used;
    public Shelf(int capacity)
    {
        _slots = new T[capacity];
    }
    // exposing some array property as needed
    public int Capacity => _slots.Length;
    public int Count => _used; // exposing that use as public property

    // methos to add item to our shelf
    public bool TryAdd(T item)
    {
        if(_used == _slots.Length())
            return false;

        // is the shlef sin't full then..
        // access the _slots arrays index the current used +1
        // increment used
        _slots[_used++] = item;
        return true;
    }

    // methor to allow index access
    public T Get(int index)
    {
        return _slots[index];
    }
}