var result = 0;

var helpers = new Helpers.File();
//var data = helpers.Read("Data.txt");
var lines = helpers.ReadLines("Data.txt");

int newElf = 0;
foreach (var line in lines)
{
    if (string.IsNullOrEmpty(line))
    {
        if (newElf > result)
        {
            result = newElf;
        }
        newElf = 0;
        continue;
    }
    if (int.TryParse(line, out int value))
    {
        newElf += value;
    }
}
Console.WriteLine($"Result part 1: {result}");

result = 0;
newElf = 0;
var elfs = new List<int>();
foreach (var line in lines)
{
    if (string.IsNullOrEmpty(line))
    {
        elfs.Add(newElf);
        newElf = 0;
        continue;
    }
    if (int.TryParse(line, out int value))
    {
        newElf += value;
    }
}

result = elfs.OrderDescending().Select(i => i).Take(3).Sum();

Console.WriteLine($"Result part 2: {result}");
