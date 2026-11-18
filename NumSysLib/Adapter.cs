namespace NumSysLib;

public class Adapter
{
    private string value = "0";
    private int fromBase = 10;
    private int toBase = 2;

    public string Value
    {
        get { return value; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Введите число");

            string text = value.ToUpperInvariant();
            string digits = text;

            if (digits[0] == '-' || digits[0] == '+')
                digits = digits.Substring(1);

            if (digits.Length == 0)
                throw new ArgumentException("Введите число после знака");

            if (FromBase == 2)
                new Binary().CheckValue = text;

            else if (FromBase == 8)
                new Oct().CheckValue = text;

            else if (FromBase == 16)
                new Hex().CheckValue = text;

            else
            {
                string symbols = "0123456789ABCDEF";

                foreach (char c in digits)
                {
                    int digit = symbols.IndexOf(c);

                    if (digit == -1 || digit >= FromBase)
                        throw new ArgumentException("Ошибка ввода числа");
                }
            }

            this.value = text;
        }
    }
    public int FromBase
    {
        get { return fromBase; }
        set
        {
            ConverterBase.CheckBase(value);
            fromBase = value;
        }
    }

    public int ToBase
    {
        get { return toBase; }
        set
        {
            ConverterBase.CheckBase(value);
            toBase = value;
        }
    }

    public string Convert(string value, int fromBase, int toBase)
    {
        FromBase = fromBase;
        ToBase = toBase;
        Value = value;

        ConverterBase converter;

        switch (FromBase)
        {
            case 2:
                converter = new Binary();
                break;

            case 8:
                converter = new Oct();
                break;

            case 16:
                converter = new Hex();
                break;

            default:
                return ConverterBase.ConvertNumber(Value, FromBase, ToBase);
        }

        return converter.Convert(Value, ToBase);
    }
}