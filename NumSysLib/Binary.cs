namespace NumSysLib;
/*internal*/ public class Binary : ConverterBase
{
    private string _digitTo = string.Empty;
    private readonly int _baseSystem = 2;

    internal string DigitTo
    {
        get => _digitTo;
        set
        {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Ошибка ввода данных, проверьте вводимые данные.");
                }

                foreach (char c in value)
                {
                    if (c != '0' && c != '1')
                    {
                        throw new ArgumentException("Ошибка ввода данных, проверьте вводимые данные.");
                    }
                }
                _digitTo = value;
        }
    }
    /*internal*/public string ConvertTo10(string value)
    {
        DigitTo = value;
        return ToBase10(DigitTo, _baseSystem);
    }
    /*internal*/public string ConvertFrom10(string decimalValue)
    {
        return FromBase10(decimalValue, _baseSystem);
    }
}
