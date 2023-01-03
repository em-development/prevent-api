namespace Application.Extensions
{
    static class DateTimeExtension
    {
        public static double Age(this DateTime date)
        {
            var today = DateTime.Today;

            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (date.Year * 100 + date.Month) * 100 + date.Day;

            return (a - b) / 10000;
        }
    }
}
