namespace NumSysLib;

/// <summary>
/// Класс для перевода чисел между системами счисления
/// </summary>
public class Adapter
{
    private string value = "0";
    private int fromBase = 10;
    private int toBase = 2;

    /// <summary>
    /// Число, которое необходимо перевести
    /// </summary>
    public string Value
    {
        get { return value; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Введите число");

            string text = value.ToUpperInvariant();

            if (FromBase == 2)
                new Binary().Number = text;

            else if (FromBase == 8)
                new Oct().Number = text;

            else if (FromBase == 16)
                new Hex().Number = text;

            this.value = text;
        }
    }

    /// <summary>
    /// Основание исходной системы счисления
    /// </summary>
    public int FromBase
    {
        get { return fromBase; }
        set
        {
            ConverterBase.CheckBase(value);
            fromBase = value;
        }
    }

    /// <summary>
    /// Основание системы счисления
    /// </summary>
    public int ToBase
    {
        get { return toBase; }
        set
        {
            ConverterBase.CheckBase(value);
            toBase = value;
        }
    }

    /// <summary>
    /// Конвертирует систему счисления
    /// </summary>
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