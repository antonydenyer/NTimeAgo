using System;

namespace NTimeAgo
{
    public static class TimeInWordExtensions
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

        private static string InWordsFromNow(this TimeSpan dateFromNow, ITimeWordFactory timeWordFactory)
        {
            var prefix = GetPrefix(WordStrings.prefixFromNow);
            var payload = timeWordFactory.GetMessage(dateFromNow);
            var suffix = GetSuffix(WordStrings.suffixFromNow);

            return prefix + payload + suffix;
        }

        private static string InWordsAgo(this TimeSpan dateAgo, ITimeWordFactory timeWordFactory)
        {
            var prefix = GetPrefix(WordStrings.prefixAgo);
            var payload = timeWordFactory.GetMessage(dateAgo);
            var suffix = GetSuffix(WordStrings.suffixAgo);

            return prefix + payload + suffix;
        }

        private static string GetPrefix(string compare)
        {
            if (!string.IsNullOrEmpty(compare))
            {
                return compare + WordStrings.wordSeparator;
            }
            return string.Empty;
        }

        private static string GetSuffix(string compare)
        {
            if (!string.IsNullOrEmpty(compare))
            {
                return WordStrings.wordSeparator + compare;
            }
            return string.Empty;
        }
    }
}
