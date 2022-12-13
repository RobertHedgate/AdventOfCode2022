var result = "";

var helpers = new Helpers.File();
//var data = helpers.Read("Data.txt");
var lines = helpers.ReadLines("Data.txt");

var stacks = new string[9] { "", "", "", "", "", "","","","" };
foreach (var line in lines)
{
    if (line.First() == ' ')
    {
        break;
    }

    try
    {
        var stack = line[1];
        if (stack != ' ')
        {
            stacks[0] = stacks[0].Insert(0, stack.ToString());
        }

        stack = line[5];
        if (stack != ' ')
        {
            stacks[1] = stacks[1].Insert(0, stack.ToString());
        }

        stack = line[9];
        if (stack != ' ')
        {
            stacks[2] = stacks[2].Insert(0, stack.ToString());
        }

        stack = line[13];
        if (stack != ' ')
        {
            stacks[3] = stacks[3].Insert(0, stack.ToString());
        }

        stack = line[17];
        if (stack != ' ')
        {
            stacks[4] = stacks[4].Insert(0, stack.ToString());
        }

        stack = line[21];
        if (stack != ' ')
        {
            stacks[5] = stacks[5].Insert(0, stack.ToString());
        }

        stack = line[25];
        if (stack != ' ')
        {
            stacks[6] = stacks[6].Insert(0, stack.ToString());
        }

        stack = line[29];
        if (stack != ' ')
        {
            stacks[7] = stacks[7].Insert(0, stack.ToString());
        }

        stack = line[33];
        if (stack != ' ')
        {
            stacks[8] = stacks[8].Insert(0, stack.ToString());
        }


    }
    catch { }
}

foreach (var line in lines)
{
    if (line.StartsWith("move"))
    {
        var splitLine = line.Split(' ');
        var move = int.Parse(splitLine[1]);
        var from = int.Parse(splitLine[3]);
        var to = int.Parse(splitLine[5]);

        for (int i = 0; i < move; i++)
        {
            var c = stacks[from - 1].Last();
            stacks[from - 1] = stacks[from - 1].Remove(stacks[from - 1].Length - 1);
            stacks[to - 1] += c;
        }
    }
}

foreach (var stack in stacks)
{
    result += stack.Last();
}
Console.WriteLine($"Result part 1: {result}");

result = "";

stacks = new string[9] { "", "", "", "", "", "", "", "", "" };
foreach (var line in lines)
{
    if (line.First() == ' ')
    {
        break;
    }

    try
    {
        var stack = line[1];
        if (stack != ' ')
        {
            stacks[0] = stacks[0].Insert(0, stack.ToString());
        }

        stack = line[5];
        if (stack != ' ')
        {
            stacks[1] = stacks[1].Insert(0, stack.ToString());
        }

        stack = line[9];
        if (stack != ' ')
        {
            stacks[2] = stacks[2].Insert(0, stack.ToString());
        }

        stack = line[13];
        if (stack != ' ')
        {
            stacks[3] = stacks[3].Insert(0, stack.ToString());
        }

        stack = line[17];
        if (stack != ' ')
        {
            stacks[4] = stacks[4].Insert(0, stack.ToString());
        }

        stack = line[21];
        if (stack != ' ')
        {
            stacks[5] = stacks[5].Insert(0, stack.ToString());
        }

        stack = line[25];
        if (stack != ' ')
        {
            stacks[6] = stacks[6].Insert(0, stack.ToString());
        }

        stack = line[29];
        if (stack != ' ')
        {
            stacks[7] = stacks[7].Insert(0, stack.ToString());
        }

        stack = line[33];
        if (stack != ' ')
        {
            stacks[8] = stacks[8].Insert(0, stack.ToString());
        }


    }
    catch { }
}

foreach (var line in lines)
{
    if (line.StartsWith("move"))
    {
        var splitLine = line.Split(' ');
        var move = int.Parse(splitLine[1]);
        var from = int.Parse(splitLine[3]);
        var to = int.Parse(splitLine[5]);

        var s = stacks[from - 1].Substring(stacks[from - 1].Length - move);
        stacks[from - 1] = stacks[from - 1].Remove(stacks[from - 1].Length - move, move);
        stacks[to - 1] += s;
    }
}

foreach (var stack in stacks)
{
    result += stack.Last();
}

Console.WriteLine($"Result part 2: {result}");
