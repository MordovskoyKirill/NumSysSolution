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
            this.value = ConverterBase.CheckValue(value, FromBase);
        }
    }

    public int FromBase
    {
        get { return fromBase; }
        set
        {
            ConverterBase.CheckBase(value);
            ConverterBase.CheckValue(Value, value);
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