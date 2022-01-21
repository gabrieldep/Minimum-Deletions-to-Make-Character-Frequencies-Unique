public class Problem
{
    public static void Main()
    {
        Console.WriteLine("Write a word:");
        string s = Console.ReadLine().ToLower();
        List<BuffItem> buff = new();
        buff.Add(new BuffItem(1, s.First()));
        for (int i = 1; i < s.Length; i++)
        {
            bool isInBuff = false;
            for (int j = 0; j < buff.Count; j++)
            {
                if (buff[j].Caractere == s[i])
                {
                    isInBuff = true;
                    buff[j].Quantidade++;
                }
            }
            if (!isInBuff)
            {
                buff.Add(new BuffItem(1, s[i]));
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
            else if(buff[i].Quantidade == 0)
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