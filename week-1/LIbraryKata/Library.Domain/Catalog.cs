namespace LibraryKata.Domain;

public class Catalog
{
    // list: ordered, grow/shrink dynamically, accesible via index
    public readonly List<LibraryItem> _items = new(); // instead of new List<LibraryItem>;
    public int Count => _items.Count();

    // Stack<T> - last in first out - we will model a return cart, the most recently returned item is re-shelved first
    // primary methods : Push() - put an item at top of the Stack / Pop() - removes the top most item
    public readonly Stack<LibraryItem> _returnCart = new();

    // Queue<T>: First In First Out - modeling a hold queue, customer placing holds on books
    // Primary methods : Push() - puts an item at the top of the stack / Pop() - removes from the front of the line
    public readonly Queue<string> _holdQueue = new();

    // Reading List
    // LinkedList<T> - cheap insert/removal anywhere in my list, but not index classes
    public readonly LinkedList<LibraryItem> _readingLIst = new();
}