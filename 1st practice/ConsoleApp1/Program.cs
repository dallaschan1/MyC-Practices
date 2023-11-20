/*Test Question 1: Collections and String Manipulation
You are working on a C# application that processes a list of names and performs various operations. Here's your task:

Create a List<string> named names and initialize it with at least five different names.
Sort the List: Sort the names alphabetically.
Stack Operations:
Create a Stack<string> and push all names from the sorted list onto the stack.
Pop each name from the stack and print it, which should display the names in reverse alphabetical order.
String Manipulation:
For each name, before adding it to the stack, concatenate the string " - Processed" to the name.
Dictionary Usage:
Create a Dictionary<string, int> where each key is a name (from the original list) and the value is 
the length of the name.
Print the dictionary content.
This question combines the use of generic collections (List<T> and Stack<T>), string manipulation, 
and the use of a Dictionary<TKey, TValue>. It tests your ability to manipulate collections, iterate over them, 
and perform basic string operations.*/


List<string> Names = new List<string>{"John", "Dames", "tom", "elf", "bella"};
SortedList<string, int> SortedNames = new SortedList<string, int>();

foreach (string name in Names)
{
    Console.WriteLine(name);
    SortedNames.Add(name, 1);
}

Stack<string> stacked_names = new Stack<string>();
foreach (var key in SortedNames)
{
    string changed_key = key.Key + "- Processed";
    stacked_names.Push(changed_key);
}

while (stacked_names.Count > 0)
{
    string names = stacked_names.Pop();
    Console.WriteLine($"{names}");
}    


Dictionary<string, int> Dict_Names = new Dictionary<string, int>();
foreach (string name in Names)
{
    Dict_Names.Add(name, name.Length);
}

foreach(var key in Dict_Names)
{
    Console.WriteLine($"Name: {key.Key}, Length: {key.Value}");
}