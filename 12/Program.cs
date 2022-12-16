using _12;
using System.Diagnostics.CodeAnalysis;

var result = int.MaxValue;

var helpers = new Helpers.File();
//var data = helpers.Read("Data.txt");
var lines = helpers.ReadLines("Data.txt");

var map = new char[lines.Count(), lines[0].Length];

var lineNumber = 0;
var columnNumber = 0;
var start = (0, 0);
var end = (0, 0);
var aList = new List<(int, int)>();
foreach (var line in lines)
{
    columnNumber = 0;
    foreach (var c in line)
    {
        if (c == 'a')
        {
            if (columnNumber == 0)
            {
                aList.Add((lineNumber, columnNumber));
            }
        }
        if (c == 'S')
        {
            start = (lineNumber, columnNumber);
            aList.Add((lineNumber, columnNumber));
        }
        if (c == 'E')
        {
            end = (lineNumber, columnNumber);
        }
        map[lineNumber, columnNumber] = c;
        columnNumber += 1;
    }
    lineNumber += 1;
}

var ways = new List<Way>();
var oriWay = new Way();
oriWay.SetMap(map);
oriWay.Path.Add(start);
ways.Add(oriWay);

while (!ways.All(w => w.Stopped))
{
    var newWays = new List<Way>();
    foreach (var way in ways)
    {
        var moreWays = way.Move();
        newWays.AddRange(moreWays);
    }

    foreach (var newWay in newWays)
    {
        var found = false;
        foreach (var testWay in ways)
        {
            if (testWay.Path.Contains(newWay.Path.Last()))
            {
                found = true;
            }
        }
        if (!found)
        {
            ways.Add(newWay);
        }
    }
}

foreach (var way in ways)
{
    if (map[way.Path.Last().Item1, way.Path.Last().Item2] == 'E')
    {
        if (way.Path.Count() < result)
        {
            result = way.Path.Count() - 1;
        }
    }
}
Console.WriteLine($"Result part 1: {result}");

result = int.MaxValue;

var index = 0;
foreach (var aPos in aList)
{
    index++;
    ways = new List<Way>();
    oriWay = new Way();
    oriWay.SetMap(map);
    oriWay.Path.Add(aPos);
    oriWay.Part2 = true;
    ways.Add(oriWay);

    while (!ways.All(w => w.Stopped))
    {
        var newWays = new List<Way>();
        foreach (var way in ways)
        {
            var moreWays = way.Move();
            newWays.AddRange(moreWays);
        }

        foreach (var newWay in newWays)
        {
            var found = false;
            foreach (var testWay in ways)
            {
                if (testWay.Path.Contains(newWay.Path.Last()))
                {
                    found = true;
                }
            }
            if (!found)
            {
                ways.Add(newWay);
            }
        }
    }

    foreach (var way in ways)
    {
        if (map[way.Path.Last().Item1, way.Path.Last().Item2] == 'E')
        {
            if (way.Path.Count() < result)
            {
                result = way.Path.Count() - 1;
            }
        }
    }
}
    
Console.WriteLine($"Result part 2: {result}");


