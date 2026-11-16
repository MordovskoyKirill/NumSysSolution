using NumSysLib;

var converter = new ConverterBase();
Console.WriteLine(converter.ToBase10("101",2));
Console.WriteLine(converter.FromBase10("5",2));
Console.WriteLine(converter.FromBase10("-5",2));
