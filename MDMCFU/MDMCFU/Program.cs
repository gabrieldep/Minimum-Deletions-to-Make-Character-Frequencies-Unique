public class Problem
{
    public static void Main()
    {
        Console.WriteLine("Write a word:");
        string s = Console.ReadLine().ToLower();
        List<char> orderedWord = s.OrderBy(s => s).ToList();
        List<BuffItem> buff = new();
        buff.Add(new BuffItem(1, orderedWord.First()));
        int j = 0;
        for (int i = 1; i < s.Length; i++)
        {
            if (buff[j].Caractere == orderedWord[i])
            {
                buff[j].Quantidade++;
            }
            else
            {
                buff.Add(new BuffItem(1, orderedWord[i]));
                j++;
            }
        }
        int sumReturn = 0;
        buff = buff.OrderByDescending(b => b.Quantidade).ToList();

        List<int> notAllowedNumber = new()
        {
            buff.First().Quantidade
        };

        for (int i = 1; i < buff.Count;)
        {
            if (notAllowedNumber.Contains(buff[i].Quantidade))
            {
                sumReturn++;
                buff[i].Quantidade--;
            }
            else if (buff[i].Quantidade == 0)
            {
                i++;
            }
            else
            {
                notAllowedNumber.Add(buff[i].Quantidade);
                i++;
            }
        }
        Console.WriteLine($"\nMinimum deletions to make character frequencies unique is {sumReturn}");
    }
}

public class BuffItem
{
    public BuffItem(int i, char s)
    {
        Quantidade = i;
        Caractere = s;
    }
    public int Quantidade { get; set; }
    public char Caractere { get; set; }
}