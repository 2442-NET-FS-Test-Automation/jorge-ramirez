namespace LibraryKata.Domain;

// Interfaces in C# - they are contract for behaviors- they do not define the implementation of their methods
public interface ILendable
{
    bool Checkout();
    void Return();
}