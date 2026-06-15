namespace LibraryKata.Domain;

public class Book : LibraryItem, ILendable
{
    // unique for a book
    public int CopiesAvailable{get; private set;}

    // child class constructor
    public Book(string title, string author, int copiesAvailable) : base(title, author)
    {
        CopiesAvailable = copiesAvailable;
    }

    // abstract method overrider
    public override string Describe()
    {
        return $"{Id} - {Title} by {Author} has {CopiesAvailable} copies available for checkout";
    }

    public bool Checkout()
    {
        if (CopiesAvailable == 0)
            return false;
        CopiesAvailable--;
        return true;
    }
    public void Return() => CopiesAvailable++;
}