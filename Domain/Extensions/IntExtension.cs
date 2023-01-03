namespace Domain.Extensions
{
    public static class IntExtension
    {
        public static bool IsBetween(this int num, int min, int max, bool includeMin = true, bool includeMax = true)
        {
            return IsGreatherThan(num, min, includeMin) && IsLessThan(num, max, includeMax);
        }

        private static bool IsGreatherThan(int value, int minValue, bool includeMin)
            => includeMin && value >= minValue || value > minValue;

        private static bool IsLessThan(int value, int maxValue, bool includeMax)
            => includeMax && value <= maxValue || value < maxValue;
    }
}
