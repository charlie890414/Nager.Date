using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class TaiwanTest
    {
        [TestMethod]
        public void TestTaiwan2026()
        {
            var publicHolidays = HolidaySystem.GetHolidays(2026, CountryCode.TW).ToArray();
            var expectedDates = new[]
            {
                "01-01", "02-15", "02-16", "02-17", "02-18", "02-19", "02-28",
                "04-04", "04-05", "05-01", "06-19", "09-25", "09-28", "10-10", "10-25", "12-25",
            };

            CollectionAssert.AreEqual(expectedDates, publicHolidays.Select(holiday => holiday.Date.ToString("MM-dd")).ToArray());
            Assert.AreEqual("Dragon Boat Festival", publicHolidays.Single(holiday => holiday.Date == new DateTime(2026, 6, 19)).EnglishName);
            Assert.AreEqual("清明節", publicHolidays.Single(holiday => holiday.Date == new DateTime(2026, 4, 5)).LocalName);
        }

        [TestMethod]
        [DataRow("TW-CHINESENEWYEARSEVEEVE-01", 2, 20)]
        [DataRow("TW-PEACEMEMORIALDAY-01", 2, 27)]
        [DataRow("TW-CHILDRENSDAY-01", 4, 3)]
        [DataRow("TW-TOMBSWEEPINGDAY-01", 4, 6)]
        [DataRow("TW-NATIONALDAY-01", 10, 9)]
        [DataRow("TW-RETROCESSIONDAY-01", 10, 26)]
        public void TestTaiwan2026ObservedDates(string id, int month, int day)
        {
            var publicHolidays = HolidaySystem.GetHolidays(2026, CountryCode.TW).ToArray();
            var holiday = publicHolidays.Single(holiday => holiday.Id == id);

            Assert.AreEqual(new DateTime(2026, month, day), holiday.ObservedDate);
            Assert.IsFalse(publicHolidays.Any(other => other.Date == holiday.ObservedDate));
        }

        [TestMethod]
        public void TestTaiwan2025RevisedCalendar()
        {
            var publicHolidays = HolidaySystem.GetHolidays(2025, CountryCode.TW).ToArray();
            var expectedDates = new[]
            {
                new DateTime(2025, 9, 28),
                new DateTime(2025, 10, 25),
                new DateTime(2025, 12, 25),
            };

            foreach (var date in expectedDates)
            {
                Assert.IsTrue(publicHolidays.Any(holiday => holiday.Date == date), $"Missing {date:yyyy-MM-dd}");
            }

            Assert.IsFalse(publicHolidays.Any(holiday => holiday.Date == new DateTime(2025, 2, 8)));
            Assert.IsFalse(publicHolidays.Any(holiday => holiday.Date == new DateTime(2025, 9, 3)));
        }

        [TestMethod]
        [DataRow("TW-CHINESENEWYEAR-01")]
        [DataRow("TW-DRAGONBOATFESTIVAL-01")]
        [DataRow("TW-MIDAUTUMNFESTIVAL-01")]
        public void TestTaiwanHolidayIdsAcrossYears(string id)
        {
            var previousHoliday = HolidaySystem.GetHolidays(2025, CountryCode.TW).Single(holiday => holiday.Id == id);
            var currentHoliday = HolidaySystem.GetHolidays(2026, CountryCode.TW).Single(holiday => holiday.Id == id);

            Assert.AreEqual(previousHoliday.EnglishName, currentHoliday.EnglishName);
            Assert.AreNotEqual(previousHoliday.Date.ToString("MM-dd"), currentHoliday.Date.ToString("MM-dd"));
        }

        [TestMethod]
        public void TestTaiwan2027CrossYearSubstituteHoliday()
        {
            var publicHolidays = HolidaySystem.GetHolidays(2027, "TW").ToArray();
            var holiday = publicHolidays.Single(holiday => holiday.Date == new DateTime(2027, 12, 31));

            Assert.AreEqual("TW-NEWYEARSDAY-SUBSTITUTE-01", holiday.Id);
        }

        [TestMethod]
        public void TestTaiwan2022CrossYearObservedDate()
        {
            var holiday = HolidaySystem.GetHolidays(2022, CountryCode.TW).Single(holiday => holiday.Id == "TW-NEWYEARSDAY-01");

            Assert.AreEqual(new DateTime(2021, 12, 31), holiday.ObservedDate);
        }

        [TestMethod]
        [DataRow(2017, 3)]
        [DataRow(2020, 3)]
        [DataRow(2021, 2)]
        [DataRow(2024, 5)]
        [DataRow(2025, 3)]
        public void TestTaiwanOverlappingChildrensDayAndTombSweepingDay(int year, int observedDay)
        {
            var publicHolidays = HolidaySystem.GetHolidays(year, CountryCode.TW).ToArray();
            var childrensDay = publicHolidays.Single(holiday => holiday.Id == "TW-CHILDRENSDAY-01");
            var tombSweepingDay = publicHolidays.Single(holiday => holiday.Id == "TW-TOMBSWEEPINGDAY-01");

            Assert.AreEqual(new DateTime(year, 4, 4), childrensDay.Date);
            Assert.AreEqual(childrensDay.Date, tombSweepingDay.Date);
            Assert.AreEqual(new DateTime(year, 4, observedDay), childrensDay.ObservedDate);
        }

        [TestMethod]
        [DataRow(2016)]
        [DataRow(9999)]
        public void TestTaiwanUnpublishedYear(int year)
        {
            Assert.IsFalse(HolidaySystem.GetHolidays(year, CountryCode.TW).Any());
        }
    }
}
