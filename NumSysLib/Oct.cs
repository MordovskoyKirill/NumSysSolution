namespace NumSysLib;

internal class Oct : ConverterBase
{
    private string number = "0";

    public Oct() : base(8)
    {
    }

    internal override string Number
    {
        get { return number; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Введите число");

            string original = value;

            if (value[0] == '-')
                value = value.Substring(1);

            foreach (char c in value)
            {
                if (c < '0' || c > '7')
                    throw new ArgumentException("Неверное восьмеричное число");
            }

            number = original;
        }
    }
}