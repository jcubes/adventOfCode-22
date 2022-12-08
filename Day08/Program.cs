using System;

void First()
{
    var map = File.ReadLines(@"input.txt").Select(s => s.Select(c => int.Parse(c.ToString())).ToArray()).ToArray();

    var x = map.Length;
    var y = map.First().Length;

    int[,] trees = new int[x, y];

    for (int i = 0; i < x; i++)
    {
        var max = -1;
        for (int j = 0; j < y; j++)
        {
            var a = map[i][j];
            if (a > max)
            {
                trees[i, j] = 1;
                max = map[i][j];
            }
        }

        max = -1;
        for (int j = y - 1; j >= 0; j--)
        {
            if (map[i][j] > max)
            {
                trees[i, j] = 1;
                max = map[i][j];
            }
        }
    }

    for (int i = 0; i < y; i++)
    {
        var max = -1;
        for (int j = 0; j < x; j++)
        {
            if (map[j][i] > max)
            {
                trees[j, i] = 1;
                max = map[j][i];
            }
        }

        max = -1;
        for (int j = x - 1; j >= 0; j--)
        {
            if (map[j][i] > max)
            {
                trees[j, i] = 1;
                max = map[j][i];
            }
        }
    }

    var count = 0;
    for (int i = 0; i < x; i++)
    {
        for (int j = 0; j < y; j++)
        {
            if (trees[i, j] == 1)
                count++;
        }
    }


    Console.WriteLine($"Result: {count}");
}

void Second()
{
    var map = File.ReadLines(@"input.txt").Select(s => s.Select(c => int.Parse(c.ToString())).ToArray()).ToArray();

    var x = map.Length;
    var y = map.First().Length;

    var maxScore = 0;

    for (int i = 0; i < y; i++)
    {
        for (int j = 0; j < x; j++)
        {
            var c1 = x - j - 1;
            for (int k = j + 1; k < x; k++)
            {
                if (map[i][k] >= map[i][j])
                {
                    c1 = k - j;
                    break;
                }
            }

            var c2 = j;
            for (int k = j - 1; k >= 0; k--)
            {
                if (map[i][k] >= map[i][j])
                {
                    c2 = j - k;
                    break;
                }
            }

            var c3 = y - i - 1;
            for (int k = i + 1; k < y; k++)
            {
                if (map[k][j] >= map[i][j])
                {
                    c3 = k - i;
                    break;
                }
            }

            var c4 = i;
            for (int k = i - 1; k >= 0; k--)
            {
                if (map[k][j] >= map[i][j])
                {
                    c4 = i - k;
                    break;
                }
            }

            var s = c1 * c2 * c3 * c4;
            if (s > maxScore)
                maxScore = s;
        }
    }

    Console.WriteLine($"Result: {maxScore}");
}

First();

Second();
