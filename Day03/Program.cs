void First()
{
    var prioritySum = 0;

    foreach (string line in File.ReadLines(@"input.txt"))
    {
        var firstHalf = line.Substring(0, line.Length / 2);
        var secondHalf = line.Substring(line.Length / 2);

        foreach (var c in firstHalf)
        {
            if (secondHalf.Contains(c))
            {
                var a = (short)c >= 97 ? ((short)c - 96) : ((short)c - 65 + 27);
                //Console.WriteLine($"{firstHalf} - {secondHalf}, priority: {c} / {a}");
                prioritySum += a;
                break;
            }
        }
    }

    Console.WriteLine($"priority sum: {prioritySum}");
}

void Second()
{
    var prioritySum = 0;

    var lines = File.ReadLines(@"input.txt").ToArray();

    for (int i = 0; i < lines.Count(); i += 3)
    {
        var l1 = lines[i];
        var l2 = lines[i + 1];
        var l3 = lines[i + 2];

        foreach (var c in l1)
        {
            if (l2.Contains(c) && l3.Contains(c))
            {
                var a = (short)c >= 97 ? ((short)c - 96) : ((short)c - 65 + 27);
                //Console.WriteLine($"{firstHalf} - {secondHalf}, priority: {c} / {a}");
                prioritySum += a;
                break;
            }
        }
    }

    Console.WriteLine($"priority sum: {prioritySum}");
}

First();

Second();