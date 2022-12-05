void First()
{
    Stack<char>[] stackArray = new Stack<char>[] { new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>() };
    stackArray[0].Push('L');
    stackArray[0].Push('N');
    stackArray[0].Push('W');
    stackArray[0].Push('T');
    stackArray[0].Push('D');

    stackArray[1].Push('C');
    stackArray[1].Push('P');
    stackArray[1].Push('H');

    stackArray[2].Push('W');
    stackArray[2].Push('P');
    stackArray[2].Push('H');
    stackArray[2].Push('N');
    stackArray[2].Push('D');
    stackArray[2].Push('G');
    stackArray[2].Push('M');
    stackArray[2].Push('J');

    stackArray[3].Push('C');
    stackArray[3].Push('W');
    stackArray[3].Push('S');
    stackArray[3].Push('N');
    stackArray[3].Push('T');
    stackArray[3].Push('Q');
    stackArray[3].Push('L');

    stackArray[4].Push('P');
    stackArray[4].Push('H');
    stackArray[4].Push('C');
    stackArray[4].Push('N');

    stackArray[5].Push('T');
    stackArray[5].Push('H');
    stackArray[5].Push('N');
    stackArray[5].Push('D');
    stackArray[5].Push('M');
    stackArray[5].Push('W');
    stackArray[5].Push('Q');
    stackArray[5].Push('B');

    stackArray[6].Push('M');
    stackArray[6].Push('B');
    stackArray[6].Push('R');
    stackArray[6].Push('J');
    stackArray[6].Push('G');
    stackArray[6].Push('S');
    stackArray[6].Push('L');

    stackArray[7].Push('Z');
    stackArray[7].Push('N');
    stackArray[7].Push('W');
    stackArray[7].Push('G');
    stackArray[7].Push('V');
    stackArray[7].Push('B');
    stackArray[7].Push('R');
    stackArray[7].Push('T');

    stackArray[8].Push('W');
    stackArray[8].Push('G');
    stackArray[8].Push('D');
    stackArray[8].Push('N');
    stackArray[8].Push('P');
    stackArray[8].Push('L');

    var start = false;

    foreach (var line in File.ReadLines(@"input.txt"))
    {
        var step = line.Split(" ");
        var from = int.Parse(step[3]) - 1;
        var to = int.Parse(step[5]) - 1;


        for (int i = 0; i < int.Parse(step[1]); i++)
        {
            stackArray[to].Push(stackArray[from].Pop());
        }
    }

    var r = "";
    foreach (var s in stackArray)
    {
        r += s.Peek();
    }

    Console.WriteLine($"Result: {r}");
}

void Second()
{
    Stack<char>[] stackArray = new Stack<char>[] { new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>() };
    stackArray[0].Push('L');
    stackArray[0].Push('N');
    stackArray[0].Push('W');
    stackArray[0].Push('T');
    stackArray[0].Push('D');

    stackArray[1].Push('C');
    stackArray[1].Push('P');
    stackArray[1].Push('H');

    stackArray[2].Push('W');
    stackArray[2].Push('P');
    stackArray[2].Push('H');
    stackArray[2].Push('N');
    stackArray[2].Push('D');
    stackArray[2].Push('G');
    stackArray[2].Push('M');
    stackArray[2].Push('J');

    stackArray[3].Push('C');
    stackArray[3].Push('W');
    stackArray[3].Push('S');
    stackArray[3].Push('N');
    stackArray[3].Push('T');
    stackArray[3].Push('Q');
    stackArray[3].Push('L');

    stackArray[4].Push('P');
    stackArray[4].Push('H');
    stackArray[4].Push('C');
    stackArray[4].Push('N');

    stackArray[5].Push('T');
    stackArray[5].Push('H');
    stackArray[5].Push('N');
    stackArray[5].Push('D');
    stackArray[5].Push('M');
    stackArray[5].Push('W');
    stackArray[5].Push('Q');
    stackArray[5].Push('B');

    stackArray[6].Push('M');
    stackArray[6].Push('B');
    stackArray[6].Push('R');
    stackArray[6].Push('J');
    stackArray[6].Push('G');
    stackArray[6].Push('S');
    stackArray[6].Push('L');

    stackArray[7].Push('Z');
    stackArray[7].Push('N');
    stackArray[7].Push('W');
    stackArray[7].Push('G');
    stackArray[7].Push('V');
    stackArray[7].Push('B');
    stackArray[7].Push('R');
    stackArray[7].Push('T');

    stackArray[8].Push('W');
    stackArray[8].Push('G');
    stackArray[8].Push('D');
    stackArray[8].Push('N');
    stackArray[8].Push('P');
    stackArray[8].Push('L');

    var craneStack = new Stack<char>();

    foreach (var line in File.ReadLines(@"input.txt"))
    {
        var step = line.Split(" ");
        var from = int.Parse(step[3]) - 1;
        var to = int.Parse(step[5]) - 1;


        craneStack.Clear();
        for (int i = 0; i < int.Parse(step[1]); i++)
        {
            craneStack.Push(stackArray[from].Pop());
        }

        for (int i = 0; i < int.Parse(step[1]); i++)
        {
            stackArray[to].Push(craneStack.Pop());
        }
    }

    var r = "";
    foreach (var s in stackArray)
    {
        r += s.Peek();
    }

    Console.WriteLine($"Result: {r}");
}

First();

Second();
