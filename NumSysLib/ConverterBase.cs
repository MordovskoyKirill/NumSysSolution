namespace NumSysLib;
 /*abstract internal*/public class ConverterBase {
    /* internal protected */public string ToBase10(string digitTo, int fromBase)
    {
        int rangeInt = digitTo.Length;
        long[] l = new long[rangeInt];
        string hexChars = "0123456789ABCDEF";

        for (int i = 0; i < rangeInt; i++)
        {
            char currentChar = char.ToUpper(digitTo[rangeInt - 1 - i]);
            long a = hexChars.IndexOf(currentChar);
            l[i] = a * (long)Math.Pow(fromBase, i);
        }
        long decimalValue = l.Sum();
        return Convert.ToString(decimalValue);
    }
    /* internal protected */ public string FromBase10(string digitFrom, int toBase)
    {
        long currentDigit = Convert.ToInt64(digitFrom);
        List<long> l = new List<long>();
        
        while (currentDigit > 0)
        {
            long newDigit = currentDigit % toBase;
            l.Add(newDigit);
            currentDigit /= toBase;
        }
        l.Reverse();

        const string hexChars = "0123456789ABCDEF";
        string newValue = "";

        foreach (long digit in l)
        {
            newValue += hexChars[(int)digit];
        }
        return newValue;
    }
}