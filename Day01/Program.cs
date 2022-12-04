using System.Text.RegularExpressions;

var elfList = new List<int>();
var sum = 0;

foreach (string line in File.ReadLines(@"input.txt"))
{
    if (string.IsNullOrEmpty(line))
    {
        elfList.Add(sum);
        sum = 0;
    }
    else
        sum += int.Parse(line);
}

Console.WriteLine($"max calories: {elfList.OrderBy(e => e).Last()} calories");

Console.WriteLine($"max calories for 3 last: {elfList.OrderBy(e => e).TakeLast(3).Sum()} calories");
