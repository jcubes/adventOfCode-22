void First()
{
    var result = 0;
    var cycle = 0;
    var register = 1;

    int[] importantCycles = new int[] { 20, 60, 100, 140, 180, 220 };

    foreach (var line in File.ReadLines(@"input.txt"))
    {
        var toAdd = 0;
        var toAddCycles = 0;
        if (line.Equals("noop"))
        {
            toAddCycles = 1;
        }

        if (line.StartsWith("addx"))
        {
            toAdd = int.Parse(line.Split(" ")[1]);
            toAddCycles = 2;
        }

        foreach (var imC in importantCycles)
        {
            if (cycle < imC && cycle + toAddCycles >= imC)
            {
                result += register * imC;
                Console.WriteLine($"Value at {imC} cycle = {register * imC}");
            }
        }

        cycle += toAddCycles;
        register += toAdd;
    }

    Console.WriteLine($"Result 1: {result}");
}

void Second()
{
    var cycle = 0;
    var register = 1;

    foreach (var line in File.ReadLines(@"input.txt"))
    {
        var toAdd = 0;
        var toAddCycles = 0;
        if (line.Equals("noop"))
        {
            toAddCycles = 1;
        }

        if (line.StartsWith("addx"))
        {
            toAdd = int.Parse(line.Split(" ")[1]);
            toAddCycles = 2;
        }

        for (int i = cycle; i < cycle + toAddCycles; i++)
        {
            if (i % 40 == 0)
                Console.WriteLine();

            Console.Write(Math.Abs(register - (i % 40)) <= 1 ? "#" : ".");
        }

        cycle += toAddCycles;
        register += toAdd;
    }
}

First();

Second();