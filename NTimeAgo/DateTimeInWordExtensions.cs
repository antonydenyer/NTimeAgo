using System;

namespace NTimeAgo
{
    public static class DateTimeInWordExtensions
    {
        private static DateTime? _dateTimeNow;

        public static DateTime DateTimeNow
        {
            get { return _dateTimeNow.HasValue ? _dateTimeNow.Value : DateTime.Now; }
            set { _dateTimeNow = value; }
        }

        public static string InWords(this DateTime date)
        {
            return date.InWords(new TimeWordFactory());
        }

        public static string InWords(this DateTime date, ITimeWordFactory timeWordFactory)
        {
            if (date < DateTimeNow)
            {
                var dateAgo = DateTimeNow.Subtract(date);
                return dateAgo.InWordsAgo(timeWordFactory);
            }

            if (date > DateTimeNow)
            {
                var dateFromNow = date.Subtract(DateTimeNow);
                return dateFromNow.InWordsFromNow(timeWordFactory);
            }
            return "now";
        }


    }
}
