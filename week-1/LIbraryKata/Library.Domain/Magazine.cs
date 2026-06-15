using System.Runtime.CompilerServices;

namespace LibraryKata.Domain;

public class Magazine: LibraryItem, ILendable
{
    public int CirculationCopies{get; private set;}
    public string Publisher{get;}

    public Magazine(string title, string author, string publisher, int circulationCopies) : base(title, author)
    {
        CirculationCopies = circulationCopies;
        Publisher = publisher;
    }

    public override string Describe()
    {
        return $"{Title} magazine, published by {Author}";
    }

    // providing implementation via new instead of override
    // this is technically Method Hiding- depends on the reference type
    // calling this method in an object instantiated like this:
    // LibraryItem sportIlustrated = new Magazine(...); calls libraryItem shelflabel
    //  this is most likely not what you want
    public new string ShelfLabel()
    {
        return $"MAG-{Id} {Title}";
    }

    public bool Checkout() // access modifyer + return type + any argument
    {
        if (CirculationCopies == 0)
            return false;
        CirculationCopies--;
        return true;
    }
    public void Return() => CirculationCopies++;
}