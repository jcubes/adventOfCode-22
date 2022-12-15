void First()
{
    const int LINE = 2000000;

    List<(int, int, (int, int))> sensors = new List<(int, int, (int, int))>();

    foreach (var line in File.ReadLines(@"input.txt"))
    {
        var sx = int.Parse(line.Split(" ")[2][2..^1]);
        var sy = int.Parse(line.Split(" ")[3][2..^1]);
        var bx = int.Parse(line.Split(" ")[8][2..^1]);
        var by = int.Parse(line.Split(" ")[9][2..]);

        sensors.Add((sx, sy, (bx, by)));
    }

    var tenLinePoints = new List<int>();

    foreach (var s in sensors)
    {
        var d = Math.Abs(s.Item1 - s.Item3.Item1) + Math.Abs(s.Item2 - s.Item3.Item2);

        var sd = Math.Abs(s.Item2 - LINE);

        if (sd > d)
            continue;

        var xMax = Math.Abs(d - sd);

        tenLinePoints.AddRange(Enumerable.Range(s.Item1 - xMax, xMax * 2 + 1));
        tenLinePoints = tenLinePoints.Distinct().ToList();
    }

    var tenLineBeacons = sensors.Where(s => s.Item3.Item2 == LINE).Select(s => s.Item3.Item1).ToList();

    tenLinePoints = tenLinePoints.Except(tenLineBeacons).ToList();

    Console.WriteLine($"Result 1: {tenLinePoints.Count}");
}

void Second()
{
    const int MIN = 0;
    const int MAX = 4000000;
    const ulong FRQ = 4000000;

    List<(int, int, (int, int))> sensors = new List<(int, int, (int, int))>();

    foreach (var line in File.ReadLines(@"input.txt"))
    {
        var sx = int.Parse(line.Split(" ")[2][2..^1]);
        var sy = int.Parse(line.Split(" ")[3][2..^1]);
        var bx = int.Parse(line.Split(" ")[8][2..^1]);
        var by = int.Parse(line.Split(" ")[9][2..]);

        sensors.Add((sx, sy, (bx, by)));
    }

    List<(int, int)> ranges = new List<(int, int)>();

    int row = 0;
    int col = 0;

    for (int i = 0; i < MAX; i++)
    {
        ranges = new List<(int, int)>();

        foreach (var s in sensors)
        {
            var d = Math.Abs(s.Item1 - s.Item3.Item1) + Math.Abs(s.Item2 - s.Item3.Item2);

            var sd = Math.Abs(s.Item2 - i);

            if (sd > d)
                continue;

            var xMax = Math.Abs(d - sd);

            var aa = Math.Max(MIN, s.Item1 - xMax);
            var bb = Math.Min(MAX, aa + (xMax * 2));

            ranges.Add((aa, bb));
            ranges = ranges.OrderBy(a => a.Item1).ToList();
        }

        row = i;

        var max = ranges.First().Item2;

        foreach (var r in ranges.Skip(1))
        {
            if (r.Item1 > max) { col = r.Item1 - 1; break; }
            if (r.Item2 > max) max = r.Item2;
        }

        if (col > 0)
            break;
    }

    ulong y = (ulong)row;
    ulong x = (ulong)col;

    Console.WriteLine($"Result 2: {x * FRQ + y}");
}

First();

Second();