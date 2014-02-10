using System;

namespace NTimeAgo
{
    public static class TimeSpanInWordExtensions
    {
        public static string InWordsFromNow(this TimeSpan fromNow)
        {
            return fromNow.InWordsFromNow(new TimeWordFactory());
        }

        public static string InWordsAgo(this TimeSpan ago)
        {
            return ago.InWordsAgo(new TimeWordFactory());
        }

        public static string InWordsFromNow(this TimeSpan dateFromNow, ITimeWordFactory timeWordFactory)
        {
            var prefix = GetPrefix(WordStrings.prefixFromNow);
            var payload = timeWordFactory.GetMessage(dateFromNow);
            var suffix = GetSuffix(WordStrings.suffixFromNow);

            return prefix + payload + suffix;
        }

        public static string InWordsAgo(this TimeSpan dateAgo, ITimeWordFactory timeWordFactory)
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