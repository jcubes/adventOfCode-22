void First()
{
    long sum = 0;
    foreach (var line in File.ReadLines(@"input.txt"))
    {
        long n = 0;
        for (int i = 0; i < line.Length; i++)
        {
            var c = line[line.Length - i - 1];
            if (c == '-')
                n += ((long)Math.Pow(5, i)) * -1;
            else if (c == '=')
                n += ((long)Math.Pow(5, i)) * -2;
            else
                n += ((long)Math.Pow(5, i)) * long.Parse(c.ToString());
        }
        sum += n;
    }

    long a = sum;
    string x = "";
    while (true)
    {
        if (a == 0)
            break;
        var zv = a % 5;
        a = a / 5;
        if (zv > 2)
        {
            x = (zv - 5 == -2 ? "=" : "-") + x;
            a++;
        }
        else
        {
            x = zv + x;
        }
    }

    Console.WriteLine($"Result 1: {x}");
}

void Second()
{
    var result = 0;

    Console.WriteLine($"Result 2: {result}");
}

First();

//Second();
