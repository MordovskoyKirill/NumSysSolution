namespace NumSysLib
{
    internal abstract class ConverterBase
    {
        protected string Value { get; set; }
        protected int FromBase { get; set; }

        protected ConverterBase(string value, int fromBase)
        {
            Value = value;
            FromBase = fromBase;
        }

        internal string Convert(string value, int fromBase, int toBase)
        {

        }
    }
}