namespace Day11
{
    public class Monkey
    {
        public Queue<ulong> items;
        public Func<ulong, ulong> operation;
        public Func<ulong, int> test;

        public ulong count;
    }
}
