using System.Diagnostics;

namespace LibraryKata.Domain;

public class OldBook
{
    // ? - make the propertied nullable
    public string? Title{get; private set;}
    public string? Author{get; private set;}
    public int? CopiesAvailable{get; private set;}
    // static methods belong to the class
    private static int _nextId = 1; //underscore by convention
    public int Id{get;}

    public OldBook(string title, string author, int copiesAvailable)
    {
        Title = title;
        Author = author;
        CopiesAvailable = copiesAvailable;
        Id = _nextId++; // asign the value and increment it
    }
    public OldBook(){}

    public bool Checkout() // access modifyer + return type + any argument
    {
        if (CopiesAvailable == 0)
            return false;
        CopiesAvailable--;
        return true;
    }
    public void Return() => CopiesAvailable++;

    public override string ToString()
    {
        return $"Name: {Title}, Author: {Author}, Copies available: {CopiesAvailable}";
    }
}