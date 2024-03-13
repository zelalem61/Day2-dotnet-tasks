using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library("My Library", "123 Main St");

        bool continueAdding = true;
        while (continueAdding)
        {
            Console.WriteLine("Add a new item to the library (1: Book, 2: Media Item, 3: Finish):");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddBook(library);
                    break;
                case "2":
                    AddMediaItem(library);
                    break;
                case "3":
                    continueAdding = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        library.PrintCatalog();
    }

    static void AddBook(Library library)
    {
        try
        {
            Console.WriteLine("Enter the title of the book:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter the author of the book:");
            string author = Console.ReadLine();
            Console.WriteLine("Enter the ISBN of the book:");
            string isbn = Console.ReadLine();
            Console.WriteLine("Enter the publication year of the book:");
            int publicationYear = int.Parse(Console.ReadLine());

            library.AddBook(new Book(title, author, isbn, publicationYear));
            Console.WriteLine("Book added to the library.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Publication year must be a valid integer.");
        }
    }

    static void AddMediaItem(Library library)
    {
        try
        {
            Console.WriteLine("Enter the title of the media item:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter the type of the media item:");
            string mediaType = Console.ReadLine();
            Console.WriteLine("Enter the duration of the media item in minutes:");
            int duration = int.Parse(Console.ReadLine());

            library.AddMediaItem(new MediaItem(title, mediaType, duration));
            Console.WriteLine("Media item added to the library.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Duration must be a valid integer.");
        }
    }
}

class Library
{
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Book> Books { get; set; }
    public List<MediaItem> MediaItems { get; set; }

    public Library(string name, string address)
    {
        Name = name;
        Address = address;
        Books = new List<Book>();
        MediaItems = new List<MediaItem>();
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        Books.Remove(book);
    }

    public void AddMediaItem(MediaItem item)
    {
        MediaItems.Add(item);
    }

    public void RemoveMediaItem(MediaItem item)
    {
        MediaItems.Remove(item);
    }

    public void PrintCatalog()
    {
        Console.WriteLine("Books:");
        foreach (var book in Books)
        {
            Console.WriteLine($"{book.Title} by {book.Author}, ISBN: {book.ISBN}, Year: {book.PublicationYear}");
        }

        Console.WriteLine("\nMedia Items:");
        foreach (var item in MediaItems)
        {
            Console.WriteLine($"{item.Title}, Type: {item.MediaType}, Duration: {item.Duration} minutes");
        }
    }
}

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int PublicationYear { get; set; }

    public Book(string title, string author, string isbn, int publicationYear)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        PublicationYear = publicationYear;
    }
}

class MediaItem
{
    public string Title { get; set; }
    public string MediaType { get; set; }
    public int Duration { get; set; }

    public MediaItem(string title, string mediaType, int duration)
    {
        Title = title;
        MediaType = mediaType;
        Duration = duration;
    }
}
