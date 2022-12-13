var result = 0;

var helpers = new Helpers.File();
//var data = helpers.Read("Data.txt");
var lines = helpers.ReadLines("Data.txt");

var trees = new int[lines[0].Length, lines.Length];
for (int y = 0; y < lines.Length; y++)
{
    var line = lines[y];
    for (int x = 0; x < line.Length; x++)
    {
        var c = line[x];
        trees[y, x] = int.Parse(c.ToString());
    }
}

var visibleTrees = 0;
for (int y = 0; y < trees.GetLength(0); y++)
{
    for (int x = 0; x < trees.GetLength(1); x++)
    {
        if (y == 0 || y == trees.GetLength(0) - 1)
        {
            visibleTrees++;
            continue;
        }
        if (x == 0 || x == trees.GetLength(1) - 1)
        {
            visibleTrees++;
            continue;
        }
        var height = trees[y, x];

        // left
        var visible = true;
        for (int l = x - 1; l >= 0; l--)
        {
            if (trees[y, l] >= height)
            {
                visible= false;
                break;
            }
        }
        if (visible)
        {
            visibleTrees++;
            continue;
        }
        // right
        visible = true;
        for (int r = x + 1; r < trees.GetLength(1); r++)
        {
            if (trees[y, r] >= height)
            {
                visible = false;
                break;
            }
        }
        if (visible)
        {
            visibleTrees++;
            continue;
        }
        // top
        visible = true;
        for (int t = y - 1; t >= 0; t--)
        {
            if (trees[t, x] >= height)
            {
                visible = false;
                break;
            }
        }
        if (visible)
        {
            visibleTrees++;
            continue;
        }
        // bottom
        visible = true;
        for (int b = y + 1; b < trees.GetLength(0); b++)
        {
            if (trees[b, x] >= height)
            {
                visible = false;
                break;
            }
        }
        if (visible)
        {
            visibleTrees++;
            continue;
        }
        // not visible
        result++;
    }
}

result = visibleTrees;

Console.WriteLine($"Result part 1: {result}");

result= 0;

var visibleTreesLeft = 0;
var visibleTreesRight = 0;
var visibleTreesTop = 0;
var visibleTreesBottom = 0;
for (int y = 0; y < trees.GetLength(0); y++)
{
    for (int x = 0; x < trees.GetLength(1); x++)
    {
        visibleTreesLeft = 0;
        visibleTreesRight = 0;
        visibleTreesTop = 0;
        visibleTreesBottom = 0;
        if (y == 0 || y == trees.GetLength(0) - 1)
        {
            continue;
        }
        if (x == 0 || x == trees.GetLength(1) - 1)
        {
            continue;
        }
        var height = trees[y, x];

        // left
        for (int l = x - 1; l >= 0; l--)
        {
            if (trees[y, l] < height)
            {
                visibleTreesLeft++;
            }
            else if (trees[y, l] >= height)
            {
                visibleTreesLeft++;
                break;
            }
            else
            {
                break;
            }
        }
        // right
        for (int r = x + 1; r < trees.GetLength(1); r++)
        {
            if (trees[y, r] < height)
            {
                visibleTreesRight++;
            }
            else if (trees[y, r] >= height)
            {
                visibleTreesRight++;
                break;
            }
            else
            {
                break;
            }
        }
        // top
        for (int t = y - 1; t >= 0; t--)
        {
            if (trees[t, x] < height)
            {
                visibleTreesTop++;
            }
            else if (trees[t, x] >= height)
            {
                visibleTreesTop++;
                break;
            }
            else
            {
                break;
            }
        }
        // bottom
        for (int b = y + 1; b < trees.GetLength(0); b++)
        {
            if (trees[b, x] < height)
            {
                visibleTreesBottom++;
            }
            else if (trees[b, x] >= height)
            {
                visibleTreesBottom++;
                break;
            }
            else
            {
                break;
            }
        }

        var value = visibleTreesLeft * visibleTreesRight * visibleTreesBottom * visibleTreesTop;
        if (value > result)
        {
            result = value;
        }
    }
}

Console.WriteLine($"Result part 2: {result}");