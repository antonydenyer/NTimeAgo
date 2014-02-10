using System;
using System.Collections.Generic;
using System.Linq;

namespace NTimeAgo
{
    public class TimeWordFactory : ITimeWordFactory
    {
        public static List<TimeWord> TimeInWords = new List<TimeWord>
            {
                new TimeWord(TimeSpan.FromMinutes(1),WordStrings.seconds),
                new TimeWord(TimeSpan.FromMinutes(2),WordStrings.minute),
                new TimeWord(TimeSpan.FromHours(1),WordStrings.minutes),
                new TimeWord(TimeSpan.FromHours(2),WordStrings.hour),
                new TimeWord(TimeSpan.FromDays(1),WordStrings.hours),
                new TimeWord(TimeSpan.FromDays(2),WordStrings.day),
                new TimeWord(TimeSpan.FromDays(365),WordStrings.days),
                new TimeWord(TimeSpan.FromDays(365 * 2),WordStrings.year),
                new TimeWord(TimeSpan.MaxValue,WordStrings.years),
            };

        public string GetMessage(TimeSpan timeSpan)
        {
            return TimeInWords.First(x => timeSpan < x.TimeSpan).ToString(timeSpan);
        }
    }

    public interface ITimeWordFactory
    {
        string GetMessage(TimeSpan dateFromNow);
    }
}