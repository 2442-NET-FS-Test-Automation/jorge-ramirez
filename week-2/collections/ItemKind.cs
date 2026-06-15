namespace LibraryKata.Domain;

// Enum -> its a custom value, where we basically enumerate possible values ahead of time

public enum ItemKind
{
    // my enum definition contains posibble values for an instance of this enum
    // an ItemKind can ONLY ever be one of these 3 things. I can come back and add more latter
    Book,
    ReferenceBook,
    Magazine
}