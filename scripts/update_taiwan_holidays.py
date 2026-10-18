"""Generate the offline Taiwan provider from DGPA dataset 14718 (Python 3.11+)."""
import argparse
import calendar
import csv
import datetime as dt
import io
import json
from pathlib import Path
import re
import urllib.parse
import urllib.request

METADATA_URL = "https://data.gov.tw/api/v2/rest/dataset/14718"
OUTPUT = Path(__file__).resolve().parents[1] / "src/Nager.Date/HolidayProviders/TaiwanHolidayProvider.cs"
TRANSLATIONS = {
    "開國紀念日": "New Year's Day",
    "小年夜": "Lunar New Year's Eve Eve",
    "農曆除夕": "Lunar New Year's Eve",
    "春節": "Lunar New Year",
    "和平紀念日": "Peace Memorial Day",
    "兒童節": "Children's Day",
    "民族掃墓節": "Tomb-Sweeping Day",
    "清明節": "Tomb-Sweeping Day",
    "兒童節及民族掃墓節": "Children's Day and Tomb-Sweeping Day",
    "勞動節": "Labour Day",
    "端午節": "Dragon Boat Festival",
    "中秋節": "Mid-Autumn Festival",
    "孔子誕辰紀念日": "Confucius' Birthday / Teachers' Day",
    "孔子誕辰紀念日/教師節": "Confucius' Birthday / Teachers' Day",
    "國慶日": "National Day",
    "臺灣光復暨金門古寧頭大捷紀念日": "Taiwan Retrocession and Battle of Guningtou Memorial Day",
    "行憲紀念日": "Constitution Day",
    "補假": "Substitute Holiday",
    "調整放假": "Adjusted Holiday",
    "放假": "Holiday",
}


def download(url):
    url = urllib.parse.quote(url, safe=":/?=&%")
    request = urllib.request.Request(url, headers={"User-Agent": "curl/8.0"})
    with urllib.request.urlopen(request, timeout=60) as response:
        return response.read()


def resources(metadata):
    """Later revisions in the publisher's ordered resource list supersede originals."""
    if not metadata.get("success"):
        raise ValueError("Dataset API reported failure")
    selected = {}
    for resource in metadata["result"]["distribution"]:
        description = resource["resourceDescription"]
        if resource["resourceFormat"].upper() != "CSV" or "Google" in description:
            continue
        match = re.match(r"(\d+)年", description)
        if not match:
            raise ValueError(f"Unknown calendar resource: {description}")
        url = resource["resourceDownloadUrl"]
        parsed = urllib.parse.urlparse(url)
        if parsed.scheme != "https" or parsed.hostname != "www.dgpa.gov.tw":
            raise ValueError(f"Unexpected download URL: {url}")
        selected[int(match[1]) + 1911] = url
    if not selected:
        raise ValueError("No calendar resources found")
    return selected


def parse_calendar(data, year):
    for encoding in ("utf-8-sig", "cp950"):
        try:
            text = data.decode(encoding)
            break
        except UnicodeDecodeError:
            if encoding == "cp950":
                raise
    reader = csv.DictReader(io.StringIO(text))
    if not {"西元日期", "是否放假", "備註"}.issubset(reader.fieldnames or []):
        raise ValueError(f"Unexpected CSV columns for {year}")
    seen, holidays = set(), []
    for row in reader:
        date = dt.datetime.strptime(row["西元日期"].strip(), "%Y%m%d").date()
        if date.year != year or date in seen:
            raise ValueError(f"Duplicate or wrong-year date: {date}")
        seen.add(date)
        flag = row["是否放假"].strip()
        if flag not in {"0", "2"}:
            raise ValueError(f"Unknown holiday flag: {flag}")
        name = row["備註"].strip()
        # Ordinary weekends and compensatory working days are not public holidays.
        if flag == "0" or (not name and date.weekday() >= 5):
            continue
        if not name:
            raise ValueError(f"Unnamed weekday holiday: {date}")
        if name not in TRANSLATIONS:
            raise ValueError(f"Add an English translation for {name!r} ({date})")
        holidays.append((date, name, TRANSLATIONS[name]))
    if len(seen) != 365 + calendar.isleap(year):
        raise ValueError(f"Incomplete calendar for {year}: {len(seen)} days")
    if not 10 <= len(holidays) <= 40:
        raise ValueError(f"Unexpected holiday count for {year}: {len(holidays)}")
    return sorted(holidays)


# Reviewed substitute dates from the published DGPA annual calendars.
# Keys identify the original holiday, including each day of Lunar New Year.
OBSERVED_DATES = {
    2017: {"NEWYEARSDAY-01": "01-02", "CHINESENEWYEAR-01": "01-31",
           "CHINESENEWYEAR-02": "02-01", "CHILDRENSDAY-01": "04-03"},
    2018: {"CHINESENEWYEAR-02": "02-19", "CHINESENEWYEAR-03": "02-20"},
    2020: {"CHINESENEWYEAR-01": "01-28", "CHINESENEWYEAR-02": "01-29",
           "CHILDRENSDAY-01": "04-03", "TOMBSWEEPINGDAY-01": "04-02", "NATIONALDAY-01": "10-09"},
    2021: {"CHINESENEWYEAR-02": "02-15", "CHINESENEWYEAR-03": "02-16",
           "PEACEMEMORIALDAY-01": "03-01", "CHILDRENSDAY-01": "04-02",
           "TOMBSWEEPINGDAY-01": "04-05", "NATIONALDAY-01": "10-11"},
    2022: {"MIDAUTUMNFESTIVAL-01": "09-09"},
    2023: {"NEWYEARSDAY-01": "01-02", "CHINESENEWYEARSEVE-01": "01-25", "CHINESENEWYEAR-01": "01-26"},
    2024: {"CHINESENEWYEAR-01": "02-13", "CHINESENEWYEAR-02": "02-14", "CHILDRENSDAY-01": "04-05"},
    2025: {"CHILDRENSDAY-01": "04-03", "DRAGONBOATFESTIVAL-01": "05-30",
           "TEACHERSDAY-01": "09-29", "RETROCESSIONDAY-01": "10-24"},
    2026: {"CHINESENEWYEARSEVEEVE-01": "02-20", "PEACEMEMORIALDAY-01": "02-27",
           "CHILDRENSDAY-01": "04-03", "TOMBSWEEPINGDAY-01": "04-06",
           "NATIONALDAY-01": "10-09", "RETROCESSIONDAY-01": "10-26"},
    2027: {"CHINESENEWYEAR-01": "02-09", "CHINESENEWYEAR-02": "02-10",
           "PEACEMEMORIALDAY-01": "03-01", "CHILDRENSDAY-01": "04-06",
           "LABOURDAY-01": "04-30", "NATIONALDAY-01": "10-11", "CONSTITUTIONDAY-01": "12-24"},
}
HOLIDAY_IDS = {
    "New Year's Day": "NEWYEARSDAY", "Lunar New Year's Eve Eve": "CHINESENEWYEARSEVEEVE",
    "Lunar New Year's Eve": "CHINESENEWYEARSEVE", "Lunar New Year": "CHINESENEWYEAR",
    "Peace Memorial Day": "PEACEMEMORIALDAY", "Children's Day": "CHILDRENSDAY",
    "Tomb-Sweeping Day": "TOMBSWEEPINGDAY", "Labour Day": "LABOURDAY",
    "Dragon Boat Festival": "DRAGONBOATFESTIVAL", "Mid-Autumn Festival": "MIDAUTUMNFESTIVAL",
    "Confucius' Birthday / Teachers' Day": "TEACHERSDAY", "National Day": "NATIONALDAY",
    "Taiwan Retrocession and Battle of Guningtou Memorial Day": "RETROCESSIONDAY",
    "Constitution Day": "CONSTITUTIONDAY", "Adjusted Holiday": "ADJUSTEDHOLIDAY",
}


def specifications(year, holidays):
    entries, counts, substitutes = [], {}, set()
    for date, local, english in holidays:
        if local in {"補假", "放假"}:
            substitutes.add(date)
            continue
        names = [(local, english)]
        if local == "兒童節及民族掃墓節":
            names = [("兒童節", "Children's Day"), ("民族掃墓節", "Tomb-Sweeping Day")]
        for local, english in names:
            prefix = HOLIDAY_IDS[english]
            counts[prefix] = counts.get(prefix, 0) + 1
            identifier = f"{prefix}-{counts[prefix]:02d}"
            observed = date
            observed_text = OBSERVED_DATES.get(year, {}).get(identifier)
            if observed_text:
                observed = dt.date.fromisoformat(f"{year}-{observed_text}")
                if observed not in substitutes and not any(d == observed and n in {"補假", "放假"} for d, n, _ in holidays):
                    raise ValueError(f"Substitute date not published for {year} {identifier}: {observed}")
            entries.append((date, identifier, local, english, observed))
    for date, _, _, _, observed in entries:
        if date != observed:
            substitutes.discard(observed)
    # The following year's New Year's Day can be observed on December 31.
    for date in sorted(substitutes):
        if date.month != 12 or date.day != 31 or dt.date(year + 1, 1, 1).weekday() != 5:
            raise ValueError(f"Review the substitute holiday mapping for {date}")
        entries.append((date, "NEWYEARSDAY-SUBSTITUTE-01", "開國紀念日（補假）", "New Year's Day (Substitute)", date))
    # Preserve the previous year's observed date on the original January 1 entry.
    if dt.date(year, 1, 1).weekday() == 5:
        entries = [(date, identifier, local, english, dt.date(year - 1, 12, 31) if identifier == "NEWYEARSDAY-01" else observed)
                   for date, identifier, local, english, observed in entries]
    return sorted(entries)


def render(calendars):
    lines = [
        "using Nager.Date.Models;", "using System;", "using System.Collections.Generic;", "",
        "namespace Nager.Date.HolidayProviders", "{",
        "    /// <summary>", "    /// Taiwan HolidayProvider", "    /// </summary>",
        "    internal sealed class TaiwanHolidayProvider : AbstractHolidayProvider", "    {",
        "        /// <summary>", "        /// Taiwan HolidayProvider", "        /// </summary>",
        "        public TaiwanHolidayProvider() : base(CountryCode.TW)", "        {", "        }", "",
        "        // Source: https://data.gov.tw/dataset/14718 (DGPA).",
        "        // License: Government Data Open License, version 1.0.",
        "        /// <inheritdoc/>",
        "        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)", "        {",
        "            return this.GetCalendarHolidays(year);", "        }", "",
        "        private HolidaySpecification[] GetCalendarHolidays(int year)", "        {",
        "            switch (year)", "            {",
    ]
    for year, holidays in sorted(calendars.items()):
        lines.extend([f"                case {year}:", "                    return", "                    ["])
        for date, identifier, local, english, observed in specifications(year, holidays):
            lines.extend([
                "                        new HolidaySpecification", "                        {",
                f'                            Id = "{identifier}",',
                f"                            Date = new DateTime(year, {date.month}, {date.day}),",
                f"                            EnglishName = {json.dumps(english)},",
                f"                            LocalName = {json.dumps(local, ensure_ascii=False)},",
                "                            HolidayTypes = HolidayTypes.Public,",
            ])
            if observed != date:
                weekday = date.strftime("%A")
                observed_year = "year" if observed.year == year else "year - 1"
                lines.extend([
                    "                            ObservedRuleSet = new ObservedRuleSet", "                            {",
                    f"                                {weekday} = date => new DateTime({observed_year}, {observed.month}, {observed.day})",
                    "                            },",
                ])
            lines.append("                        },")
        lines.append("                    ];")
    lines.extend([
        "                default:", "                    return [];", "            }", "        }", "",
        "        /// <inheritdoc/>", "        public override IEnumerable<string> GetSources()", "        {",
        "            return", "            [", '                "https://data.gov.tw/dataset/14718",',
        "            ];", "        }", "    }", "}", "",
    ])
    return "\n".join(lines)


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--output", type=Path, default=OUTPUT)
    output = parser.parse_args().output
    selected = resources(json.loads(download(METADATA_URL)))
    # Never remove previously published years if the upstream list is truncated.
    existing = set(map(int, re.findall(r"(?:case |\[)(\d{4})(?::|\] =)", output.read_text() if output.exists() else "")))
    if not existing.issubset(selected):
        raise ValueError("Upstream is missing previously published years")
    calendars = {year: parse_calendar(download(url), year) for year, url in sorted(selected.items())}
    # Write only after every resource has been downloaded and validated.
    output.write_text(render(calendars), encoding="utf-8", newline="\r\n")
    print(f"Updated Taiwan holidays: {min(calendars)}–{max(calendars)}")


if __name__ == "__main__":
    main()
