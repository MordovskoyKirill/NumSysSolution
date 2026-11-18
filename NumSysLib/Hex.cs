namespace NumSysLib;

internal class Hex : ConverterBase
{
    private string number = "0";

    public Hex() : base(16)
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
                if ((c < '0' || c > '9') &&
                    (c < 'A' || c > 'F'))
                    throw new ArgumentException("Неверное шестнадцатеричное число");
            }

            number = original;
        }
    }
}