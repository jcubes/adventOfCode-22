void First()
{
    var result = 0;

    var m = File.ReadAllText(@"input.txt").Split("\r\n").Select(s => s.ToArray()).ToArray();

    var x = m.First().Length;
    var y = m.Length;

    var dist = new int[y, x];
    var prev = new Tuple<int, int>[y, x];

    Tuple<int, int> start = null;
    Tuple<int, int> end = null;
    List<Tuple<int, int>> queue = new List<Tuple<int, int>>();

    for (int i = 0; i < y; i++)
    {
        for (int j = 0; j < x; j++)
        {
            dist[i, j] = 1000000;
            if (m[i][j] == 'S')
            {
                start = Tuple.Create(i, j);
                m[i][j] = 'a';
            }
            if (m[i][j] == 'E')
            {
                end = Tuple.Create(i, j);
                m[i][j] = 'z';
            }
            queue.Add(Tuple.Create(i, j));
        }
    }

    dist[start.Item1, start.Item2] = 0;

    while (queue.Count > 0)
    {
        queue = queue.OrderBy(p => dist[p.Item1, p.Item2]).ToList();
        var c = queue.First();
        queue.Remove(c);

        if (c.Item1 == end.Item1 && c.Item2 == end.Item2)
            break;

        var neighbours = new List<Tuple<int, int>>();
        if (c.Item1 > 0) neighbours.Add(Tuple.Create(c.Item1 - 1, c.Item2));
        if (c.Item1 < y - 1) neighbours.Add(Tuple.Create(c.Item1 + 1, c.Item2));
        if (c.Item2 > 0) neighbours.Add(Tuple.Create(c.Item1, c.Item2 - 1));
        if (c.Item2 < x - 1) neighbours.Add(Tuple.Create(c.Item1, c.Item2 + 1));

        foreach (var n in neighbours)
        {
            var a = m[c.Item1][c.Item2] - m[n.Item1][n.Item2];

            var d = ((a >= -1) ? dist[c.Item1, c.Item2] + 1 : 1000000);
            if (d < dist[n.Item1, n.Item2])
            {
                dist[n.Item1, n.Item2] = d;
                prev[n.Item1, n.Item2] = c;
            }
        }
    }

    result = dist[end.Item1, end.Item2];

    Console.WriteLine($"Result 1: {result}");
}

void Second()
{
    var result = 0;

    var m = File.ReadAllText(@"input.txt").Split("\r\n").Select(s => s.ToArray()).ToArray();

    var x = m.First().Length;
    var y = m.Length;

    var dist = new int[y, x];
    var prev = new Tuple<int, int>[y, x];

    Tuple<int, int> start = null;
    List<Tuple<int, int>> queue = new List<Tuple<int, int>>();

    for (int i = 0; i < y; i++)
    {
        for (int j = 0; j < x; j++)
        {
            dist[i, j] = 1000000;
            if (m[i][j] == 'S')
            {
                m[i][j] = 'a';
            }
            if (m[i][j] == 'E')
            {
                start = Tuple.Create(i, j);
                m[i][j] = 'z';
            }
            queue.Add(Tuple.Create(i, j));
        }
    }

    dist[start.Item1, start.Item2] = 0;

    while (queue.Count > 0)
    {
        queue = queue.OrderBy(p => dist[p.Item1, p.Item2]).ToList();
        var c = queue.First();
        queue.Remove(c);

        var neighbours = new List<Tuple<int, int>>();
        if (c.Item1 > 0) neighbours.Add(Tuple.Create(c.Item1 - 1, c.Item2));
        if (c.Item1 < y - 1) neighbours.Add(Tuple.Create(c.Item1 + 1, c.Item2));
        if (c.Item2 > 0) neighbours.Add(Tuple.Create(c.Item1, c.Item2 - 1));
        if (c.Item2 < x - 1) neighbours.Add(Tuple.Create(c.Item1, c.Item2 + 1));

        foreach (var n in neighbours)
        {
            var a = m[c.Item1][c.Item2] - m[n.Item1][n.Item2];

            var d = ((a <= 1) ? dist[c.Item1, c.Item2] + 1 : 1000000);
            if (d < dist[n.Item1, n.Item2])
            {
                dist[n.Item1, n.Item2] = d;
                prev[n.Item1, n.Item2] = c;
            }
        }
    }

    Tuple<int, int> min = null;
    for (int i = 0; i < y; i++)
    {
        for (int j = 0; j < x; j++)
        {
            if (m[i][j] == 'a')
            {
                if (min == null || dist[min.Item1, min.Item2] > dist[i, j])
                    min = Tuple.Create(i, j);
            }
        }
    }

    result = dist[min.Item1, min.Item2];

    Console.WriteLine($"Result 1: {result}");
}

First();

Second();