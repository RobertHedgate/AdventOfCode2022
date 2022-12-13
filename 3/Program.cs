var result = 0;

var helpers = new Helpers.File();
//var data = helpers.Read("Data.txt");
var lines = helpers.ReadLines("Data.txt");

foreach (var line in lines)
{
    var length = line.Length;
    var first = line.Take(length / 2);
    var second = line.Take(new Range(length / 2, length));

    foreach (var c in first)
    {
        if (second.Contains(c))
        {
            result += ValueOfChar(c);
            break;
        }
    }
}

Console.WriteLine($"Result part 1: {result}");

result = 0;

for (var i = 0; i < lines.Length; i++)
{
    var line1 = lines[i];
    var line2 = lines[i + 1];
    var line3 = lines[i + 2];
    i = i + 2;

    foreach (var c in line1)
    {
        if (line2.Contains(c) && line3.Contains(c)) 
        {
            result += ValueOfChar(c);
            break;
        }
    }
}



Console.WriteLine($"Result part 2: {result}");

int ValueOfChar(char c)
{
    int modifier = 0;
    if (c == Char.ToUpper(c))
    {
        modifier = 26;
    }
    int index = (int)c % 32;

    return index + modifier;
}