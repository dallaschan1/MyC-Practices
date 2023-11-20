/* Test Question 2: Integrating Multiple Concepts
Imagine you are creating a simple C# program to manage a book club. Here's your task:

Book Club Management:

Create a Dictionary<string, string> where each key is a book name and the 
value is the author's name. Add at least 5 books to this dictionary.
Book Name: "To Kill a Mockingbird", Author: Harper Lee
Book Name: "1984", Author: George Orwell
Book Name: "The Great Gatsby", Author: F. Scott Fitzgerald
Book Name: "Pride and Prejudice", Author: Jane Austen
Book Name: "Moby-Dick", Author: Herman Melville
Create a Queue<string> representing members waiting to borrow a book. Add at least 3 member names to this queue.
Book Availability Check:

Write a method IsBookAvailable that takes the book name as a parameter and checks if 
the book is available in the dictionary. It returns true if the book is available and false otherwise.
Borrowing Books:

Using a for or while loop, iterate over the queue of members.
For each member, randomly select a book from the dictionary.
If the book is available (use the IsBookAvailable method), print a message saying 
the member has borrowed the book and remove the book from the dictionary.
If not, print a message saying the book is not available.
Date and Time:

For each borrowing transaction, print the current date and time in the format "dd-MM-yyyy HH:mm:ss".
File I/O:

Write the details of each borrowing transaction to a text file including the member's name, 
the book borrowed, and the date-time of the transaction.
This question tests your ability to use collections (Dictionary, Queue), control structures 
(if-else, loops), methods, and basic file I/O operations, along with working with dates and times.*/
class Program
{
    static void Main(String[] args)
    {
        Dictionary<string, string> Library = new Dictionary<string, string>();
        Library.Add("To Kill a Mockingbird", "Harper Lee");
        Library.Add("1984", "George Orwell");
        Library.Add("Name3", "Author3");
        Library.Add("Name4", "Author4");
        Library.Add("Name5", "Author5");

        Queue<string> Queue = new Queue<string>();
        Queue.Enqueue("P1");
        Queue.Enqueue("P2");
        Queue.Enqueue("P3");
        

        Random rand = new Random();
        List<string> keys = new List<string>(Library.Keys);
        string filePath = "C:\\PRG ASSIGNMENTS C# PRACTICES\\MyC-Practices\\2nd practice\\practice 2\\example.txt";
        using(StreamWriter streamWriter = new StreamWriter(filePath))
        {
            foreach (string members in Queue)
            {
                string randomKey = keys[rand.Next(keys.Count)];
                if (Checker(randomKey, Library) == true)
                {
                    DateTime dateTime = DateTime.Now;
                    Console.WriteLine($"{randomKey} has been borrowed at {dateTime}");
                    Library.Remove(randomKey);
                    streamWriter.WriteLine($"{randomKey} has been borrowed by {members} at {dateTime}");
                }
                else
                {
                    Console.WriteLine($"{randomKey} is Not Available");

                };
            }
        }

    }

    static public bool Checker(string Bookname, Dictionary<string, string> library)
    {
        return library.ContainsKey(Bookname);
    }
}