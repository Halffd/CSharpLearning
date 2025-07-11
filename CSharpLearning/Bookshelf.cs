using System;
using System.Collections.Generic;
using System.Linq;

// For the IEnumerable example:
IEnumerable<Book> GetBooks(IEnumerable<Book> books)
{
    int i = 0;
    foreach (Book book in books)
    {
        Console.WriteLine($"Book {i}: {book.Title}");
        yield return book;
        i++; // Move this after yield return, and remove the duplicate i++
    }
}

// For the generic type system example:
public class BookCollection<T> where T : Book
{
    private List<T> books = new List<T>();
    
    public void AddBook(T book)
    {
        books.Add(book);
    }
    
    public T GetBook(int index)
    {
        return books[index];
    }
    
    public int Count => books.Count; // Use property instead of method
    
    public IEnumerable<T> Books => books; // Expose books for iteration
}

// For generics with constraints:
public class Repository<T> where T : class, new()
{
    private List<T> items = new List<T>();
    
    public void Add(T item)
    {
        items.Add(item);
    }
    
    public T CreateNew()
    {
        return new T();
    }

    public T Get(int index)
    {
        return items[index];
    }
    
    public int Count => items.Count; // Use property instead of method
    
    public IEnumerable<T> Items => items; // Expose items for iteration
}

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Pages { get; set; }
}

public class Bookshelf
{
    private List<Book> books = new List<Book>(); // Make it a List, not IEnumerable
    
    public void AddBook(Book book)
    {
        books.Add(book);
    }
    
    public Book GetBook(int index)
    {
        return books[index];
    }
    
    public int Count => books.Count; // Use property instead of method
    
    public IEnumerable<Book> Books => books; // Expose books for iteration
    
    public static void Run()
    {
        Bookshelf bookshelf = new Bookshelf();
        bookshelf.AddBook(new Book { Title = "Book 1", Author = "Author 1", Pages = 100 });
        bookshelf.AddBook(new Book { Title = "Book 2", Author = "Author 2", Pages = 200 });
        bookshelf.AddBook(new Book { Title = "Book 3", Author = "Author 3", Pages = 300 });
        
        Console.WriteLine($"Bookshelf has {bookshelf.Count} books");
        Console.WriteLine($"Book 1: {bookshelf.GetBook(0).Title}");
        Console.WriteLine($"Book 2: {bookshelf.GetBook(1).Title}");
        Console.WriteLine($"Book 3: {bookshelf.GetBook(2).Title}");

        var booksFromShelf = GetBooks(bookshelf.Books);
        foreach (Book book in booksFromShelf)
        {
            Console.WriteLine($"Processed book: {book.Title}");
        }
        
        Repository<Book> repository = new Repository<Book>();
        repository.Add(new Book { Title = "Repo Book 1", Author = "Author 1", Pages = 100 });
        repository.Add(new Book { Title = "Repo Book 2", Author = "Author 2", Pages = 200 });
        repository.Add(new Book { Title = "Repo Book 3", Author = "Author 3", Pages = 300 });
        
        Console.WriteLine($"Repository has {repository.Count} books");
        Console.WriteLine($"Book 1: {repository.Get(0).Title}");
        Console.WriteLine($"Book 2: {repository.Get(1).Title}");
        Console.WriteLine($"Book 3: {repository.Get(2).Title}");
        
        var booksFromRepo = GetBooks(repository.Items);
        foreach (Book book in booksFromRepo)
        {
            Console.WriteLine($"Processed repo book: {book.Title}");
        }
        
        BookCollection<Book> bookCollection = new BookCollection<Book>();
        bookCollection.AddBook(new Book { Title = "Collection Book 1", Author = "Author 1", Pages = 100 });
        bookCollection.AddBook(new Book { Title = "Collection Book 2", Author = "Author 2", Pages = 200 });
        bookCollection.AddBook(new Book { Title = "Collection Book 3", Author = "Author 3", Pages = 300 });
        
        Console.WriteLine($"BookCollection has {bookCollection.Count} books");
        Console.WriteLine($"Book 1: {bookCollection.GetBook(0).Title}");
        Console.WriteLine($"Book 2: {bookCollection.GetBook(1).Title}");
        Console.WriteLine($"Book 3: {bookCollection.GetBook(2).Title}");
        
        var booksFromCollection = GetBooks(bookCollection.Books);
        foreach (Book book in booksFromCollection)
        {
            Console.WriteLine($"Processed collection book: {book.Title}");
        }
        
        // For nullable value types (C# 2 feature):
        int? nullableInt = null;
        if (nullableInt.HasValue)
        {
            Console.WriteLine($"Value: {nullableInt.Value}");
        }
        else
        {
            Console.WriteLine("Nullable int has no value");
        }
    }
}
