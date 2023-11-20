/* 
Test Question 3: Class Creation and Advanced Collection Manipulation
Scenario: Library Management System
You are developing a part of a library management system. Here's your task:

Create a Book Class:

Properties: Title (string), Author (string), IsAvailable (bool).
Constructor: Parameters for title and author. IsAvailable should be initially set to true.
Method: BorrowBook(), which sets IsAvailable to false.
Manage Library:

Create a List<Book> representing all books in the library.
Add at least 5 Book objects to this list, with titles and authors of your choice.
Simulate Borrowing Process:

Randomly select a book from the list.
If the book is available (IsAvailable is true), print a message that the book is being borrowed and 
call the BorrowBook() method on it.
If the book is not available, print a message stating that the book is already borrowed.
Enhance the Process:

After a book is borrowed, remove it from the list.
Continue the process until all books have been borrowed or attempted to be borrowed.
This question tests your ability to create and use classes, manage collections, implement basic logic 
with control structures, and simulate a real-world process. It also gives you a chance to practice encapsulation, 
one of the key principles of object-oriented programming.

Please go ahead and implement this scenario. If you need any hints or have questions, feel free to ask! 
*/

using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        List<Book> books = new List<Book>();
        Book book1 = new Book("T1", "A1");
        Book book2 = new Book("T2", "A2");
        Book book3 = new Book("T3", "A3");
        Book book4 = new Book("T4", "A4");
        Book book5 = new Book("T5", "A5");
        books.Add(book1);
        books.Add(book2);
        books.Add(book3);
        books.Add(book4);
        books.Add(book5);

        Random random = new Random();

        while (books.Count > 0)  
        {
            Book ran = books[random.Next(books.Count - 1)];
            if (ran.IsAvailable == true)
            {
                Console.WriteLine($"{ran.Title} is being borrowed");
                ran.BorrowBook();
                books.Remove(ran);

            }
            else
            {
                Console.WriteLine("Unavailable");

            }
        }
    }
}

class Book
{
    private string title;
    private string author;
    private bool isavailable;

    public string Title 
    {
        get { return title; } 
        set { title = value; }
    }
    public string Author 
    { 
        get { return author; } 
        set { author = value; } 
    }
    public bool IsAvailable 
    { 
        get { return isavailable; } 
        set { isavailable = value; } 
    }

    public Book(string title, string author, bool isavailable = true)
    {
        this.title = title;
        this.author = author;
        this.isavailable = isavailable;

    }

    public void BorrowBook()
    {
        this.IsAvailable = false;
    }


}