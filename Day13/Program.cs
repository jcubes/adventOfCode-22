using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

void First()
{
    var result = 0;

    var doubles = File.ReadAllText(@"input.txt").Split("\r\n\r\n").Select(s => s.Split("\r\n").Select(s => (JArray)JsonConvert.DeserializeObject(s.Trim()))).ToArray();

    for (int i = 0; i < doubles.Length; i++)
    {
        var f = doubles[i].First();
        var s = doubles[i].Last();

        var res = Check(f, s);

        if (res == 1) result += i + 1;
    }

    Console.WriteLine($"Result 1: {result}");
}


int Check(JToken first, JToken second)
{
    var a = first.Type == JTokenType.Integer ? new JArray(first) : (JArray)first;
    var b = second.Type == JTokenType.Integer ? new JArray(second) : (JArray)second;

    for (int i = 0; i < Math.Min(a.Count, b.Count); i++)
    {
        if (a[i].Type == JTokenType.Integer && b[i].Type == JTokenType.Integer)
        {
            if ((long)a[i] < (long)b[i]) return 1;
            else if ((long)a[i] > (long)b[i]) return -1;
        }
        else
        {
            var r = Check(a[i], b[i]);
            if (r != 0) return r;
        }
    }

    if (a.Count < b.Count) return 1;
    else if (a.Count > b.Count) return -1;
    return 0;
}

void Second()
{
    var result = 0;

    var doubles = File.ReadAllText(@"input.txt").Split("\r\n").Select(s => (JArray)JsonConvert.DeserializeObject(s.Trim()));

    var arr = doubles.OrderByDescending(p => p, new PacketComparer()).ToArray();

    var x = 0;
    var y = 0;
    
    for (int i = 0; i < arr.Length; i++)
    {
        var p = JsonConvert.SerializeObject(arr[i]);
        if (p == "[[2]]") x = i + 1;
        if (p == "[[6]]") y = i + 1;
    }

    result = x * y;

    Console.WriteLine($"Result 2: {result}");
}

First();

Second();

class PacketComparer : IComparer<JArray>
{
    public int Compare(JArray? x, JArray? y)
    {
        return Check(x, y);
    }

    int Check(JToken first, JToken second)
    {
        var a = first.Type == JTokenType.Integer ? new JArray(first) : (JArray)first;
        var b = second.Type == JTokenType.Integer ? new JArray(second) : (JArray)second;

        //Console.WriteLine($"   Compare {JsonConvert.SerializeObject(a)} vs {JsonConvert.SerializeObject(b)}");

        for (int i = 0; i < Math.Min(a.Count, b.Count); i++)
        {
            if (a[i].Type == JTokenType.Integer && b[i].Type == JTokenType.Integer)
            {
                //Console.WriteLine($"   Compare {a[i]} vs {b[i]}");
                if ((long)a[i] < (long)b[i]) return 1;
                else if ((long)a[i] > (long)b[i]) return -1;
            }
            else
            {
                var r = Check(a[i], b[i]);
                if (r != 0) return r;
            }
        }

        if (a.Count < b.Count) return 1;
        else if (a.Count > b.Count) return -1;
        return 0;
    }
}