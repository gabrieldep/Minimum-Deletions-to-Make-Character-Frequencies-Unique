public class Problem
{
    public static void Main()
    {
        string s = "ceabaacb";
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

        for (int i = 0; i < buff.Count; i++)
        {
            for (int j = 0; j < buff.Count; j++)
            {
                if (buff[i].Quantidade == buff[j].Quantidade && buff[i].Quantidade != 0 && i != j)
                {
                    buff[j].Quantidade--;
                    sumReturn++;
                }
            }
        }
        Console.WriteLine(sumReturn);
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