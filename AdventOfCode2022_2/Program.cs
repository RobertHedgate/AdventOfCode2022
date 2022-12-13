var result = 0;

var helpers = new Helpers.File();
//var data = helpers.Read("Data.txt");
var lines = helpers.ReadLines("Data.txt");

foreach (var line in lines)
{
    var opponent = line[0];
    var me = line[2];

    if (me == 'X')
    {
        result += 1;
        if (opponent == 'A')
        {
            result += 3;
        }
        if (opponent == 'B')
        {
            result += 0;
        }
        if (opponent == 'C')
        {
            result += 6;
        }
    }
    if (me == 'Y')
    {
        result += 2;
        if (opponent == 'A')
        {
            result += 6;
        }
        if (opponent == 'B')
        {
            result += 3;
        }
        if (opponent == 'C')
        {
            result += 0;
        }
    }
    if (me == 'Z')
    {
        result += 3;
        if (opponent == 'A')
        {
            result += 0;
        }
        if (opponent == 'B')
        {
            result += 6;
        }
        if (opponent == 'C')
        {
            result += 3;
        }
    }

}

Console.WriteLine($"Result part 1: {result}");

result = 0;
foreach (var line in lines)
{
    var opponent = line[0];
    var outcome = line[2];

    var me = 'X';
    if (outcome == 'X')
    {
        if (opponent == 'A')
        {
            me = 'Z';
        }
        if (opponent == 'B')
        {
            me = 'X';
        }
        if (opponent == 'C')
        {
            me = 'Y';
        }
    }
    if (outcome == 'Y')
    {
        if (opponent == 'A')
        {
            me = 'X';
        }
        if (opponent == 'B')
        {
            me = 'Y';
        }
        if (opponent == 'C')
        {
            me = 'Z';
        }
    }
    if (outcome == 'Z')
    {
        if (opponent == 'A')
        {
            me = 'Y';
        }
        if (opponent == 'B')
        {
            me = 'Z';
        }
        if (opponent == 'C')
        {
            me = 'X';
        }
    }

    if (me == 'X')
    {
        result += 1;
        if (opponent == 'A')
        {
            result += 3;
        }
        if (opponent == 'B')
        {
            result += 0;
        }
        if (opponent == 'C')
        {
            result += 6;
        }
    }
    if (me == 'Y')
    {
        result += 2;
        if (opponent == 'A')
        {
            result += 6;
        }
        if (opponent == 'B')
        {
            result += 3;
        }
        if (opponent == 'C')
        {
            result += 0;
        }
    }
    if (me == 'Z')
    {
        result += 3;
        if (opponent == 'A')
        {
            result += 0;
        }
        if (opponent == 'B')
        {
            result += 6;
        }
        if (opponent == 'C')
        {
            result += 3;
        }
    }

}

Console.WriteLine($"Result part 2: {result}");
