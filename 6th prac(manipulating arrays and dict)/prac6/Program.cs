internal class Program
{
    private static void Main(string[] args)
    {
        int[] num = {4, 2, 2, 8, 5, 4, 8, 1};
        SortedList<int, int> Numbers = new SortedList<int, int>();
        foreach (int nu in num)
        {
            if (Numbers.ContainsKey(nu) == false)
            {
                Numbers.Add(nu, 1);
            }
            else
            {
                Numbers[nu] += 1;
            }
        }

        foreach (var kvp in Numbers)
        {
            Console.WriteLine($"Number: {kvp.Key} Occurances: {kvp.Value}");
        }

    }
}

