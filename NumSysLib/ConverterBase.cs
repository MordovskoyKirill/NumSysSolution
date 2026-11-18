
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

        int start = 0;

        if (value[0] == '-' || value[0] == '+')
            start = 1;

        if (start == value.Length)
            throw new ArgumentException("Введите число после знака");

        string digits = "0123456789ABCDEF";

        for (int i = start; i < value.Length; i++)
        {
            int digit = digits.IndexOf(value[i]);

            if (digit == -1 || digit >= numberBase)
                throw new ArgumentException("Ошибка ввода данных, проверьте число");
        }

        return value;
    }

    internal static string ConvertNumber(string value, int fromBase, int toBase)
    {
        value = CheckValue(value, fromBase);
        CheckBase(toBase);

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
