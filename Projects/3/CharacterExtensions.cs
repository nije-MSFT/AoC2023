namespace AoC2023_3
{
    public static class CharacterExtensions
    {
        public static bool IsNumber(this char character)
        {
            return character >= '0' && character <= '9';
        }
    }
}
