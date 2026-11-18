namespace NumSysLib;

internal class Binary : ConverterBase
{
    private string number = "0";

    public Binary() : base(2)
    {
    }

    internal override string CheckValue
    {
        get { return number; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Введите число");

            string original = value;

            if (value[0] == '-')
                value = value.Substring(1);

            if (value.Length == 0)
                throw new ArgumentException("Введите число после знака");

            foreach (char c in value)
            {
                if (c != '0' && c != '1')
                    throw new ArgumentException("Неверное двоичное число");
            }

            number = original;
        }
    }
}