using static System.Runtime.InteropServices.JavaScript.JSType;

var result = 0;

var helpers = new Helpers.File();
//var data = helpers.Read("Data.txt");
var lines = helpers.ReadLines("Data.txt");

var visited = new List<(int, int)>();
var head = (0, 0);
var tail = (0, 0);
visited.Add(tail);

foreach (var line in lines)
{
    var heading = line.Split(" ").First();
    var steps = int.Parse(line.Split(" ").Last());
    for (int step = 0; step < steps; step++)
    {
        switch (heading)
        {
            case "U":
                head = (head.Item1, head.Item2 + 1);
                break;
            case "D":
                head = (head.Item1, head.Item2 - 1);
                break;
            case "R":
                head = (head.Item1 + 1, head.Item2);
                break;
            case "L":
                head = (head.Item1 - 1, head.Item2);
                break;
        }

        if (head.Item1 == tail.Item1 + 2)
        {
            if (head.Item2 != tail.Item2)
            {
                tail.Item2 = head.Item2;
            }
            tail.Item1 = tail.Item1 + 1;
        }
        if (head.Item1 == tail.Item1 - 2)
        {
            if (head.Item2 != tail.Item2)
            {
                tail.Item2 = head.Item2;
            }
            tail.Item1 = tail.Item1 - 1;
        }
        if (head.Item2 == tail.Item2 + 2)
        {
            if (head.Item1 != tail.Item1)
            {
                tail.Item1 = head.Item1;
            }
            tail.Item2 = tail.Item2 + 1;
        }
        if (head.Item2 == tail.Item2 - 2)
        {
            if (head.Item1 != tail.Item1)
            {
                tail.Item1 = head.Item1;
            }
            tail.Item2 = tail.Item2 - 1;
        }
        if (!visited.Contains(tail))
        {
            visited.Add(tail);
        }
    }
}

result = visited.Count();

Console.WriteLine($"Result part 1: {result}");

result = 0;

visited = new List<(int, int)>();
var ropes = new (int, int)[10];
for(var i = 0; i < ropes.Count(); i++)
{
    ropes[i] = (0, 0);
}
visited.Add(ropes[9]);

foreach (var line in lines)
{
    var heading = line.Split(" ").First();
    var steps = int.Parse(line.Split(" ").Last());
    for (int step = 0; step < steps; step++)
    {
        switch (heading)
        {
            case "U":
                ropes[0] = (ropes[0].Item1, ropes[0].Item2 + 1);
                break;
            case "D":
                ropes[0] = (ropes[0].Item1, ropes[0].Item2 - 1);
                break;
            case "R":
                ropes[0] = (ropes[0].Item1 + 1, ropes[0].Item2);
                break;
            case "L":
                ropes[0] = (ropes[0].Item1 - 1, ropes[0].Item2);
                break;
        }

        for (var i = 1; i < ropes.Count(); i++)
        {
            if (ropes[i - 1].Item1 == ropes[i].Item1 + 2)
            {
                if (ropes[i - 1].Item2 > ropes[i].Item2)
                {
                    ropes[i].Item2 = ropes[i].Item2 + 1;
                }
                if (ropes[i - 1].Item2 < ropes[i].Item2)
                {
                    ropes[i].Item2 = ropes[i].Item2 - 1;
                }
                ropes[i].Item1 = ropes[i].Item1 + 1;
            }
            if (ropes[i - 1].Item1 == ropes[i].Item1 - 2)
            {
                if (ropes[i - 1].Item2 > ropes[i].Item2)
                {
                    ropes[i].Item2 = ropes[i].Item2 + 1;
                }
                if (ropes[i - 1].Item2 < ropes[i].Item2)
                {
                    ropes[i].Item2 = ropes[i].Item2 - 1;
                }
                ropes[i].Item1 = ropes[i].Item1 - 1;
            }
            if (ropes[i - 1].Item2 == ropes[i].Item2 + 2)
            {
                if (ropes[i - 1].Item1 > ropes[i].Item1)
                {
                    ropes[i].Item1 = ropes[i].Item1 + 1;
                }
                if (ropes[i - 1].Item1 < ropes[i].Item1)
                {
                    ropes[i].Item1 = ropes[i].Item1 - 1;
                }
                ropes[i].Item2 = ropes[i].Item2 + 1;
            }
            if (ropes[i - 1].Item2 == ropes[i].Item2 - 2)
            {
                if (ropes[i - 1].Item1 > ropes[i].Item1)
                {
                    ropes[i].Item1 = ropes[i].Item1 + 1;
                }
                if (ropes[i - 1].Item1 < ropes[i].Item1)
                {
                    ropes[i].Item1 = ropes[i].Item1 - 1;
                }
                ropes[i].Item2 = ropes[i].Item2 - 1;
            }
        }
        if (!visited.Contains(ropes[9]))
        {
            visited.Add(ropes[9]);
        }
    }
}

result = visited.Count();


Console.WriteLine($"Result part 2: {result}");