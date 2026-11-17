namespace NumSysLib;

internal abstract class ConverterBase
{
    protected int BaseSystem;

    protected ConverterBase(int baseSystem)
    {
        BaseSystem = baseSystem;
    }

    internal string Convert(string value, int toBase)
    {
        return ConvertNumber(value, BaseSystem, toBase);
    }

    internal static void CheckBase(int numberBase)
    {
        if (numberBase < 2 || numberBase > 16)
            throw new ArgumentException("Основание должно быть от 2 до 16");
    }

    internal static string CheckValue(string value, int numberBase)
    {
        CheckBase(numberBase);

        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Число не может быть пустым");

        value = value.ToUpperInvariant();

        string digits = "0123456789ABCDEF";

        foreach (char c in value)
        {
            int digit = digits.IndexOf(c);

            if (digit == -1 || digit >= numberBase)
                throw new ArgumentException("Ошибка ввода данных, проверьте число");
        }

        return value;
    }

    internal static string ConvertNumber(string value, int fromBase, int toBase)
    {
        value = CheckValue(value, fromBase);
        CheckBase(toBase);

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

        return result;
    }
}