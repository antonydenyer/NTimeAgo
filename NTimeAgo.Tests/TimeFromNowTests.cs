using System;
using NUnit.Framework;
using Should;

namespace NTimeAgo.Tests
{
    [TestFixture]
    public class TimeFromNowTests
    {
        private DateTime _dateTime;

        [SetUp]
        public void setup()
        {
            _dateTime = DateTime.Now;
            TimeInWordExtensions.DateTimeNow = _dateTime;
        }

        [Test]
        public void in_a_second()
        {
            var inASecond = _dateTime.AddSeconds(45);

            inASecond.InWords().ShouldEqual("less than a minute from now");
        }

        [Test]
        public void about_a_minute_from_now()
        {
            var minuteFromNow = _dateTime.AddMinutes(1).AddSeconds(45);

            minuteFromNow.InWords().ShouldEqual("about a minute from now");
        }

        [Test]
        public void three_minutes_from_now_always_round_down()
        {
            var threeMinutesFromNow = _dateTime.AddMinutes(3).AddSeconds(45);

            threeMinutesFromNow.InWords().ShouldEqual("3 minutes from now");
        }

        [Test]
        public void an_hour_from_now()
        {
            var hourFromNow = _dateTime.AddHours(1);

            hourFromNow.InWords().ShouldEqual("about an hour from now");
        }

        [Test]
        public void two_hours_from_now()
        {
            var twoHours = _dateTime.AddHours(7);

            twoHours.InWords().ShouldEqual("about 7 hours from now");
        }

        [Test]
        public void a_day_from_now()
        {
            var dayFromNow = _dateTime.AddDays(1);

            dayFromNow.InWords().ShouldEqual("a day from now");
        }

        [Test]
        public void days_from_now()
        {
            var dayFromNow = _dateTime.AddDays(4);

            dayFromNow.InWords().ShouldEqual("4 days from now");
        }

        [Test]
        public void year_from_now()
        {
            var yearFromNow = _dateTime.AddYears(1);

            yearFromNow.InWords().ShouldEqual("about a year from now");
        }

        [Test]
        public void years_from_now()
        {
            var yearFromNow = _dateTime.AddYears(8);

            yearFromNow.InWords().ShouldEqual("about 8 years from now");
        }
    }
}
