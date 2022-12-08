class Dir
{
    public string name;
    public Dictionary<string, DirFile> files;
    public Dictionary<string, Dir> sub;
    public Dir parent;

    public Dir()
    {
        files = new Dictionary<string, DirFile>();
        sub = new Dictionary<string, Dir>();
    }

    public int Size(ref int c)
    {
        var fileSizeSum = files.Values.Select(f => f.size).Sum();
        var dirSizeSum = 0;

        foreach (var item in sub.Values)
            dirSizeSum += item.Size(ref c);

        if (fileSizeSum + dirSizeSum <= 100000)
            c += fileSizeSum + dirSizeSum;
        return fileSizeSum + dirSizeSum;
    }

    public int Size2(int toFree, ref int minToFree)
    {
        var fileSizeSum = files.Values.Select(f => f.size).Sum();
        var dirSizeSum = 0;

        foreach (var item in sub.Values)
            dirSizeSum += item.Size2(toFree, ref minToFree);

        if (fileSizeSum + dirSizeSum > toFree && fileSizeSum + dirSizeSum < minToFree)
            minToFree = fileSizeSum + dirSizeSum;

        return fileSizeSum + dirSizeSum;
    }
}

class DirFile
{
    public string name;
    public int size;
}
