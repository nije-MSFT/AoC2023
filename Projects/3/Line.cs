using System.Text;

namespace AoC2023_3
{
    internal class Line
    {
        public List<Number> Numbers;
        public List<int> Symbols;

        public Line()
        { 
            Numbers = new List<Number>();
            Symbols = new List<int>();
        }
    }
}
