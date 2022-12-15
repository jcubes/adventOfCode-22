void First()
{
    var result = 0;
    var walls = File.ReadAllLines("input.txt").Select(l => l.Split(" -> ").Select(x => Tuple.Create(int.Parse(x.Split(",")[0]), int.Parse(x.Split(",")[1]))));

    var x = walls.SelectMany(w => w.Select(p => p.Item1));
    var y = walls.SelectMany(w => w.Select(p => p.Item2));

    var xMin = x.Min() - 200+54;
    var xMax = x.Max() + 250-154;
    var yMin = y.Min();
    var yMax = y.Max() + 3;

    var xSize = xMax - xMin + 1 + 5;
    var ySize = yMax - yMin + 1 + 13;

    yMin = yMin - 13;

    int[,] map = new int[xSize, ySize];

    foreach (var wall in walls)
    {
        var a = wall.ToArray();
        for (int i = 0; i < a.Length - 1; i++)
        {
            var v = Tuple.Create(a[i].Item1 - a[i + 1].Item1, a[i].Item2 - a[i + 1].Item2);
            if (v.Item1 != 0)
            {
                foreach (var j in Enumerable.Range((v.Item1 < 0 ? v.Item1 : 0), Math.Abs(v.Item1) + 1))
                {
                    var x1 = a[i].Item1 - xMin - j;
                    var y1 = a[i].Item2 - yMin;
                    map[x1, y1] = 5;
                }
            }

            if (v.Item2 != 0)
            {
                foreach (var j in Enumerable.Range((v.Item2 < 0 ? v.Item2 : 0), Math.Abs(v.Item2) + 1))
                {
                    var x1 = a[i].Item1 - xMin;
                    var y1 = a[i].Item2 - yMin - j;
                    map[x1, y1] = 5;
                }
            }
        }
    }

    for (int i = 0; i < xSize; i++)
    {
        map[i, ySize - 2] = 5;
    }

    //foreach (var wall in walls)
    //{
    //    Console.WriteLine(string.Join(" -- ", wall.Select(w => $"({w.Item1},{w.Item2})")));
    //}

    //for (int i = 0; i < ySize/3; i++)
    //{
    //    for (int j = 0; j < xSize; j++)
    //    {
    //        Console.Write(map[j, i]);
    //    }
    //    Console.WriteLine();
    //}
    //Console.WriteLine();

    var end = false;
    var sandStart = Tuple.Create(500 - xMin, 0);
    while (!end)
    {
        var newSand = sandStart;
        var falling = true;
        while (falling)
        {
            for (int i = newSand.Item2; i < ySize; i++)
            {
                if (map[newSand.Item1, i] != 5 && map[newSand.Item1, i] != 3)
                {
                    newSand = Tuple.Create(newSand.Item1, i);
                }
                else
                {
                    break;
                }
            }

            if (newSand.Item1 - 1 < 0 || newSand.Item2 + 1 > ySize - 1)
            {
                end = true;
                falling = false;
                break;
            }

            if (map[newSand.Item1 - 1, newSand.Item2 + 1] == 0)
            {
                newSand = Tuple.Create(newSand.Item1 - 1, newSand.Item2 + 1);
                continue;
            }

            if (newSand.Item1 + 1 > xSize - 1 || newSand.Item2 + 1 > ySize - 1)
            {
                end = true;
                falling = false;
                break;
            }

            if (map[newSand.Item1 + 1, newSand.Item2 + 1] == 0)
            {
                newSand = Tuple.Create(newSand.Item1 + 1, newSand.Item2 + 1);
                continue;
            }

            falling = false;
        }

        map[newSand.Item1, newSand.Item2] = 3;
        result++;
        if (map[sandStart.Item1, sandStart.Item2] == 3)
            end = true;
    }

    for (int i = 0; i < ySize; i++)
    {
        for (int j = 0; j < xSize; j++)
        {
            var v = map[j, i];
            if (v == 5)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("█");
            }
            if (v == 3)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("o");
            }
            if (v == 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(".");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.WriteLine();
    }
    Console.WriteLine();

    Console.WriteLine(result);
}

void Second()
{

}

First();

Second();
