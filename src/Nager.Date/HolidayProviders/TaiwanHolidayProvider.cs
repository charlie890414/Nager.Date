using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Taiwan HolidayProvider
    /// </summary>
    internal sealed class TaiwanHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// Taiwan HolidayProvider
        /// </summary>
        public TaiwanHolidayProvider() : base(CountryCode.TW)
        {
        }

        // Source: https://data.gov.tw/dataset/14718 (DGPA).
        // License: Government Data Open License, version 1.0.
        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            return this.GetCalendarHolidays(year);
        }

        private HolidaySpecification[] GetCalendarHolidays(int year)
        {
            switch (year)
            {
                case 2017:
                    return
                    [
                        new HolidaySpecification
                        {
                            Id = "NEWYEARSDAY-01",
                            Date = new DateTime(year, 1, 1),
                            EnglishName = "New Year's Day",
                            LocalName = "開國紀念日",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Sunday = date => new DateTime(year, 1, 2)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEARSEVE-01",
                            Date = new DateTime(year, 1, 27),
                            EnglishName = "Lunar New Year's Eve",
                            LocalName = "農曆除夕",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-01",
                            Date = new DateTime(year, 1, 28),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Saturday = date => new DateTime(year, 1, 31)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-02",
                            Date = new DateTime(year, 1, 29),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Sunday = date => new DateTime(year, 2, 1)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-03",
                            Date = new DateTime(year, 1, 30),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "ADJUSTEDHOLIDAY-01",
                            Date = new DateTime(year, 2, 27),
                            EnglishName = "Adjusted Holiday",
                            LocalName = "調整放假",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "PEACEMEMORIALDAY-01",
                            Date = new DateTime(year, 2, 28),
                            EnglishName = "Peace Memorial Day",
                            LocalName = "和平紀念日",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHILDRENSDAY-01",
                            Date = new DateTime(year, 4, 4),
                            EnglishName = "Children's Day",
                            LocalName = "兒童節",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Tuesday = date => new DateTime(year, 4, 3)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "TOMBSWEEPINGDAY-01",
                            Date = new DateTime(year, 4, 4),
                            EnglishName = "Tomb-Sweeping Day",
                            LocalName = "民族掃墓節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "ADJUSTEDHOLIDAY-02",
                            Date = new DateTime(year, 5, 29),
                            EnglishName = "Adjusted Holiday",
                            LocalName = "調整放假",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "DRAGONBOATFESTIVAL-01",
                            Date = new DateTime(year, 5, 30),
                            EnglishName = "Dragon Boat Festival",
                            LocalName = "端午節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "MIDAUTUMNFESTIVAL-01",
                            Date = new DateTime(year, 10, 4),
                            EnglishName = "Mid-Autumn Festival",
                            LocalName = "中秋節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "ADJUSTEDHOLIDAY-03",
                            Date = new DateTime(year, 10, 9),
                            EnglishName = "Adjusted Holiday",
                            LocalName = "調整放假",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "NATIONALDAY-01",
                            Date = new DateTime(year, 10, 10),
                            EnglishName = "National Day",
                            LocalName = "國慶日",
                            HolidayTypes = HolidayTypes.Public,
                        },
                    ];
                case 2018:
                    return
                    [
                        new HolidaySpecification
                        {
                            Id = "NEWYEARSDAY-01",
                            Date = new DateTime(year, 1, 1),
                            EnglishName = "New Year's Day",
                            LocalName = "開國紀念日",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEARSEVE-01",
                            Date = new DateTime(year, 2, 15),
                            EnglishName = "Lunar New Year's Eve",
                            LocalName = "農曆除夕",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-01",
                            Date = new DateTime(year, 2, 16),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-02",
                            Date = new DateTime(year, 2, 17),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Saturday = date => new DateTime(year, 2, 19)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-03",
                            Date = new DateTime(year, 2, 18),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Sunday = date => new DateTime(year, 2, 20)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "PEACEMEMORIALDAY-01",
                            Date = new DateTime(year, 2, 28),
                            EnglishName = "Peace Memorial Day",
                            LocalName = "和平紀念日",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHILDRENSDAY-01",
                            Date = new DateTime(year, 4, 4),
                            EnglishName = "Children's Day",
                            LocalName = "兒童節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "TOMBSWEEPINGDAY-01",
                            Date = new DateTime(year, 4, 5),
                            EnglishName = "Tomb-Sweeping Day",
                            LocalName = "民族掃墓節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "ADJUSTEDHOLIDAY-01",
                            Date = new DateTime(year, 4, 6),
                            EnglishName = "Adjusted Holiday",
                            LocalName = "調整放假",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "DRAGONBOATFESTIVAL-01",
                            Date = new DateTime(year, 6, 18),
                            EnglishName = "Dragon Boat Festival",
                            LocalName = "端午節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "MIDAUTUMNFESTIVAL-01",
                            Date = new DateTime(year, 9, 24),
                            EnglishName = "Mid-Autumn Festival",
                            LocalName = "中秋節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "NATIONALDAY-01",
                            Date = new DateTime(year, 10, 10),
                            EnglishName = "National Day",
                            LocalName = "國慶日",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "ADJUSTEDHOLIDAY-02",
                            Date = new DateTime(year, 12, 31),
                            EnglishName = "Adjusted Holiday",
                            LocalName = "調整放假",
                            HolidayTypes = HolidayTypes.Public,
                        },
                    ];
                case 2019:
                    return
                    [
                        new HolidaySpecification
                        {
                            Id = "NEWYEARSDAY-01",
                            Date = new DateTime(year, 1, 1),
                            EnglishName = "New Year's Day",
                            LocalName = "開國紀念日",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEARSEVE-01",
                            Date = new DateTime(year, 2, 4),
                            EnglishName = "Lunar New Year's Eve",
                            LocalName = "農曆除夕",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-01",
                            Date = new DateTime(year, 2, 5),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-02",
                            Date = new DateTime(year, 2, 6),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-03",
                            Date = new DateTime(year, 2, 7),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "ADJUSTEDHOLIDAY-01",
                            Date = new DateTime(year, 2, 8),
                            EnglishName = "Adjusted Holiday",
                            LocalName = "調整放假",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "PEACEMEMORIALDAY-01",
                            Date = new DateTime(year, 2, 28),
                            EnglishName = "Peace Memorial Day",
                            LocalName = "和平紀念日",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "ADJUSTEDHOLIDAY-02",
                            Date = new DateTime(year, 3, 1),
                            EnglishName = "Adjusted Holiday",
                            LocalName = "調整放假",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHILDRENSDAY-01",
                            Date = new DateTime(year, 4, 4),
                            EnglishName = "Children's Day",
                            LocalName = "兒童節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "TOMBSWEEPINGDAY-01",
                            Date = new DateTime(year, 4, 5),
                            EnglishName = "Tomb-Sweeping Day",
                            LocalName = "民族掃墓節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "DRAGONBOATFESTIVAL-01",
                            Date = new DateTime(year, 6, 7),
                            EnglishName = "Dragon Boat Festival",
                            LocalName = "端午節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "MIDAUTUMNFESTIVAL-01",
                            Date = new DateTime(year, 9, 13),
                            EnglishName = "Mid-Autumn Festival",
                            LocalName = "中秋節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "NATIONALDAY-01",
                            Date = new DateTime(year, 10, 10),
                            EnglishName = "National Day",
                            LocalName = "國慶日",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "ADJUSTEDHOLIDAY-03",
                            Date = new DateTime(year, 10, 11),
                            EnglishName = "Adjusted Holiday",
                            LocalName = "調整放假",
                            HolidayTypes = HolidayTypes.Public,
                        },
                    ];
                case 2020:
                    return
                    [
                        new HolidaySpecification
                        {
                            Id = "NEWYEARSDAY-01",
                            Date = new DateTime(year, 1, 1),
                            EnglishName = "New Year's Day",
                            LocalName = "開國紀念日",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "ADJUSTEDHOLIDAY-01",
                            Date = new DateTime(year, 1, 23),
                            EnglishName = "Adjusted Holiday",
                            LocalName = "調整放假",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEARSEVE-01",
                            Date = new DateTime(year, 1, 24),
                            EnglishName = "Lunar New Year's Eve",
                            LocalName = "農曆除夕",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-01",
                            Date = new DateTime(year, 1, 25),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Saturday = date => new DateTime(year, 1, 28)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-02",
                            Date = new DateTime(year, 1, 26),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Sunday = date => new DateTime(year, 1, 29)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-03",
                            Date = new DateTime(year, 1, 27),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "PEACEMEMORIALDAY-01",
                            Date = new DateTime(year, 2, 28),
                            EnglishName = "Peace Memorial Day",
                            LocalName = "和平紀念日",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHILDRENSDAY-01",
                            Date = new DateTime(year, 4, 4),
                            EnglishName = "Children's Day",
                            LocalName = "兒童節",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Saturday = date => new DateTime(year, 4, 3)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "TOMBSWEEPINGDAY-01",
                            Date = new DateTime(year, 4, 4),
                            EnglishName = "Tomb-Sweeping Day",
                            LocalName = "民族掃墓節",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Saturday = date => new DateTime(year, 4, 2)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "DRAGONBOATFESTIVAL-01",
                            Date = new DateTime(year, 6, 25),
                            EnglishName = "Dragon Boat Festival",
                            LocalName = "端午節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "ADJUSTEDHOLIDAY-02",
                            Date = new DateTime(year, 6, 26),
                            EnglishName = "Adjusted Holiday",
                            LocalName = "調整放假",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "MIDAUTUMNFESTIVAL-01",
                            Date = new DateTime(year, 10, 1),
                            EnglishName = "Mid-Autumn Festival",
                            LocalName = "中秋節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "ADJUSTEDHOLIDAY-03",
                            Date = new DateTime(year, 10, 2),
                            EnglishName = "Adjusted Holiday",
                            LocalName = "調整放假",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "NATIONALDAY-01",
                            Date = new DateTime(year, 10, 10),
                            EnglishName = "National Day",
                            LocalName = "國慶日",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Saturday = date => new DateTime(year, 10, 9)
                            },
                        },
                    ];
                case 2021:
                    return
                    [
                        new HolidaySpecification
                        {
                            Id = "NEWYEARSDAY-01",
                            Date = new DateTime(year, 1, 1),
                            EnglishName = "New Year's Day",
                            LocalName = "開國紀念日",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "ADJUSTEDHOLIDAY-01",
                            Date = new DateTime(year, 2, 10),
                            EnglishName = "Adjusted Holiday",
                            LocalName = "調整放假",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEARSEVE-01",
                            Date = new DateTime(year, 2, 11),
                            EnglishName = "Lunar New Year's Eve",
                            LocalName = "農曆除夕",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-01",
                            Date = new DateTime(year, 2, 12),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-02",
                            Date = new DateTime(year, 2, 13),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Saturday = date => new DateTime(year, 2, 15)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-03",
                            Date = new DateTime(year, 2, 14),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Sunday = date => new DateTime(year, 2, 16)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "PEACEMEMORIALDAY-01",
                            Date = new DateTime(year, 2, 28),
                            EnglishName = "Peace Memorial Day",
                            LocalName = "和平紀念日",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Sunday = date => new DateTime(year, 3, 1)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "CHILDRENSDAY-01",
                            Date = new DateTime(year, 4, 4),
                            EnglishName = "Children's Day",
                            LocalName = "兒童節",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Sunday = date => new DateTime(year, 4, 2)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "TOMBSWEEPINGDAY-01",
                            Date = new DateTime(year, 4, 4),
                            EnglishName = "Tomb-Sweeping Day",
                            LocalName = "民族掃墓節",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Sunday = date => new DateTime(year, 4, 5)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "DRAGONBOATFESTIVAL-01",
                            Date = new DateTime(year, 6, 14),
                            EnglishName = "Dragon Boat Festival",
                            LocalName = "端午節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "ADJUSTEDHOLIDAY-02",
                            Date = new DateTime(year, 9, 20),
                            EnglishName = "Adjusted Holiday",
                            LocalName = "調整放假",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "MIDAUTUMNFESTIVAL-01",
                            Date = new DateTime(year, 9, 21),
                            EnglishName = "Mid-Autumn Festival",
                            LocalName = "中秋節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "NATIONALDAY-01",
                            Date = new DateTime(year, 10, 10),
                            EnglishName = "National Day",
                            LocalName = "國慶日",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Sunday = date => new DateTime(year, 10, 11)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "NEWYEARSDAY-SUBSTITUTE-01",
                            Date = new DateTime(year, 12, 31),
                            EnglishName = "New Year's Day (Substitute)",
                            LocalName = "開國紀念日（補假）",
                            HolidayTypes = HolidayTypes.Public,
                        },
                    ];
                case 2022:
                    return
                    [
                        new HolidaySpecification
                        {
                            Id = "NEWYEARSDAY-01",
                            Date = new DateTime(year, 1, 1),
                            EnglishName = "New Year's Day",
                            LocalName = "開國紀念日",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Saturday = date => new DateTime(year - 1, 12, 31)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEARSEVE-01",
                            Date = new DateTime(year, 1, 31),
                            EnglishName = "Lunar New Year's Eve",
                            LocalName = "農曆除夕",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-01",
                            Date = new DateTime(year, 2, 1),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-02",
                            Date = new DateTime(year, 2, 2),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-03",
                            Date = new DateTime(year, 2, 3),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "ADJUSTEDHOLIDAY-01",
                            Date = new DateTime(year, 2, 4),
                            EnglishName = "Adjusted Holiday",
                            LocalName = "調整放假",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "PEACEMEMORIALDAY-01",
                            Date = new DateTime(year, 2, 28),
                            EnglishName = "Peace Memorial Day",
                            LocalName = "和平紀念日",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHILDRENSDAY-01",
                            Date = new DateTime(year, 4, 4),
                            EnglishName = "Children's Day",
                            LocalName = "兒童節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "TOMBSWEEPINGDAY-01",
                            Date = new DateTime(year, 4, 5),
                            EnglishName = "Tomb-Sweeping Day",
                            LocalName = "民族掃墓節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "DRAGONBOATFESTIVAL-01",
                            Date = new DateTime(year, 6, 3),
                            EnglishName = "Dragon Boat Festival",
                            LocalName = "端午節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "MIDAUTUMNFESTIVAL-01",
                            Date = new DateTime(year, 9, 10),
                            EnglishName = "Mid-Autumn Festival",
                            LocalName = "中秋節",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Saturday = date => new DateTime(year, 9, 9)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "NATIONALDAY-01",
                            Date = new DateTime(year, 10, 10),
                            EnglishName = "National Day",
                            LocalName = "國慶日",
                            HolidayTypes = HolidayTypes.Public,
                        },
                    ];
                case 2023:
                    return
                    [
                        new HolidaySpecification
                        {
                            Id = "NEWYEARSDAY-01",
                            Date = new DateTime(year, 1, 1),
                            EnglishName = "New Year's Day",
                            LocalName = "開國紀念日",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Sunday = date => new DateTime(year, 1, 2)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEARSEVEEVE-01",
                            Date = new DateTime(year, 1, 20),
                            EnglishName = "Lunar New Year's Eve Eve",
                            LocalName = "小年夜",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEARSEVE-01",
                            Date = new DateTime(year, 1, 21),
                            EnglishName = "Lunar New Year's Eve",
                            LocalName = "農曆除夕",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Saturday = date => new DateTime(year, 1, 25)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-01",
                            Date = new DateTime(year, 1, 22),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Sunday = date => new DateTime(year, 1, 26)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-02",
                            Date = new DateTime(year, 1, 23),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-03",
                            Date = new DateTime(year, 1, 24),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "ADJUSTEDHOLIDAY-01",
                            Date = new DateTime(year, 1, 27),
                            EnglishName = "Adjusted Holiday",
                            LocalName = "調整放假",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "ADJUSTEDHOLIDAY-02",
                            Date = new DateTime(year, 2, 27),
                            EnglishName = "Adjusted Holiday",
                            LocalName = "調整放假",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "PEACEMEMORIALDAY-01",
                            Date = new DateTime(year, 2, 28),
                            EnglishName = "Peace Memorial Day",
                            LocalName = "和平紀念日",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "ADJUSTEDHOLIDAY-03",
                            Date = new DateTime(year, 4, 3),
                            EnglishName = "Adjusted Holiday",
                            LocalName = "調整放假",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHILDRENSDAY-01",
                            Date = new DateTime(year, 4, 4),
                            EnglishName = "Children's Day",
                            LocalName = "兒童節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "TOMBSWEEPINGDAY-01",
                            Date = new DateTime(year, 4, 5),
                            EnglishName = "Tomb-Sweeping Day",
                            LocalName = "民族掃墓節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "DRAGONBOATFESTIVAL-01",
                            Date = new DateTime(year, 6, 22),
                            EnglishName = "Dragon Boat Festival",
                            LocalName = "端午節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "ADJUSTEDHOLIDAY-04",
                            Date = new DateTime(year, 6, 23),
                            EnglishName = "Adjusted Holiday",
                            LocalName = "調整放假",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "MIDAUTUMNFESTIVAL-01",
                            Date = new DateTime(year, 9, 29),
                            EnglishName = "Mid-Autumn Festival",
                            LocalName = "中秋節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "ADJUSTEDHOLIDAY-05",
                            Date = new DateTime(year, 10, 9),
                            EnglishName = "Adjusted Holiday",
                            LocalName = "調整放假",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "NATIONALDAY-01",
                            Date = new DateTime(year, 10, 10),
                            EnglishName = "National Day",
                            LocalName = "國慶日",
                            HolidayTypes = HolidayTypes.Public,
                        },
                    ];
                case 2024:
                    return
                    [
                        new HolidaySpecification
                        {
                            Id = "NEWYEARSDAY-01",
                            Date = new DateTime(year, 1, 1),
                            EnglishName = "New Year's Day",
                            LocalName = "開國紀念日",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEARSEVEEVE-01",
                            Date = new DateTime(year, 2, 8),
                            EnglishName = "Lunar New Year's Eve Eve",
                            LocalName = "小年夜",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEARSEVE-01",
                            Date = new DateTime(year, 2, 9),
                            EnglishName = "Lunar New Year's Eve",
                            LocalName = "農曆除夕",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-01",
                            Date = new DateTime(year, 2, 10),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Saturday = date => new DateTime(year, 2, 13)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-02",
                            Date = new DateTime(year, 2, 11),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Sunday = date => new DateTime(year, 2, 14)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-03",
                            Date = new DateTime(year, 2, 12),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "PEACEMEMORIALDAY-01",
                            Date = new DateTime(year, 2, 28),
                            EnglishName = "Peace Memorial Day",
                            LocalName = "和平紀念日",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHILDRENSDAY-01",
                            Date = new DateTime(year, 4, 4),
                            EnglishName = "Children's Day",
                            LocalName = "兒童節",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Thursday = date => new DateTime(year, 4, 5)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "TOMBSWEEPINGDAY-01",
                            Date = new DateTime(year, 4, 4),
                            EnglishName = "Tomb-Sweeping Day",
                            LocalName = "民族掃墓節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "DRAGONBOATFESTIVAL-01",
                            Date = new DateTime(year, 6, 10),
                            EnglishName = "Dragon Boat Festival",
                            LocalName = "端午節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "MIDAUTUMNFESTIVAL-01",
                            Date = new DateTime(year, 9, 17),
                            EnglishName = "Mid-Autumn Festival",
                            LocalName = "中秋節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "NATIONALDAY-01",
                            Date = new DateTime(year, 10, 10),
                            EnglishName = "National Day",
                            LocalName = "國慶日",
                            HolidayTypes = HolidayTypes.Public,
                        },
                    ];
                case 2025:
                    return
                    [
                        new HolidaySpecification
                        {
                            Id = "NEWYEARSDAY-01",
                            Date = new DateTime(year, 1, 1),
                            EnglishName = "New Year's Day",
                            LocalName = "開國紀念日",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEARSEVEEVE-01",
                            Date = new DateTime(year, 1, 27),
                            EnglishName = "Lunar New Year's Eve Eve",
                            LocalName = "小年夜",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEARSEVE-01",
                            Date = new DateTime(year, 1, 28),
                            EnglishName = "Lunar New Year's Eve",
                            LocalName = "農曆除夕",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-01",
                            Date = new DateTime(year, 1, 29),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-02",
                            Date = new DateTime(year, 1, 30),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-03",
                            Date = new DateTime(year, 1, 31),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "PEACEMEMORIALDAY-01",
                            Date = new DateTime(year, 2, 28),
                            EnglishName = "Peace Memorial Day",
                            LocalName = "和平紀念日",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHILDRENSDAY-01",
                            Date = new DateTime(year, 4, 4),
                            EnglishName = "Children's Day",
                            LocalName = "兒童節",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Friday = date => new DateTime(year, 4, 3)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "TOMBSWEEPINGDAY-01",
                            Date = new DateTime(year, 4, 4),
                            EnglishName = "Tomb-Sweeping Day",
                            LocalName = "民族掃墓節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "DRAGONBOATFESTIVAL-01",
                            Date = new DateTime(year, 5, 31),
                            EnglishName = "Dragon Boat Festival",
                            LocalName = "端午節",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Saturday = date => new DateTime(year, 5, 30)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "TEACHERSDAY-01",
                            Date = new DateTime(year, 9, 28),
                            EnglishName = "Confucius' Birthday / Teachers' Day",
                            LocalName = "孔子誕辰紀念日",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Sunday = date => new DateTime(year, 9, 29)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "MIDAUTUMNFESTIVAL-01",
                            Date = new DateTime(year, 10, 6),
                            EnglishName = "Mid-Autumn Festival",
                            LocalName = "中秋節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "NATIONALDAY-01",
                            Date = new DateTime(year, 10, 10),
                            EnglishName = "National Day",
                            LocalName = "國慶日",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "RETROCESSIONDAY-01",
                            Date = new DateTime(year, 10, 25),
                            EnglishName = "Taiwan Retrocession and Battle of Guningtou Memorial Day",
                            LocalName = "臺灣光復暨金門古寧頭大捷紀念日",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Saturday = date => new DateTime(year, 10, 24)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "CONSTITUTIONDAY-01",
                            Date = new DateTime(year, 12, 25),
                            EnglishName = "Constitution Day",
                            LocalName = "行憲紀念日",
                            HolidayTypes = HolidayTypes.Public,
                        },
                    ];
                case 2026:
                    return
                    [
                        new HolidaySpecification
                        {
                            Id = "NEWYEARSDAY-01",
                            Date = new DateTime(year, 1, 1),
                            EnglishName = "New Year's Day",
                            LocalName = "開國紀念日",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEARSEVEEVE-01",
                            Date = new DateTime(year, 2, 15),
                            EnglishName = "Lunar New Year's Eve Eve",
                            LocalName = "小年夜",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Sunday = date => new DateTime(year, 2, 20)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEARSEVE-01",
                            Date = new DateTime(year, 2, 16),
                            EnglishName = "Lunar New Year's Eve",
                            LocalName = "農曆除夕",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-01",
                            Date = new DateTime(year, 2, 17),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-02",
                            Date = new DateTime(year, 2, 18),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-03",
                            Date = new DateTime(year, 2, 19),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "PEACEMEMORIALDAY-01",
                            Date = new DateTime(year, 2, 28),
                            EnglishName = "Peace Memorial Day",
                            LocalName = "和平紀念日",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Saturday = date => new DateTime(year, 2, 27)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "CHILDRENSDAY-01",
                            Date = new DateTime(year, 4, 4),
                            EnglishName = "Children's Day",
                            LocalName = "兒童節",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Saturday = date => new DateTime(year, 4, 3)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "TOMBSWEEPINGDAY-01",
                            Date = new DateTime(year, 4, 5),
                            EnglishName = "Tomb-Sweeping Day",
                            LocalName = "清明節",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Sunday = date => new DateTime(year, 4, 6)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "LABOURDAY-01",
                            Date = new DateTime(year, 5, 1),
                            EnglishName = "Labour Day",
                            LocalName = "勞動節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "DRAGONBOATFESTIVAL-01",
                            Date = new DateTime(year, 6, 19),
                            EnglishName = "Dragon Boat Festival",
                            LocalName = "端午節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "MIDAUTUMNFESTIVAL-01",
                            Date = new DateTime(year, 9, 25),
                            EnglishName = "Mid-Autumn Festival",
                            LocalName = "中秋節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "TEACHERSDAY-01",
                            Date = new DateTime(year, 9, 28),
                            EnglishName = "Confucius' Birthday / Teachers' Day",
                            LocalName = "孔子誕辰紀念日/教師節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "NATIONALDAY-01",
                            Date = new DateTime(year, 10, 10),
                            EnglishName = "National Day",
                            LocalName = "國慶日",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Saturday = date => new DateTime(year, 10, 9)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "RETROCESSIONDAY-01",
                            Date = new DateTime(year, 10, 25),
                            EnglishName = "Taiwan Retrocession and Battle of Guningtou Memorial Day",
                            LocalName = "臺灣光復暨金門古寧頭大捷紀念日",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Sunday = date => new DateTime(year, 10, 26)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "CONSTITUTIONDAY-01",
                            Date = new DateTime(year, 12, 25),
                            EnglishName = "Constitution Day",
                            LocalName = "行憲紀念日",
                            HolidayTypes = HolidayTypes.Public,
                        },
                    ];
                case 2027:
                    return
                    [
                        new HolidaySpecification
                        {
                            Id = "NEWYEARSDAY-01",
                            Date = new DateTime(year, 1, 1),
                            EnglishName = "New Year's Day",
                            LocalName = "開國紀念日",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEARSEVEEVE-01",
                            Date = new DateTime(year, 2, 4),
                            EnglishName = "Lunar New Year's Eve Eve",
                            LocalName = "小年夜",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEARSEVE-01",
                            Date = new DateTime(year, 2, 5),
                            EnglishName = "Lunar New Year's Eve",
                            LocalName = "農曆除夕",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-01",
                            Date = new DateTime(year, 2, 6),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Saturday = date => new DateTime(year, 2, 9)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-02",
                            Date = new DateTime(year, 2, 7),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Sunday = date => new DateTime(year, 2, 10)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "CHINESENEWYEAR-03",
                            Date = new DateTime(year, 2, 8),
                            EnglishName = "Lunar New Year",
                            LocalName = "春節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "PEACEMEMORIALDAY-01",
                            Date = new DateTime(year, 2, 28),
                            EnglishName = "Peace Memorial Day",
                            LocalName = "和平紀念日",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Sunday = date => new DateTime(year, 3, 1)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "CHILDRENSDAY-01",
                            Date = new DateTime(year, 4, 4),
                            EnglishName = "Children's Day",
                            LocalName = "兒童節",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Sunday = date => new DateTime(year, 4, 6)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "TOMBSWEEPINGDAY-01",
                            Date = new DateTime(year, 4, 5),
                            EnglishName = "Tomb-Sweeping Day",
                            LocalName = "清明節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "LABOURDAY-01",
                            Date = new DateTime(year, 5, 1),
                            EnglishName = "Labour Day",
                            LocalName = "勞動節",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Saturday = date => new DateTime(year, 4, 30)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "DRAGONBOATFESTIVAL-01",
                            Date = new DateTime(year, 6, 9),
                            EnglishName = "Dragon Boat Festival",
                            LocalName = "端午節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "MIDAUTUMNFESTIVAL-01",
                            Date = new DateTime(year, 9, 15),
                            EnglishName = "Mid-Autumn Festival",
                            LocalName = "中秋節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "TEACHERSDAY-01",
                            Date = new DateTime(year, 9, 28),
                            EnglishName = "Confucius' Birthday / Teachers' Day",
                            LocalName = "孔子誕辰紀念日/教師節",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "NATIONALDAY-01",
                            Date = new DateTime(year, 10, 10),
                            EnglishName = "National Day",
                            LocalName = "國慶日",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Sunday = date => new DateTime(year, 10, 11)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "RETROCESSIONDAY-01",
                            Date = new DateTime(year, 10, 25),
                            EnglishName = "Taiwan Retrocession and Battle of Guningtou Memorial Day",
                            LocalName = "臺灣光復暨金門古寧頭大捷紀念日",
                            HolidayTypes = HolidayTypes.Public,
                        },
                        new HolidaySpecification
                        {
                            Id = "CONSTITUTIONDAY-01",
                            Date = new DateTime(year, 12, 25),
                            EnglishName = "Constitution Day",
                            LocalName = "行憲紀念日",
                            HolidayTypes = HolidayTypes.Public,
                            ObservedRuleSet = new ObservedRuleSet
                            {
                                Saturday = date => new DateTime(year, 12, 24)
                            },
                        },
                        new HolidaySpecification
                        {
                            Id = "NEWYEARSDAY-SUBSTITUTE-01",
                            Date = new DateTime(year, 12, 31),
                            EnglishName = "New Year's Day (Substitute)",
                            LocalName = "開國紀念日（補假）",
                            HolidayTypes = HolidayTypes.Public,
                        },
                    ];
                default:
                    return [];
            }
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://data.gov.tw/dataset/14718",
            ];
        }
    }
}
