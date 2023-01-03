namespace Domain.Extensions
{
    public static class stringExtension
    {
        public static bool hasMinhWords(this string value, int min)
        {
            string[]? items = value.Split(" ");

            return items.Length >= min;
        }
    }
}
