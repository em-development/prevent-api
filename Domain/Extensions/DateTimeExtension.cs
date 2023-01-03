namespace Domain.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime ToDateTime(this long timestamp)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(timestamp).ToLocalTime();
            return dtDateTime;
        }

        public static long ToTimestamp(this DateTime dateTime)
        {
            var timeSpan = dateTime - new DateTime(1970, 1, 1, 0, 0, 0);
            return (long) timeSpan.TotalSeconds;
        }
    }
}