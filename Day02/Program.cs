void First()
{
    var winning = new string[] { "C X", "B Z", "A Y" };
    var draw = new string[] { "A X", "B Y", "C Z" };
    var score = 0;
    foreach (string line in File.ReadLines(@"input.txt"))
    {
        var picks = line.Split(" ");

        score += picks[1] switch
        {
            "Y" => 2,
            "X" => 1,
            "Z" => 3
        };

        if (draw.Contains(line))
            score += 3;
        else if (winning.Contains(line))
            score += 6;
    }

    Console.WriteLine($"Score: {score}");
}


void Second()
{
    var draw = new Dictionary<string, int>() { { "A", 1 }, { "B", 2 }, { "C", 3 } };
    var win = new Dictionary<string, int>() { { "A", 2 }, { "B", 3 }, { "C", 1 } };
    var lose = new Dictionary<string, int>() { { "A", 3 }, { "B", 1 }, { "C", 2 } };
    
    var score = 0;
    foreach (string line in File.ReadLines(@"input.txt"))
    {
        var picks = line.Split(" ");

        switch (picks[1])
        {
            case "X":
                score += lose[picks[0]];
                break;
            case "Y":
                score += draw[picks[0]]+3;
                break;
            case "Z":
                score += win[picks[0]]+6;
                break;
        }
    }

    Console.WriteLine($"Score: {score}");
}


First();

Second();
