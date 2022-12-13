using _7;

var result = 0;

var helpers = new Helpers.File();
//var data = helpers.Read("Data.txt");
var lines = helpers.ReadLines("Data.txt");

var rootFolder = new Folder(null, "");
var currentFolder = rootFolder;

foreach (var line in lines)
{
    if (line.StartsWith('$'))
    {
        if (line.Contains("cd"))
        {
            if (line.Contains(".."))
            {
                currentFolder = currentFolder?.Parent;
            }
            else if (line.Contains("/"))
            {
                currentFolder= rootFolder;
            }
            else
            {
                currentFolder = currentFolder?.FindFolder(line.Split(" ").Last());
            }
        }
    }
    else
    {
        if (line.StartsWith("dir"))
        {
            currentFolder?.Folders.Add(new Folder(currentFolder, line.Split(" ").Last()));
        }
        else
        {
            currentFolder?.Files.Add(new ElfFile(line.Split(" ").Last(), int.Parse(line.Split(" ").First())));
        }
    }
}

var folders = rootFolder.FolderSizes();

foreach(var folder in folders)
{
    if (folder.Size <= 100000)
    {
        result += folder.Size;
    }
}

Console.WriteLine($"Result part 1: {result}");

result = 70000000;

var rootFolderSize = rootFolder.Size();
foreach (var folder in folders)
{
    if (70000000 - rootFolderSize + folder.Size > 30000000)
    {
        if (folder.Size < result)
        {
            result = folder.Size;
        }    
    }
}

Console.WriteLine($"Result part 2: {result}");
