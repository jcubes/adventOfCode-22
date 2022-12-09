void First()
{
    var h = Tuple.Create(0, 0);
    var t = Tuple.Create(0, 0);

    var history = new List<Tuple<int, int>>();
    history.Add(t); 

    var move = new Tuple<int, int>[] { Tuple.Create(0, 1), Tuple.Create(1, 0), Tuple.Create(0, -1), Tuple.Create(-1, 0) };

    foreach (var line in File.ReadLines(@"input.txt"))
    {
        var cmd = line.Split(' ');

        var m = cmd[0] switch
        {
            "U" => move[0],
            "R" => move[1],
            "D" => move[2],
            "L" => move[3]
        };

        for (int i = 0; i < int.Parse(cmd[1]); i++)
        {
            h = Tuple.Create(h.Item1 + m.Item1, h.Item2 + m.Item2);

            if (Math.Abs(h.Item1 - t.Item1) > 1)
            {
                var x = h.Item1 > t.Item1 ? t.Item1 + 1 : t.Item1 - 1;
                var y = h.Item2;
                t = Tuple.Create(x, y);
                history.Add(t);
            }
            else if (Math.Abs(h.Item2 - t.Item2) > 1)
            {
                var x = h.Item1;
                var y = h.Item2 > t.Item2 ? t.Item2 + 1 : t.Item2 - 1;
                t = Tuple.Create(x, y);
                history.Add(t);
            }
        }
    }

    var result = history.Distinct().Count();

    Console.WriteLine($"Result: {result}");
}

void Second()
{
    Tuple<int, int>[] knots = new Tuple<int, int>[10];
    List<Tuple<int, int>>[] history = new List<Tuple<int, int>>[10];

    for (int i = 0; i < knots.Length; i++)
    {
        knots[i] = Tuple.Create(0, 0);
        history[i] = new List<Tuple<int, int>>();
        history[i].Add(knots[i]);
    }

    var move = new Tuple<int, int>[] { Tuple.Create(0, 1), Tuple.Create(1, 0), Tuple.Create(0, -1), Tuple.Create(-1, 0) };

    foreach (var line in File.ReadLines(@"input.txt"))
    {
        var cmd = line.Split(' ');

        var m = cmd[0] switch
        {
            "U" => move[0],
            "R" => move[1],
            "D" => move[2],
            "L" => move[3]
        };

        for (int i = 0; i < int.Parse(cmd[1]); i++)
        {
            knots[0] = Tuple.Create(knots[0].Item1 + m.Item1, knots[0].Item2 + m.Item2);

            for (int j = 1; j < knots.Length; j++)
            {
                var h = knots[j - 1];
                var t = knots[j];

                if (Math.Abs(h.Item1 - t.Item1) > 1 && Math.Abs(h.Item2 - t.Item2) > 1)
                {
                    var x = h.Item1 > t.Item1 ? t.Item1 + 1 : t.Item1 - 1;
                    var y = h.Item2 > t.Item2 ? t.Item2 + 1 : t.Item2 - 1;
                    knots[j] = Tuple.Create(x, y);
                    history[j].Add(knots[j]);
                }
                else if (Math.Abs(h.Item1 - t.Item1) > 1)
                {
                    var x = h.Item1 > t.Item1 ? t.Item1 + 1 : t.Item1 - 1;
                    var y = h.Item2;
                    knots[j] = Tuple.Create(x, y);
                    history[j].Add(knots[j]);
                }
                else if (Math.Abs(h.Item2 - t.Item2) > 1)
                {
                    var x = h.Item1;
                    var y = h.Item2 > t.Item2 ? t.Item2 + 1 : t.Item2 - 1;
                    knots[j] = Tuple.Create(x, y);
                    history[j].Add(knots[j]);
                }
            }
        }
    }

    var result = history[9].Distinct().Count();

    Console.WriteLine($"Result: {result}");
}

First();

Second();
