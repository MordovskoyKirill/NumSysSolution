
namespace NumSysLib;

internal abstract class ConverterBase
{
    protected int BaseSystem;

    protected ConverterBase(int baseSystem)
    {
        BaseSystem = baseSystem;
    }

    internal abstract string Number { get; set; }
    internal string Convert(string value, int toBase)
    {
        return ConvertNumber(value, BaseSystem, toBase);
    }

    internal static void CheckBase(int numberBase)
    {
        if (numberBase < 2 || numberBase > 16)
            throw new ArgumentException("Основание должно быть от 2 до 16");
    }


    internal static string ConvertNumber(string value, int fromBase, int toBase)
    {
        bool negative = value[0] == '-';

        if (value[0] == '-' || value[0] == '+')
            value = value.Substring(1);

        string symbols = "0123456789ABCDEF";

        List<int> digits = new List<int>();

        foreach (char c in value)
            digits.Add(symbols.IndexOf(c));

        string result = "";

        while (digits.Count > 0)
        {
            List<int> quotient = new List<int>();
            int remainder = 0;

            foreach (int digit in digits)
            {
                int current = remainder * fromBase + digit;

                int part = current / toBase;
                remainder = current % toBase;

                if (quotient.Count > 0 || part != 0)
                    quotient.Add(part);
            }

            result = symbols[remainder] + result;
            digits = quotient;
        }

        if (result == "")
            result = "0";

        if (negative && result != "0")
            result = "-" + result;

        return result;
    }
}
