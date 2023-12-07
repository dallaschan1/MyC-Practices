class Program
{ 
    private static List<Phone> phonelist = new List<Phone>();

    public static void Main(String[] args)
    {
        InitialisePhones();
        while (true)
        {
            DisplayOutput();
            UpdateUsage();
        }

    }

    public static void InitialisePhones()
    {
        string file = "PhoneDetails.csv";
        using (StreamReader sr = new StreamReader(file)) 
        {
            string s = sr.ReadLine();

            while ((s = sr.ReadLine()) != null)
            {
                string PhoneNum = s.Split(',')[0];
                int usage = Int32.Parse(s.Split(',')[1]);
                string PlanType = s.Split(",")[2];

                Phone phonesdetail = new Phone(PhoneNum, usage, PlanType);
                phonelist.Add(phonesdetail);
            }
        }
    
    }

    public static void DisplayOutput()
    {
        Console.WriteLine("PhoneNo   Usage   PlanType   PhoneCharge($)");
        foreach (Phone phone in phonelist) 
        {
            Console.WriteLine($"{phone.PhoneNum,-10}{phone.Usage,-8}{phone.PlanType,-11}{phone.CalculateCharge(phone.Usage, phone.PlanType),13:N2}");

        }
    }

    public static void UpdateUsage()
    {
        Console.WriteLine();
        Console.WriteLine("Update Phone Usage");
        Console.WriteLine("------------------");
        Console.Write("Enter phone no: ");
        string number = Console.ReadLine();
        foreach (Phone phones in phonelist)
        {
            if (number == phones.PhoneNum)
            {
                Console.WriteLine($"Current usage: {phones.Usage}");
                Console.Write("Enter new Usage: ");
                int use = int.Parse(Console.ReadLine());
                phones.Usage = use;
                Console.WriteLine("The new usage is updated successfully");
                Console.WriteLine();
                DisplayOutput();
                Console.WriteLine();
                break;
            }
            else
            {
                Console.WriteLine("Phone not found!");
                Console.WriteLine();
                break;

            }
        }

    }
}






class Phone
{
    private string phoneNum;
    private int usage;
    private string planType;

    public string PhoneNum
    {
        get { return phoneNum; }
        set { phoneNum = value; }
    }

    public int Usage
    {
        get { return usage; }
        set { usage = value; }
    }

    public string PlanType
    {
        get { return planType; }
        set { planType = value; }
    }

    public double CalculateCharge(int Use, string Plan)
    {
        if (Plan == "A")
        {
            return 0.5 * Use / 100;
        }
        else if (Plan == "B")
        {
            Use -= 1000;
            if (Use > 0)
            {
                return Use * 0.2 / 100;
            }
        }

        else
        {
            Use -= 5000;
            if (Use > 0)
            {
                return Use * 0.1 / 100;
            }
        }

        return 0;

    }

    public Phone(string PhoneNum, int Usage, string PlanType)
    {
        this.PhoneNum = PhoneNum;
        this.Usage = Usage;
        this.PlanType = PlanType;
    }

    public override string ToString()
    {
        return null;
    }
}

