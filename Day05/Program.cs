void First()
{
    var lines = File.ReadLines(@"input.txt");

    var stackCount = (lines.First().Length / 4) + 1;

    var stackLines = new List<string>();

    foreach (var line in lines)
    {
        if (string.IsNullOrEmpty(line))
            break;

        stackLines.Add(line);
    }

    stackLines.Reverse();

    var stackArrayA = new List<Stack<char>>();

    for (int i = 0; i < stackCount; i++)
    {
        stackArrayA.Add(new Stack<char>());
    }

    var stackArray = stackArrayA.ToArray();

    foreach (var line in stackLines.Skip(1))
    {
        for (int i = 0; i < stackCount; i++)
        {
            var a = line.Substring(i * 3 + i, 3);
            if (a[1] != ' ')
                stackArray[i].Push(a[1]);
        }
    }

    var start = false;
    foreach (var line in File.ReadLines(@"input.txt"))
    {
        if (start)
        {
            var step = line.Split(" ");
            var from = int.Parse(step[3]) - 1;
            var to = int.Parse(step[5]) - 1;


            for (int i = 0; i < int.Parse(step[1]); i++)
            {
                stackArray[to].Push(stackArray[from].Pop());
            }
        }

        if (string.IsNullOrEmpty(line))
            start = true;
    }

    var r = "";
    foreach (var s in stackArray)
    {
        r += s.Peek();
    }

    Console.WriteLine($"Result: {r}");
}

void Second()
{
    var lines = File.ReadLines(@"input.txt");

    var stackCount = (lines.First().Length / 4) + 1;

    var stackLines = new List<string>();

    foreach (var line in lines)
    {
        if (string.IsNullOrEmpty(line))
            break;

        stackLines.Add(line);
    }

    stackLines.Reverse();

    var stackArrayA = new List<Stack<char>>();

    for (int i = 0; i < stackCount; i++)
    {
        stackArrayA.Add(new Stack<char>());
    }

    var stackArray = stackArrayA.ToArray();

    foreach (var line in stackLines.Skip(1))
    {
        for (int i = 0; i < stackCount; i++)
        {
            var a = line.Substring(i * 3 + i, 3);
            if (a[1] != ' ')
                stackArray[i].Push(a[1]);
        }
    }

    var craneStack = new Stack<char>();
    var start = false;

    foreach (var line in File.ReadLines(@"input.txt"))
    {
        if (start)
        {
            var step = line.Split(" ");
            var from = int.Parse(step[3]) - 1;
            var to = int.Parse(step[5]) - 1;

            craneStack.Clear();
            for (int i = 0; i < int.Parse(step[1]); i++)
            {
                craneStack.Push(stackArray[from].Pop());
            }

            for (int i = 0; i < int.Parse(step[1]); i++)
            {
                stackArray[to].Push(craneStack.Pop());
            }
        }

        if (string.IsNullOrEmpty(line))
            start = true;
    }

    var r = "";
    foreach (var s in stackArray)
    {
        r += s.Peek();
    }

    Console.WriteLine($"Result: {r}");
}

First();

Second();
