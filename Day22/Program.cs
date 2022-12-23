using System.Text.RegularExpressions;

void First()
{
    var result = 0;

    var directions = new (int, int)[]
    {
        (0,1),
        (1,0),
        (0,-1),
        (-1,0)
    };

    var input = File.ReadAllText("input.txt");
    var map = input.Split("\r\n\r\n")[0].Split("\r\n").Select(s => s.ToArray()).ToArray();
    var maxLength = map.Select(r => r.Length).Max();
    for (int i = 0; i < map.Length; i++)
    {
        char[] l = map[i];
        if (map[i].Length < maxLength)
        {
            var x = new List<char>();
            x.AddRange(l);
            for (int j = 0; j < maxLength - l.Length; j++)
            {
                x.Add(' ');
            }
            map[i] = x.ToArray();
        }
    }

    var instr = input.Split("\r\n\r\n")[1];

    var heading = 0;
    var position = (0, 0);

    for (int i = 0; i < map[0].Length; i++)
    {
        if (map[0][i] != ' ')
        {
            position = (0, i);
            break;
        }
    }

    MatchCollection matches = Regex.Matches(instr, @"([0-9]+[A-Za-z]?)");
    var instr2 = new List<string>();

    foreach (Match match in matches)
    {
        if (match.Groups[1].Value[match.Groups[1].Length - 1] == 'L' || match.Groups[1].Value[match.Groups[1].Length - 1] == 'R')
        {
            if (match.Groups[1].Value.Substring(0, match.Groups[1].Length - 1).Length > 0)
                instr2.Add(match.Groups[1].Value.Substring(0, match.Groups[1].Length - 1));
            if (match.Groups[1].Value[match.Groups[1].Length - 1].ToString().Length > 0)
                instr2.Add(match.Groups[1].Value[match.Groups[1].Length - 1].ToString());
        }
        else
        {
            instr2.Add(match.Groups[1].Value.ToString());
        }
    }

    foreach (string ins in instr2)
    {
        if (ins == "R")
            heading = (heading + 1) % 4;
        else if (ins == "L")
            heading = (heading + 3) % 4;
        else
        {
            var c = int.Parse(ins);
            for (int i = 0; i < c; i++)
            {
                var newP = ((position.Item1 + directions[heading].Item1) % map.Length, (position.Item2 + directions[heading].Item2) % maxLength);
                if (newP.Item1 < 0)
                    newP = (map.Length - 1, newP.Item2);
                if (newP.Item2 < 0)
                    newP = (newP.Item1, maxLength - 1);

                if (map[newP.Item1][newP.Item2] == ' ')
                {
                    var aa = newP;
                    while (true)
                    {
                        aa = ((aa.Item1 + directions[heading].Item1) % map.Length, (aa.Item2 + directions[heading].Item2) % maxLength);
                        if (aa.Item1 < 0)
                            aa = (map.Length - 1, newP.Item2);
                        if (aa.Item2 < 0)
                            aa = (newP.Item1, maxLength - 1);
                        if (map[aa.Item1][aa.Item2] != ' ')
                            break;
                    }
                    newP = aa;
                }

                if (map[newP.Item1][newP.Item2] == '#')
                    break;
                else if (map[newP.Item1][newP.Item2] == '.')
                    position = newP;
            }
        }
    }

    result = (position.Item1 + 1) * 1000 + (position.Item2 + 1) * 4 + heading;
    Console.WriteLine($"Result 1: {result}");
}

void Second()
{
    var result = 0;

    var directions = new (int, int)[]
    {
        (0,1),
        (1,0),
        (0,-1),
        (-1,0)
    };

    var input = File.ReadAllText("input.txt");
    var map = input.Split("\r\n\r\n")[0].Split("\r\n").Select(s => s.ToArray()).ToArray();
    var maxLength = map.Select(r => r.Length).Max();
    for (int i = 0; i < map.Length; i++)
    {
        char[] l = map[i];
        if (map[i].Length < maxLength)
        {
            var x = new List<char>();
            x.AddRange(l);
            for (int j = 0; j < maxLength - l.Length; j++)
            {
                x.Add(' ');
            }
            map[i] = x.ToArray();
        }
    }

    var instr = input.Split("\r\n\r\n")[1];

    var heading = 0;
    var position = (0, 0);

    for (int i = 0; i < map[0].Length; i++)
    {
        if (map[0][i] != ' ')
        {
            position = (0, i);
            break;
        }
    }

    MatchCollection matches = Regex.Matches(instr, @"([0-9]+[A-Za-z]?)");
    var instr2 = new List<string>();

    foreach (Match match in matches)
    {
        if (match.Groups[1].Value[match.Groups[1].Length - 1] == 'L' || match.Groups[1].Value[match.Groups[1].Length - 1] == 'R')
        {
            if (match.Groups[1].Value.Substring(0, match.Groups[1].Length - 1).Length > 0)
                instr2.Add(match.Groups[1].Value.Substring(0, match.Groups[1].Length - 1));
            if (match.Groups[1].Value[match.Groups[1].Length - 1].ToString().Length > 0)
                instr2.Add(match.Groups[1].Value[match.Groups[1].Length - 1].ToString());
        }
        else
        {
            instr2.Add(match.Groups[1].Value.ToString());
        }
    }

    foreach (string ins in instr2)
    {
        if (ins == "R")
            heading = (heading + 1) % 4;
        else if (ins == "L")
            heading = (heading + 3) % 4;
        else
        {
            var c = int.Parse(ins);
            for (int i = 0; i < c; i++)
            {
                var newP = ((position.Item1 + directions[heading].Item1), (position.Item2 + directions[heading].Item2));
                var newH = heading;
                var x = CheckMove(newP, heading);
                newP = x.Item1;
                newH = x.Item2;

                if (newP.Item1 < 0)
                    newP = (0, newP.Item2);
                if (newP.Item1 > 199)
                    newP = (map.Length - 1, newP.Item2);
                if (newP.Item2 < 0)
                    newP = (newP.Item1, 0);
                if (newP.Item2 > 149)
                    newP = (newP.Item1, maxLength - 1);

                if (map[newP.Item1][newP.Item2] == ' ')
                {
                    var aa = newP;
                    while (map[aa.Item1][aa.Item2] == ' ')
                    {
                        aa = (aa.Item1 + directions[newH].Item1, aa.Item2 + directions[newH].Item2);
                        var y = CheckMove(newP, newH);
                        newP = y.Item1;
                        newH = y.Item2;
                    }
                    newP = aa;
                }

                if (map[newP.Item1][newP.Item2] == '|')
                    break;
                else if (map[newP.Item1][newP.Item2] == '.')
                {
                    position = newP;
                    heading = newH;
                }
            }
        }
    }

    result = (position.Item1 + 1) * 1000 + (position.Item2 + 1) * 4 + heading;

    Console.WriteLine($"Result 2: {result}");
}

((int, int), int) CheckMove((int, int) newP, int heading)
{
    if (newP.Item1 == 50 && newP.Item2 >= 100 && heading == 1)
    {
        newP = (newP.Item2 - 50, 99);
        heading = 2;
    }
    else if (newP.Item2 == 100 && newP.Item1 >= 50 && newP.Item1 < 100)
    {
        newP = (49, newP.Item1 + 50);
        heading = 3;
    }
    else if (newP.Item1 == 150 && newP.Item2 >= 50 && newP.Item2 < 100 && heading == 1)
    {
        newP = (newP.Item2 + 100, 49);
        heading = 2;
    }
    else if (newP.Item2 == 50 && newP.Item1 >= 150 && heading == 0)
    {
        newP = (149, newP.Item1 - 100);
        heading = 3;
    }
    else if (newP.Item1 == 99 && newP.Item2 < 50 && heading == 3)
    {
        newP = (50 + newP.Item2, 50);
        heading = 0;
    }
    else if (newP.Item2 == 49 && newP.Item1 >= 50 && newP.Item1 < 100)
    {
        newP = (100, newP.Item1 - 50);
        heading = 1;
    }
    else if (newP.Item2 == 150 && newP.Item1 < 50)
    {
        newP = (100 + 49 - newP.Item1, 100);
        heading = 2;
    }
    else if (newP.Item2 == 100 && newP.Item1 >= 100 && newP.Item1 < 150)
    {
        newP = (149 - newP.Item1, 150);
        heading = 2;
    }
    else if (newP.Item2 == 49 && newP.Item1 < 50)
    {
        newP = (100 + 49 - newP.Item1, 0);
        heading = 0;
    }
    else if (newP.Item2 == -1 && newP.Item1 >= 100 && newP.Item1 < 150)
    {
        newP = (149 - newP.Item1, 49);
        heading = 0;
    }
    else if (newP.Item1 == 200 && newP.Item2 < 50)
    {
        newP = (0, 100 + newP.Item2);
        heading = 1;
    }
    else if (newP.Item1 == -1 && newP.Item2 >= 100)
    {
        newP = (199, newP.Item2-100);
        heading = 3;
    }
    else if (newP.Item1 == -1 && newP.Item2 >= 50 && newP.Item2 < 100)
    {
        newP = (newP.Item2 + 100, 0);
        heading = 0;
    }
    else if (newP.Item2 == -1 && newP.Item1 >= 150)
    {
        newP = (0, newP.Item1 - 100);
        heading = 1;
    }

    return (newP, heading);
}

First();

Second();
