namespace librarykata.App; // A namespace is like a container for classes and other types. It helps to organize code and avoid naming conflicts.

using System.Data;
using LibraryKata.Domain;

public class Program
{
    // public - accesible across the entire application
    // static - Main can be called upon without a Program object. It is a static/class method
    //void - it doesn't return anything
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!"); 
        ClassesExample();
        OopDemo();
        CollectionsDemo();
    }

    //private - only accessible within this class
    // static - it belongs to the class, not objects of a class
    // void - returns nothing
    private static void DataTypesAndOperators() // If I have arguments or inputs for this methos, they would be inside the parentesis
    {

    }

    private static void ControlFlow()
    {
        Console.WriteLine("Contorl Flows1");

        // if else
        bool condition = true;

        if(condition)
            Console.WriteLine("Is true");
        else if(!condition)
            Console.WriteLine("Maybe not");
        else
            Console.WriteLine("Deffinitlely not");
        
        // switch
        string genre = "Action".ToLower();

        switch(genre)
        {
            case "mystery":
                Console.WriteLine("You are a Mistery");
                break;
            case "action":
                Console.WriteLine("You are an Action");
                break;
            default:
                Console.WriteLine("Are you a movie");
                break;
        }

        string section = genre switch
        {
          "Mystery" => "Section A",
          "Action" => "Section B",
          _ => "You are a default"   
        };
    }
    private static void Loops()
    {
        for(int day = 1; day <= 3; day++)
        {
            Console.WriteLine($"Reminder day {day}: fee so far {CalculateLateFee(day)}");
        }

        int onShelf = 3;
        while(onShelf > 0)
            Console.WriteLine($"{onShelf} copies on the shelf");
            onShelf--;
        
    }

    private static decimal CalculateLateFee(int daysLate) => daysLate * 2;

    private static void ArraysWork()
    {
        string[] books = {"Dune", "Harry Potter", "Any others"};
        Console.WriteLine(books[2]);
        foreach(string book in books)
        {
            Console.WriteLine(book);
        }
    }

    private static void ClassesExample()
    {
        Console.WriteLine("Using Our Domain Class");
        
        // instanciating book, calling the constructor via new
        Book dune = new Book("Dune", "Frank Herbert", 3);
        OldBook littlePrince = new OldBook("Little Prince", "Antonie", 0);

        Console.WriteLine(dune);
        Console.WriteLine(littlePrince.ToString());

        Console.WriteLine($"Checking out Dune:  {dune.Checkout()}");
        Console.WriteLine($"Checking out for the litle Prince: {littlePrince.Checkout()}");


    }

    public static void OopDemo()
    {
        Console.WriteLine("\n OOP Demo stuff");

        LibraryItem[] catalog =
        {
            new Book("Harry", "Frank", 2),
            new ReferenceBook("C# Languaje Standards", "Microsoft", "Technology"),
            new Magazine("Sports Ilustrator", "Antonio Alcalde", "Conde Maste", 5)
        };
        foreach(LibraryItem item in catalog)
            Console.WriteLine(item.Describe());
        // we can even use interfaces as reference types
        foreach(LibraryItem item in catalog)
        {
            if(item is ILendable lendable)
            {
                Console.WriteLine($"{item.Title}: checkout {lendable.Checkout()}");
            }
            else
            {
                Console.WriteLine($"{item.Title} is reference only");
            }
        }
        // override vs new behaivor
        Magazine wired = new Magazine("Wired", "Luis", "WLS", 3);
        LibraryItem baseMag = wired;

        Console.WriteLine("Override vs new on the sema object, different reference");
        Console.WriteLine($"Magazine reference -> {wired.Describe}");
        Console.WriteLine($"LibraryItem reference -> {baseMag.Describe}");
    }

    // Collections demo stuff
    private static void CollectionsDemo()
    {
        Console.WriteLine("----- Collections --------");
        // creating catalog item
        Catalog catalog = new();
        // create my object
        Book dune = new Book("Dune", "Frank", 3);
        // then add the item
        catalog._items.Add(dune);

        // I can also just call the constructor inside the Add() method call
        // methods having their arguments satisfied by the returns of the other methods is a common pattern
        // and sometimes you'll get like 4-5 callbacks deep in tools like ASP.NET
        catalog._items.Add(new ReferenceBook("C# Language Specs", "Microsoft", "Technology"));
        catalog._items.Add(new Magazine("Net Geo", "Charlie", "Conde Naste", 3));

        Console.WriteLine($"Catalog holds {catalog._items.Count}; first is {catalog._items[0].Title}");

        // Enum + Struc use
        ItemKind kind = ItemKind.Magazine;
        ShelfLocation location = new ShelfLocation(3, 12);
        Console.WriteLine($"{kind} sits a {location}");

        Book duneCopy = dune; // copies the reference
        // if change one, change the other too

        ShelfLocation location2 = location; // copies the data/fields
        // these are not linked in the same way

        // Generics: our own Shelf<T> that can hold anyhting - though technically all the collections
        // we use thusfar have been generic classes themselves
        Shelf<LibraryItem> shelf = new Shelf<LibraryItem>(10) ;
        Shelf<int> intShelf = new Shelf<int>(200);

        shelf.TryAdd(catalog._items[0]);
        shelf.TryAdd(catalog._items[1]);

        Console.WriteLine($"Trying to add a third thing in our catalog: {shelf.TryAdd(catalog._items[2])}");
    }
}
