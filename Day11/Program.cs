using Day11;

void First()
{
    var monkeys = new Monkey[8];
    monkeys[0] = new Monkey
    {
        items = new Queue<ulong>(new ulong[] { 92, 73, 86, 83, 65, 51, 55, 93 }),
        operation = (old) => old * 5,
        test = (val) => val % 11 == 0 ? 3 : 4
    };

    monkeys[1] = new Monkey
    {
        items = new Queue<ulong>(new ulong[] { 99, 67, 62, 61, 59, 98 }),
        operation = (old) => old * old,
        test = (val) => val % 2 == 0 ? 6 : 7
    };

    monkeys[2] = new Monkey
    {
        items = new Queue<ulong>(new ulong[] { 81, 89, 56, 61, 99 }),
        operation = (old) => old * 7,
        test = (val) => val % 5 == 0 ? 1 : 5
    };

    monkeys[3] = new Monkey
    {
        items = new Queue<ulong>(new ulong[] { 97, 74, 68 }),
        operation = (old) => old + 1,
        test = (val) => val % 17 == 0 ? 2 : 5
    };

    monkeys[4] = new Monkey
    {
        items = new Queue<ulong>(new ulong[] { 78, 73 }),
        operation = (old) => old + 3,
        test = (val) => val % 19 == 0 ? 2 : 3
    };

    monkeys[5] = new Monkey
    {
        items = new Queue<ulong>(new ulong[] { 50 }),
        operation = (old) => old + 5,
        test = (val) => val % 7 == 0 ? 1 : 6
    };

    monkeys[6] = new Monkey
    {
        items = new Queue<ulong>(new ulong[] { 95, 88, 53, 75 }),
        operation = (old) => old + 8,
        test = (val) => val % 3 == 0 ? 0 : 7
    };

    monkeys[7] = new Monkey
    {
        items = new Queue<ulong>(new ulong[] { 50, 77, 98, 85, 94, 56, 89 }),
        operation = (old) => old + 2,
        test = (val) => val % 13 == 0 ? 4 : 0
    };


    for (int i = 0; i < 20; i++)
    {
        for (int j = 0; j < monkeys.Length; j++)
        {
            var m = monkeys[j];
            while (m.items.TryDequeue(out ulong item))
            {
                var n = m.operation(item) / 3;
                m.count++;
                var newMonkey = m.test(n);
                monkeys[newMonkey].items.Enqueue(n);
            }
        }
    }

    Console.WriteLine($"Result 1: {monkeys.Select(m => m.count).OrderByDescending(i => i).Take(2).Aggregate((a, b) => a * b)}");
}

void Second()
{
    var result = 0;

    var monkeys = new Monkey[8];
    monkeys[0] = new Monkey
    {
        items = new Queue<ulong>(new ulong[] { 92, 73, 86, 83, 65, 51, 55, 93 }),
        operation = (old) => old * 5,
        test = (val) => val % 11 == 0 ? 3 : 4
    };

    monkeys[1] = new Monkey
    {
        items = new Queue<ulong>(new ulong[] { 99, 67, 62, 61, 59, 98 }),
        operation = (old) => old * old,
        test = (val) => val % 2 == 0 ? 6 : 7
    };

    monkeys[2] = new Monkey
    {
        items = new Queue<ulong>(new ulong[] { 81, 89, 56, 61, 99 }),
        operation = (old) => old * 7,
        test = (val) => val % 5 == 0 ? 1 : 5
    };

    monkeys[3] = new Monkey
    {
        items = new Queue<ulong>(new ulong[] { 97, 74, 68 }),
        operation = (old) => old + 1,
        test = (val) => val % 17 == 0 ? 2 : 5
    };

    monkeys[4] = new Monkey
    {
        items = new Queue<ulong>(new ulong[] { 78, 73 }),
        operation = (old) => old + 3,
        test = (val) => val % 19 == 0 ? 2 : 3
    };

    monkeys[5] = new Monkey
    {
        items = new Queue<ulong>(new ulong[] { 50 }),
        operation = (old) => old + 5,
        test = (val) => val % 7 == 0 ? 1 : 6
    };

    monkeys[6] = new Monkey
    {
        items = new Queue<ulong>(new ulong[] { 95, 88, 53, 75 }),
        operation = (old) => old + 8,
        test = (val) => val % 3 == 0 ? 0 : 7
    };

    monkeys[7] = new Monkey
    {
        items = new Queue<ulong>(new ulong[] { 50, 77, 98, 85, 94, 56, 89 }),
        operation = (old) => old + 2,
        test = (val) => val % 13 == 0 ? 4 : 0
    };

    for (int i = 0; i < 10000; i++)
    {
        for (int j = 0; j < monkeys.Length; j++)
        {
            var m = monkeys[j];
            while (m.items.TryDequeue(out ulong item))
            {
                var n = (m.operation(item)) % (11*2*5*17*19*7*3*13);
                m.count++;
                var newMonkey = m.test(n);
                monkeys[newMonkey].items.Enqueue(n);
            }
        }

        //if (i == 0 || i == 19 || i % 1000 == 0)
        //{
        //    Console.WriteLine($"Round: {i}");
        //    for (int j = 0; j < monkeys.Length; j++)
        //    {
        //        var m = monkeys[j];
        //        Console.WriteLine($"Monkey {j} [{m.count}]: {string.Join(", ", m.items)}");
        //    }
        //    Console.WriteLine();

        //}
    }

    for (int j = 0; j < monkeys.Length; j++)
    {
        var m = monkeys[j];
        //Console.WriteLine($"Monkey {j} [{m.count}]: {string.Join(", ", m.items)}");
    }
    //Console.WriteLine();

    Console.WriteLine($"Result 2: {monkeys.Select(m => m.count).OrderByDescending(i => i).Take(2).Aggregate((a, b) => a * b)}");
}

First();

Second();