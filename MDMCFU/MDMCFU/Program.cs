public class Problem
{
    public static void Main()
    {
        Console.WriteLine("Write a word:");
        string s = Console.ReadLine().ToLower();
        List<char> orderedWord = s.OrderBy(s => s).ToList();
        List<BufferItem> buffer = new();
        buffer.Add(new BufferItem(1, orderedWord.First()));
        int j = 0;
        for (int i = 1; i < s.Length; i++)
        {
            if (buffer[j].Caractere == orderedWord[i])
            {
                buffer[j].Quantidade++;
            }
            else
            {
                buffer.Add(new BufferItem(1, orderedWord[i]));
                j++;
            }
        }
        int sumReturn = 0;
        buffer = buffer.OrderByDescending(b => b.Quantidade).ToList();

        List<int> notAllowedNumber = new()
        {
            buffer.First().Quantidade
        };

        for (int i = 1; i < buffer.Count;)
        {
            if (notAllowedNumber.Contains(buffer[i].Quantidade))
            {
                sumReturn++;
                buffer[i].Quantidade--;
            }
            else if (buffer[i].Quantidade == 0)
            {
                i++;
            }
            else
            {
                notAllowedNumber.Add(buffer[i].Quantidade);
                i++;
            }
        }
        Console.WriteLine($"\nMinimum deletions to make character frequencies unique is {sumReturn}");
    }
}

public class BufferItem
{
    public BufferItem(int i, char s)
    {
        Quantidade = i;
        Caractere = s;
    }
    public int Quantidade { get; set; }
    public char Caractere { get; set; }
}