namespace AoC2023_3
{
    internal class Symbol
    {
        public int Position { get; }

        public char Value { get; }

        public Symbol(int postion, char value)
        {
            Position = postion;
            Value = value;
        }
    }
}
