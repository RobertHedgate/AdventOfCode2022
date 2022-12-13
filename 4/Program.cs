var result = 0;

var helpers = new Helpers.File();
//var data = helpers.Read("Data.txt");
var lines = helpers.ReadLines("Data.txt");

foreach (var line in lines)
{
    var first = line.Split(',').First();
    var second = line.Split(',').Last();
    var first1 = first.Split('-').First();
    var first2 = first.Split('-').Last();
    var second1 = second.Split('-').First();
    var second2 = second.Split('-').Last();
    var firstInt1 = int.Parse(first1);
    var firstInt2 = int.Parse(first2);
    var secondInt1 = int.Parse(second1);
    var secondInt2 = int.Parse(second2);

    if ((firstInt1 >= secondInt1 && firstInt2 <= secondInt2)
        || (secondInt1 >= firstInt1 && secondInt2 <= firstInt2))
    {
        result++;
    }
}

Console.WriteLine($"Result part 1: {result}");

result = 0;

foreach (var line in lines)
{
    var first = line.Split(',').First();
    var second = line.Split(',').Last();
    var first1 = first.Split('-').First();
    var first2 = first.Split('-').Last();
    var second1 = second.Split('-').First();
    var second2 = second.Split('-').Last();
    var firstInt1 = int.Parse(first1);
    var firstInt2 = int.Parse(first2);
    var secondInt1 = int.Parse(second1);
    var secondInt2 = int.Parse(second2);

   if ((firstInt2 >= secondInt1 && firstInt2 <= secondInt2)
        || (firstInt1 >= secondInt1 && firstInt1 <= secondInt2)
        || (secondInt1 >= firstInt1 && secondInt1 <= firstInt2)
        || (secondInt2 >= firstInt1 && secondInt2 <= firstInt2)
        )
    {
        result++;
    }
}

Console.WriteLine($"Result part 2: {result}");
