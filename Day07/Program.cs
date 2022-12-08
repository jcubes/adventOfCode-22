void First()
{
    var root = new Dir { name = "/" };
    var cd = root;

    var lines = File.ReadLines(@"input.txt").ToArray();
    var i = 0;

    while (i < lines.Length)
    {
        var line = lines[i];

        if (line.StartsWith("$"))
        {
            var cmd = line.Split(" ");
            if (cmd[1] == "cd")
            {
                if (cmd[2] == "/")
                    cd = root;
                else if (cmd[2] == "..")
                    cd = cd.parent;
                else
                {
                    if (!cd.sub.ContainsKey(cmd[2]))
                        cd.sub.Add(cmd[2], new Dir { name = cmd[2], parent = cd });

                    cd = cd.sub[cmd[2]];
                }
            }
            if (cmd[1] == "ls")
            {
                i++;
                while (i < lines.Length && !lines[i].StartsWith("$"))
                {
                    var sLine = lines[i].Split();
                    if (sLine[0] == "dir" && !cd.sub.ContainsKey(sLine[1]))
                        cd.sub.Add(sLine[1], new Dir { name = sLine[1], parent = cd });
                    else
                        cd.files.Add(sLine[1], new DirFile { name = sLine[1], size = int.Parse(sLine[0]) });
                    i++;
                }
                if (i < lines.Length)
                    i--;
            }
        }

        i++;
    }

    int c = 0;
    root.Size(ref c);

    Console.WriteLine($"Result: {c}");
}

void Second()
{
    var root = new Dir { name = "/" };
    var cd = root;

    var lines = File.ReadLines(@"input.txt").ToArray();
    var i = 0;

    while (i < lines.Length)
    {
        var line = lines[i];

        if (line.StartsWith("$"))
        {
            var cmd = line.Split(" ");
            if (cmd[1] == "cd")
            {
                if (cmd[2] == "/")
                    cd = root;
                else if (cmd[2] == "..")
                    cd = cd.parent;
                else
                {
                    if (!cd.sub.ContainsKey(cmd[2]))
                        cd.sub.Add(cmd[2], new Dir { name = cmd[2], parent = cd });

                    cd = cd.sub[cmd[2]];
                }
            }
            if (cmd[1] == "ls")
            {
                i++;
                while (i < lines.Length && !lines[i].StartsWith("$"))
                {
                    var sLine = lines[i].Split();
                    if (sLine[0] == "dir" && !cd.sub.ContainsKey(sLine[1]))
                        cd.sub.Add(sLine[1], new Dir { name = sLine[1], parent = cd });
                    else
                        cd.files.Add(sLine[1], new DirFile { name = sLine[1], size = int.Parse(sLine[0]) });
                    i++;
                }
                if (i < lines.Length)
                    i--;
            }
        }

        i++;
    }

    int c = 0;
    var x = root.Size(ref c);

    int max = 70000000;
    int needed = 30000000;
    int free = max - x;

    var toFree = needed - free;
    var minToFree = x;

    root.Size2(toFree, ref minToFree);

    Console.WriteLine($"Total: {max}");
    Console.WriteLine($"Needed: {needed}");
    Console.WriteLine($"Free: {free}");
    Console.WriteLine($"toFree: {toFree}");
    Console.WriteLine($"Result: {minToFree}");
}

First();

Second();
