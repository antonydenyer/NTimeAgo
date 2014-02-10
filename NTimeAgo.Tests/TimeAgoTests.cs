using System;
using NUnit.Framework;
using Should;

namespace NTimeAgo.Tests
{
    [TestFixture]
    public class TimeAgoTests
    {
        private DateTime _dateTime;

        [SetUp]
        public void setup()
        {
              _dateTime = DateTime.Now;
            DateTimeInWordExtensions.DateTimeNow = _dateTime;
        }

        [Test]
        public void less_than_a_second_ago()
        {
            var lessThanAMinuteAgo = _dateTime.AddSeconds(-45);

            lessThanAMinuteAgo.InWords().ShouldEqual("less than a minute ago");
        }

        [Test]
        public void about_a_minute_ago()
        {
            var minuteAgo = _dateTime.AddMinutes(-1).AddSeconds(-45);

            minuteAgo.InWords().ShouldEqual("about a minute ago");
        }

        [Test]
        public void three_minutes_ago_always_round_down()
        {
            var threeMinutesAgo = _dateTime.AddMinutes(-3).AddSeconds(-45);

            threeMinutesAgo.InWords().ShouldEqual("3 minutes ago");
        }

        [Test]
        public void an_hour_ago()
        {
            var hourAgo = _dateTime.AddHours(-1);

            hourAgo.InWords().ShouldEqual("about an hour ago");
        }

        [Test]
        public void two_hours_ago()
        {
            var twoHours = _dateTime.AddHours(-7);

            twoHours.InWords().ShouldEqual("about 7 hours ago");
        }

        [Test]
        public void a_day_ago()
        {
            var dayAgo = _dateTime.AddDays(-1);

            dayAgo.InWords().ShouldEqual("a day ago");
        }

        [Test]
        public void days_ago()
        {
            var dayAgo = _dateTime.AddDays(-4);

            dayAgo.InWords().ShouldEqual("4 days ago");
        }

        [Test]
        public void year_ago()
        {
            var yearAgo = _dateTime.AddYears(-1);

            yearAgo.InWords().ShouldEqual("about a year ago");
        }

        [Test]
        public void years_ago()
        {
            var yearAgo = _dateTime.AddYears(-8);

            yearAgo.InWords().ShouldEqual("about 8 years ago");
        }
    }
}
