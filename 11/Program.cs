using _11;
using System.Numerics;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

var result = 0;

var helpers = new Helpers.File();
//var data = helpers.Read("Data.txt");
var lines = helpers.ReadLines("Data.txt");

var monkeys = new List<Monkey>();
Monkey? monkey = null;
foreach (var line in lines)
{
    if (line.Trim().StartsWith("Monkey"))
    {
        if (monkey != null)
        {
            monkeys.Add(monkey);
        }
        monkey = new Monkey();
    }
    if (line.Trim().StartsWith("Starting items"))
    {
        var items = line.Split(": ").Last();
        var items2 = items.Split(", ");
        foreach(var item in items2)
        {
            monkey?.Items.Add(int.Parse(item));
        }
    }
    if (line.Trim().StartsWith("Operation"))
    {
        var items = line.Split("old ").Last();
        var items2 = items.Split(" ");
        if (monkey != null)
        {
            monkey.OperationItem = items2[0];
            if (items2[1] == "old")
            {
                monkey.OperationNumber = 1;
                monkey.OperationNumberOld = true;
            }
            else
            {
                monkey.OperationNumber = int.Parse(items2[1]);
            }
        }
    }
    if (line.Trim().StartsWith("Test"))
    {
        var item = line.Split("by ").Last();
        if (monkey != null)
        {
            monkey.Divisible = int.Parse(item);
        }
    }
    if (line.Trim().StartsWith("If true"))
    {
        var item = line.Split("monkey ").Last();
        if (monkey != null)
        {
            monkey.DivTrue = int.Parse(item);
        }
    }
    if (line.Trim().StartsWith("If false"))
    {
        var item = line.Split("monkey ").Last();
        if (monkey != null)
        {
            monkey.DivFalse = int.Parse(item);
        }
    }
}
if (monkey != null)
{
    monkeys.Add(monkey);
}

for (int i = 0; i < 20; i++)
{
    foreach (var monkeyLoop in monkeys)
    {
        foreach (var item in monkeyLoop.Items)
        {
            var newItem = item;
            monkeyLoop.HandeldItems++;
            switch (monkeyLoop.OperationItem)
            {
                case "*":
                    if (monkeyLoop.OperationNumberOld)
                    {
                        newItem = newItem * newItem;
                    }
                    else
                    {
                        newItem = newItem * monkeyLoop.OperationNumber;
                    }
                    break;
                case "/":
                    if (monkeyLoop.OperationNumberOld)
                    {
                        newItem = newItem / newItem;
                    }
                    else
                    {
                        newItem = newItem / monkeyLoop.OperationNumber;
                    }
                    break;
                case "+":
                    if (monkeyLoop.OperationNumberOld)
                    {
                        newItem = newItem + newItem;
                    }
                    else
                    {
                        newItem = newItem + monkeyLoop.OperationNumber;
                    }
                    break;
                case "-":
                    if (monkeyLoop.OperationNumberOld)
                    {
                        newItem = newItem - newItem;
                    }
                    else
                    {
                        newItem = newItem - monkeyLoop.OperationNumber;
                    }
                    break;
            }
            newItem = newItem / 3;
            if (newItem % monkeyLoop.Divisible == 0)
            {
                monkeys[monkeyLoop.DivTrue].Items.Add(newItem);
            }
            else
            {
                monkeys[monkeyLoop.DivFalse].Items.Add(newItem);
            }
        }
        monkeyLoop.Items.Clear();
    }
}

var monkeysMost = monkeys.OrderByDescending(m => m.HandeldItems).Take(2).ToList();
result = monkeysMost[0].HandeldItems * monkeysMost[1].HandeldItems;

Console.WriteLine($"Result part 1: {result}");

result = 0;

lines = helpers.ReadLines("Data.txt");

var monkeys2 = new List<Monkey2>();
Monkey2? monkey2 = null;
foreach (var line in lines)
{
    if (line.Trim().StartsWith("Monkey"))
    {
        if (monkey2 != null)
        {
            monkeys2.Add(monkey2);
        }
        monkey2 = new Monkey2();
    }
    if (line.Trim().StartsWith("Starting items"))
    {
        var items = line.Split(": ").Last();
        var items2 = items.Split(", ");
        foreach (var item in items2)
        {
            monkey2?.Items.Add(ulong.Parse(item));
        }
    }
    if (line.Trim().StartsWith("Operation"))
    {
        var items = line.Split("old ").Last();
        var items2 = items.Split(" ");
        if (monkey2 != null)
        {
            monkey2.OperationItem = items2[0];
            if (items2[1] == "old")
            {
                monkey2.OperationNumber = 1;
                monkey2.OperationNumberOld = true;
            }
            else
            {
                monkey2.OperationNumber = ulong.Parse(items2[1]);
            }
        }
    }
    if (line.Trim().StartsWith("Test"))
    {
        var item = line.Split("by ").Last();
        if (monkey2 != null)
        {
            monkey2.Divisible = ulong.Parse(item);
        }
    }
    if (line.Trim().StartsWith("If true"))
    {
        var item = line.Split("monkey ").Last();
        if (monkey2 != null)
        {
            monkey2.DivTrue = int.Parse(item);
        }
    }
    if (line.Trim().StartsWith("If false"))
    {
        var item = line.Split("monkey ").Last();
        if (monkey2 != null)
        {
            monkey2.DivFalse = int.Parse(item);
        }
    }
}
if (monkey2 != null)
{
    monkeys2.Add(monkey2);
}
ulong mod = 1;
foreach (var monkey2a in monkeys2)
{
    mod = mod * monkey2a.Divisible;
}
for (int i = 0; i < 10000; i++)
{
    foreach (var monkeyLoop2 in monkeys2)
    {
        foreach (var item in monkeyLoop2.Items)
        {
            ulong newItem = item;
            monkeyLoop2.HandeldItems++;
            switch (monkeyLoop2.OperationItem)
            {
                case "*":
                    if (monkeyLoop2.OperationNumberOld)
                    {
                        newItem = newItem * newItem;
                    }
                    else
                    {
                        newItem = newItem * monkeyLoop2.OperationNumber;
                    }
                    break;
                case "/":
                    if (monkeyLoop2.OperationNumberOld)
                    {
                        newItem = newItem / newItem;
                    }
                    else
                    {
                        newItem = newItem / monkeyLoop2.OperationNumber;
                    }
                    break;
                case "+":
                    if (monkeyLoop2.OperationNumberOld)
                    {
                        newItem = newItem + newItem;
                    }
                    else
                    {
                        newItem = newItem + monkeyLoop2.OperationNumber;
                    }
                    break;
                case "-":
                    if (monkeyLoop2.OperationNumberOld)
                    {
                        newItem = newItem - newItem;
                    }
                    else
                    {
                        newItem = newItem - monkeyLoop2.OperationNumber;
                    }
                    break;
            }
            newItem = newItem % mod;

            if (newItem % monkeyLoop2.Divisible == 0)
            {
                monkeys2[monkeyLoop2.DivTrue].Items.Add(newItem);
            }
            else
            {
                monkeys2[monkeyLoop2.DivFalse].Items.Add(newItem);
            }
        }
        monkeyLoop2.Items.Clear();
    }
}

var monkeysMost2 = monkeys2.OrderByDescending(m => m.HandeldItems).Take(2).ToList();
result = monkeysMost2[0].HandeldItems * monkeysMost2[1].HandeldItems;
ulong v1 = Convert.ToUInt64(monkeysMost2[0].HandeldItems);
ulong v2 = Convert.ToUInt64(monkeysMost2[1].HandeldItems);
ulong result2 = v1 * v2;

Console.WriteLine($"Result part 2: {result2}");

