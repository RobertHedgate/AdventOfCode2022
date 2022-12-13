var result = 0;

var helpers = new Helpers.File();
//var data = helpers.Read("Data.txt");
var lines = helpers.ReadLines("Data.txt");

var line = lines.FirstOrDefault();

var marker = "";
foreach (var c in line)
{
    marker += c;
    result += 1;
    if (marker.Length < 4)
    { 
        continue; 
    }
    if (marker.Length > 4)
    {
        marker = marker.Remove(0, 1);
    }

    if (marker[0] != marker[1] &&
        marker[0] != marker[2] &&
        marker[0] != marker[3] &&
        marker[1] != marker[2] &&
        marker[1] != marker[3] &&
        marker[2] != marker[3]) 
    {
        break;
    }
}

Console.WriteLine($"Result part 1: {result}");

result = 0;

marker = "";
foreach (var c in line)
{
    marker += c;
    result += 1;
    if (marker.Length < 14)
    { 
        continue; 
    }
    if (marker.Length > 14)
    {
        marker = marker.Remove(0, 1);
    }

    var duplicate = false;
    for (int i = 0; i < marker.Length; i++)
    {
        for (int j = i + 1; j < marker.Length; j++)
        {
            if (marker[i] == marker[j])
            {
                duplicate = true;
                break;
            }
        }
        if (duplicate) 
        { 
            break; 
        }
    }

    if (!duplicate)
    {
        break;
    }
}

Console.WriteLine($"Result part 2: {result}");
