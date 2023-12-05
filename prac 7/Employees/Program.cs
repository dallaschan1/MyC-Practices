using System;
using System.Collections.Generic;


public abstract class Employee
{
    protected int id;
    protected string name;

    public Employee(int id, string name)
    {
        this.id = id;
        this.name = name;
    }

    public abstract double CalculatePay();

    public override string ToString()
    {
        return $"ID: {id}, Name: {name}";
    }
}

public class FullTimeEmployee : Employee
{
    private double basicPay;
    private double allowance;

    public FullTimeEmployee(int id, string name, double basicPay, double allowance) : base(id, name)
    {
        this.basicPay = basicPay;
        this.allowance = allowance;
    }

    public override double CalculatePay()
    {
        return basicPay + allowance;
    }

    public override string ToString()
    {
        return base.ToString() + $", Basic Pay: {basicPay}, Allowance: {allowance}";
    }
}
public class PartTimeEmployee : Employee
{
    private double dailyRate;
    private int daysWorked;

    public PartTimeEmployee(int id, string name, double dailyRate, int daysWorked) : base(id, name)
    {
        this.dailyRate = dailyRate;
        this.daysWorked = daysWorked;
    }

    public override double CalculatePay()
    {
        return dailyRate * daysWorked;
    }

    public override string ToString()
    {
        return base.ToString() + $", Daily Rate: {dailyRate}, Days Worked: {daysWorked}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();
        InitEmployees(employees);

        while (true)
        {
            Console.WriteLine("\n1. List all employees\n2. Calculate and display pay for all employees\n3. Exit");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ListEmployees(employees);
                    break;
                case 2:
                    DisplayPay(employees);
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void InitEmployees(List<Employee> employees)
    {
        employees.Add(new FullTimeEmployee(1, "John Doe", 3000, 500));
        employees.Add(new PartTimeEmployee(2, "Jane Smith", 100, 15));
    }

    static void ListEmployees(List<Employee> employees)
    {
        foreach (var employee in employees)
        {
            Console.WriteLine(employee);
        }
    }

    static void DisplayPay(List<Employee> employees)
    {
        foreach (var employee in employees)
        {
            Console.WriteLine($"{employee}: Pay = {employee.CalculatePay():C2}");
        }
    }
}


