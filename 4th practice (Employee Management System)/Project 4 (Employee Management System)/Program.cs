/* 
Advanced C# Programming Challenge: Employee Management System
Scenario:
You are tasked with developing a part of an employee management system for a small company. The system should perform
various operations related to employee data handling and reporting.

Task 1: Employee Class Creation
Create an Employee class with the following properties: ID (int), Name (string), Department (string), Position (string), and Salary (decimal).
Include a constructor that initializes all the properties.
Implement a method RaiseSalary(decimal percentage) which increases the employee's salary by the given percentage.
Task 2: Managing Employee Data
Create a List<Employee> to represent the company's employees.
Add at least 5 Employee objects to this list with different details.
Implement a method to print all employee details in a formatted manner.
Task 3: Data Manipulation and Reporting
Implement functionality to find and display the details of the highest-paid employee.
Write code to display all employees in a specific department.
Implement a method to calculate and display the average salary of the employees.
Task 4: Advanced Features
Introduce error handling to manage scenarios such as invalid salary percentages or department names.
Implement a sorting feature to display employees sorted by their salaries in descending order.
Task 5: File I/O Extension
Write a method to save all employee details into a file named "employees.txt".
Implement a method to read employee details from "employees.txt" and populate the List<Employee>.
Task 6: String Manipulation and Output Formatting
Ensure all employee names are stored in the format "Lastname, Firstname".
When displaying employee details, format the output to align the details in columns neatly.
This task is designed to test your skills in class creation, collection management, basic algorithms,
file I/O, error handling, string manipulation, and output formatting in C#. Feel free to ask for hints or
clarifications as needed. Once you have implemented this, we can review it together, and I can provide feedback or 
further challenges based on your performance. Good luck!

 
*/

class Program
{
    public static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();
        Employee one = new Employee(1, "1", "1", "1", 10M);
        employees.Add(one);
        Employee two = new Employee(2, "2", "2", "2", 20M);
        employees.Add(two);
        Employee three = new Employee(3, "3", "3", "3", 30M);
        employees.Add(three);
        Employee four = new Employee(4, "4", "4", "4", 40M);
        employees.Add(four);
        Employee five = new Employee(5, "5", "5", "5", 50M);
        employees.Add(five);

        Console.WriteLine("Employee Details:");
        Console.WriteLine();
        Console.WriteLine("-----------------");
        Console.WriteLine();
        foreach (Employee es in employees)
        {
            Console.WriteLine(es.ToString());
            Console.WriteLine();
        }

        decimal initial = one.Salary;
        int identifier = 0;
        foreach (Employee es in employees)
        {
            if (es.Salary > initial)
            {
                initial = es.Salary;
                identifier = employees.IndexOf(es);
            }
        }
        Console.WriteLine(employees[identifier].ToString());


        using (StreamWriter sw = new StreamWriter("employees.txt"))
        {
            foreach (Employee es in employees)
            {
                sw.WriteLine(es.ToString());
                sw.WriteLine();
            }
        }

        using (StreamReader sr = new StreamReader("employees.txt"))
        {
            string? s;
            while ((s = sr.ReadLine()) != null) 
            { 
                Console.WriteLine(s);
            }
        }
    }

}

class Employee
{
    private int iD;
    private string name;
    private string department;
    private string position;
    private decimal salary;

    public int ID
    {
        get { return iD;}
        set { iD = value;}
    } 

    public string Name
    {
        get { return name;  }
        set { name = value; }
    }

    public string Department 
    {
        get { return department; }
        set { department = value; }
    }
    public string Position
    {
        get { return position; }
        set { position = value; }
    }
    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }


    public Employee(int ID, string Name, string Department, string Position, decimal Salary) 
    { 
        this.iD = ID;
        this.name = Name;
        this.department = Department;
        this.position = Position;
        this.salary = Salary;
    }

    public void RaiseSalary(decimal percentage)
    {
        salary = salary * (percentage / 100 + 1);
    }

    public override string ToString()
    {
        return $"ID: {ID}, Name: {Name}, Department: {Department}, Position:{Position}, Salary:${Salary}";
    }
}