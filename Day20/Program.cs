void First()
{
    var result = 0;

    var numbers = File.ReadLines(@"input.txt").Select(s => (int.Parse(s), 0)).ToList();

    while (numbers.Any(n => n.Item2 == 0))
    {
        var x = numbers.FindIndex(result => result.Item2 == 0);
        var n = numbers[x];
        numbers.RemoveAt(x);
        n.Item2 = 1;
        var newIndex = (x + n.Item1) % numbers.Count;
        if (newIndex < 0)
            newIndex = numbers.Count + newIndex;
        numbers.Insert(newIndex, n);
    }

    var s = numbers.FindIndex(n => n.Item1 == 0);
    var x1 = (s + 1000) % numbers.Count;
    var x2 = (s + 2000) % numbers.Count;
    var x3 = (s + 3000) % numbers.Count;

    result = numbers[x1].Item1 + numbers[x2].Item1 + numbers[x3].Item1;

    Console.WriteLine($"Result 1: {result}");
}

void Second()
{
    long result = 0;

    var numbers = File.ReadLines(@"input.txt").Select(s => (long.Parse(s) * 811589153, 0)).ToList();

    for (int i = 0; i < numbers.Count; i++)
    {
        numbers[i] = (numbers[i].Item1, i);
    }

    for (int i = 0; i < 10; i++)
    {
        for (int j = 0; j < numbers.Count; j++)
        {
            var x = numbers.FindIndex(result => result.Item2 == j);
            var n = numbers[x];
            numbers.RemoveAt(x);
            var newIndex = (int)((((long)x) + n.Item1) % ((long)numbers.Count));
            if (newIndex < 0)
                newIndex = numbers.Count + newIndex;
            numbers.Insert(newIndex, n);
        }
    }

    var s = numbers.FindIndex(n => n.Item1 == 0);
    var x1 = numbers[(s + 1000) % numbers.Count].Item1;
    var x2 = numbers[(s + 2000) % numbers.Count].Item1;
    var x3 = numbers[(s + 3000) % numbers.Count].Item1;

    result = x1 + x2 + x3;

    Console.WriteLine($"Result 2: {result}");
}

First();

Second();
