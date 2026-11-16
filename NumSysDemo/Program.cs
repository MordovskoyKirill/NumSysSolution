using NumSysLib;

var converterBinary = new Binary();
var converterOct = new Oct();
var converterHex = new Hex();
Console.WriteLine(converterBinary.ConvertTo10("1100"));
Console.WriteLine(converterBinary.ConvertFrom10("12"));
Console.WriteLine(converterOct.ConvertTo10("1100"));
Console.WriteLine(converterOct.ConvertFrom10("576"));
Console.WriteLine(converterHex.ConvertTo10("1a"));
Console.WriteLine(converterHex.ConvertFrom10("26"));