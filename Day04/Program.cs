void First()
{
    var contained = 0;
    foreach (var line in File.ReadLines(@"input.txt"))
    {
        var elfOne = line.Split(",")[0].Split("-").Select(s => int.Parse(s)).ToArray();
        var elfTwo = line.Split(",")[1].Split("-").Select(s => int.Parse(s)).ToArray();

        if (elfOne[0] <= elfTwo[0] && elfOne[1] >= elfTwo[1])
            contained++;
        else if (elfOne[1] <= elfTwo[1] && elfOne[0] >= elfTwo[0])
            contained++;
    }

    Console.WriteLine($"Contained: {contained}");
}

void Second()
{
    var overlapping = 0;
    foreach (var line in File.ReadLines(@"input.txt"))
    {
        var elfOne = line.Split(",")[0].Split("-").Select(s => int.Parse(s)).ToArray();
        var elfTwo = line.Split(",")[1].Split("-").Select(s => int.Parse(s)).ToArray();

        if (elfOne[0] <= elfTwo[0] && elfTwo[0] <= elfOne[1])
            overlapping++;
        else if (elfTwo[0] <= elfOne[0] && elfOne[0] <= elfTwo[1])
            overlapping++;
    }

    Console.WriteLine($"Overlapped: {overlapping}");
}

First();

Second();