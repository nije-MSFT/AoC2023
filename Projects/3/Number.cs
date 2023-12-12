using System.Text;

namespace AoC2023_3
{
    internal class Number
    {
        public int StartPosition { get; }
        public int EndPosition { get; private set; }
        public int Value { get; set; }

        public StringBuilder sb { get; }

        public Number(int startPostion)
        {
            StartPosition = startPostion;
            sb = new StringBuilder();
        }

        public void End(int endPosition)
        {
            EndPosition = endPosition;
            Value = int.Parse(sb.ToString());
        }
    }
}
