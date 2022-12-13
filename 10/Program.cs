using _10;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

var result = 0;

var e = new Extra();
var helpers = new Helpers.File();
//var data = helpers.Read("Data.txt");
var lines = helpers.ReadLines("Data.txt");

var cycle = 1;
var x = 1;

foreach (var line in lines)
{
    if (line.StartsWith("noop"))
    {
        cycle++;
        result = e.TestCycle(cycle, x, result);
    }
    else
    {
        cycle++;
        result = e.TestCycle(cycle, x, result);
        cycle++;
        x += int.Parse(line.Split(" ").Last());
        result = e.TestCycle(cycle, x, result);
    }
}

Console.WriteLine($"Result part 1: {result}");

result = 0;

cycle = 1;
var row = 0;
x = 1;
var pixels = new List<bool>();

foreach (var line in lines)
{
    if (line.StartsWith("noop"))
    {
        if (cycle - row * 40 - 1 >= x - 1 && cycle - row * 40 - 1 <= x + 1)
        {
            pixels.Add(true);
        }
        else
        {
            pixels.Add(false);
        }
        if (cycle % 40 == 0)
        {
            row++;
        }
        cycle++;
    }
    else
    {
        if (cycle - row * 40 - 1 >= x - 1 && cycle - row * 40 - 1 <= x + 1)
        {
            pixels.Add(true);
        }
        else
        {
            pixels.Add(false);
        }
        if (cycle % 40 == 0)
        {
            row++;
        }
        cycle++;
        if (cycle - row * 40 - 1 >= x - 1 && cycle - row * 40 - 1 <= x + 1)
        {
            pixels.Add(true);
        }
        else
        {
            pixels.Add(false);
        }
        if (cycle % 40 == 0)
        {
            row++;
        }
        cycle++;
        x += int.Parse(line.Split(" ").Last());
    }
}

Console.WriteLine($"Result part 2:");
var pixelLine = "";
var count = 0;
foreach (var pixel in pixels)
{
    if (pixel)
    {
        pixelLine += "#";
    }
    else
    {
        pixelLine += ".";
    }
    count++;
    if (count % 40 == 0)
    {
        Console.WriteLine(pixelLine);
        count = 0;
        pixelLine = "";
    }
    else
    {
    }
}
