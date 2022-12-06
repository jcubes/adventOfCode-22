void First()
{
    var line = File.ReadAllText(@"input.txt");
    for (int i = 0; i < line.Length - 4; i++)
    {
        if (line.Skip(i).Take(4).Distinct().Count() == 4)
        {
            Console.WriteLine($"start-of-packet: {i + 4}");
            break;
        }
    }

}

void Second()
{
    var line = File.ReadAllText(@"input.txt");
    for (int i = 0; i < line.Length - 14; i++)
    {
        if (line.Skip(i).Take(14).Distinct().Count() == 14)
        {
            Console.WriteLine($"start-of-message: {i + 14}");
            break;
        }
    }

}

First();

Second();
