using System.Reflection;

namespace LibraryKata.Domain;

// abstract can't be instantiated
// it will still have a constructor - because child classes need to be able to call their parent'a constructor, but not via NEW
public abstract class LibraryItem
{
    public string? Title{get; private set;}
    public string? Author{get; private set;}
    private static int _nextId = 1;
    public int Id{get;}

    // abstract class DOES hae a constructor
    // so far we've dealt with public and provate access modifiers
    // public: anyone can see/call this
    // private: only accessible within this class
    // protected: this class and derived (child) classes only
    protected LibraryItem(string title, string author)
    {
        Id = _nextId++;
        Title = title;
        Author = author;
    }

    // Abstract method - only a signature - no body
    public abstract string Describe();
    // abstract classes can contain concrete implementation - and we can mix abstract methods to save time later
    // its child will implement Describe()
    public override string ToString() => Describe();

    // concrete methods have a body, abstract methods must be overriden... virtual methods have a body and may be overriden
    public virtual string ShelfLabel()
    {
        return $"{Id}: {Title}";
    }
}
