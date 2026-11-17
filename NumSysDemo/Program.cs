using NumSysLib;

Adapter adapter = new Adapter();

Console.WriteLine(adapter.Convert("1010", 2, 10));
Console.WriteLine(adapter.Convert("10", 10, 2));
Console.WriteLine(adapter.Convert("77", 8, 10));
Console.WriteLine(adapter.Convert("63", 10, 8));
Console.WriteLine(adapter.Convert("FF", 16, 10));
Console.WriteLine(adapter.Convert("255", 10, 16));
Console.WriteLine(adapter.Convert("11111111", 2, 16));
Console.WriteLine(adapter.Convert("FF", 16, 2));