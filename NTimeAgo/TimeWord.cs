using System;
using System.Globalization;

namespace NTimeAgo
{
    public class TimeWord
    {
        public TimeSpan TimeSpan { get; private set; }
        public string Message { get; private set; }

        public TimeWord(TimeSpan timeSpan, string message)
        {
            TimeSpan = timeSpan;
            Message = message;
        }

        public string ToString(TimeSpan timeSpan)
        {
            var formatedMessage = Message.Replace("%m", timeSpan.Minutes.ToString(CultureInfo.InvariantCulture));
            formatedMessage = formatedMessage.Replace("%h", timeSpan.Hours.ToString(CultureInfo.InvariantCulture));
            formatedMessage = formatedMessage.Replace("%d", timeSpan.Days.ToString(CultureInfo.InvariantCulture));
            formatedMessage = formatedMessage.Replace("%M", (timeSpan.Days / (365.25 / 12)).ToString(CultureInfo.InvariantCulture));
            formatedMessage = formatedMessage.Replace("%y", (timeSpan.Days / (365.25)).ToString(CultureInfo.InvariantCulture));
            return formatedMessage;
        }
    }
}