import datetime as dt
import importlib.util
from pathlib import Path
import unittest

spec = importlib.util.spec_from_file_location("updater", Path(__file__).parents[1] / "update_taiwan_holidays.py")
updater = importlib.util.module_from_spec(spec)
spec.loader.exec_module(updater)


def calendar_csv(year=2026):
    date = dt.date(year, 1, 1)
    rows = ["西元日期,星期,是否放假,備註"]
    while date.year == year:
        name = "春節" if date.month == 2 and date.day in range(16, 26) else ""
        if date.month == 1 and date.day == 1:
            name = "開國紀念日"
        flag = "2" if name or date.weekday() >= 5 else "0"
        rows.append(f"{date:%Y%m%d},,{flag},{name}")
        date += dt.timedelta(days=1)
    return ("\ufeff" + "\n".join(rows)).encode("utf-8")


class CalendarTests(unittest.TestCase):
    def test_weekends_workdays_and_named_weekend_holidays(self):
        data = calendar_csv().replace(b"20260221,,2,", b"20260221,,0,")
        holidays = updater.parse_calendar(data, 2026)
        dates = [row[0] for row in holidays]
        self.assertIn(dt.date(2026, 2, 22), dates)  # Named holiday on Sunday.
        self.assertNotIn(dt.date(2026, 2, 21), dates)  # Working Saturday.
        self.assertNotIn(dt.date(2026, 1, 3), dates)  # Ordinary weekend.
        self.assertEqual(holidays[0][2], "New Year's Day")

    def test_incomplete_duplicate_and_wrong_year_fail(self):
        data = calendar_csv()
        for invalid in (b"\n".join(data.splitlines()[:-1]),
                        data.replace(b"20261231", b"20261230"),
                        data.replace(b"20261231", b"20271231")):
            with self.subTest(invalid=invalid[-50:]), self.assertRaises(ValueError):
                updater.parse_calendar(invalid, 2026)

    def test_unknown_translation_flag_and_unnamed_weekday_fail(self):
        for invalid in (calendar_csv().replace("開國紀念日".encode(), "新節日".encode()),
                        calendar_csv().replace(b"20260101,,2", b"20260101,,1"),
                        calendar_csv().replace(b"20260102,,0", b"20260102,,2")):
            with self.assertRaises(ValueError):
                updater.parse_calendar(invalid, 2026)

    def test_leap_year_and_legacy_encoding(self):
        data = calendar_csv(2024).decode("utf-8-sig").encode("cp950")
        self.assertEqual(11, len(updater.parse_calendar(data, 2024)))

    def test_revision_selection_skips_google_format(self):
        def resource(description, filename):
            return {"resourceDescription": description, "resourceFormat": "CSV",
                    "resourceDownloadUrl": "https://www.dgpa.gov.tw/" + filename}
        metadata = {"success": True, "result": {"distribution": [
            resource("114年辦公日曆表", "original.csv"),
            resource("114年辦公日曆表(1141020更新)", "revised.csv"),
            resource("114年辦公日曆表_Google行事曆專用", "google.csv"),
            resource("115年辦公日曆表", "next.csv"),
        ]}}
        self.assertEqual({2025: "https://www.dgpa.gov.tw/revised.csv",
                          2026: "https://www.dgpa.gov.tw/next.csv"}, updater.resources(metadata))

    def test_empty_and_untrusted_resources_fail(self):
        for metadata in (
            {"success": False},
            {"success": True, "result": {"distribution": []}},
            {"success": True, "result": {"distribution": [{
                "resourceDescription": "115年辦公日曆表", "resourceFormat": "CSV",
                "resourceDownloadUrl": "https://example.com/calendar.csv",
            }]}},
        ):
            with self.assertRaises(ValueError):
                updater.resources(metadata)

    def test_combined_holidays_have_distinct_ids_and_observed_dates(self):
        entries = updater.specifications(2024, [
            (dt.date(2024, 4, 4), "兒童節及民族掃墓節", "Children's Day and Tomb-Sweeping Day"),
            (dt.date(2024, 4, 5), "補假", "Substitute Holiday"),
        ])
        by_id = {entry[1]: entry for entry in entries}
        self.assertEqual(dt.date(2024, 4, 5), by_id["CHILDRENSDAY-01"][4])
        self.assertEqual(dt.date(2024, 4, 4), by_id["TOMBSWEEPINGDAY-01"][4])
        self.assertEqual(2, len(entries))

    def test_unknown_substitute_fails_instead_of_guessing(self):
        with self.assertRaisesRegex(ValueError, "Review the substitute"):
            updater.specifications(2028, [(dt.date(2028, 3, 1), "補假", "Substitute Holiday")])

    def test_missing_published_substitute_fails(self):
        with self.assertRaisesRegex(ValueError, "not published"):
            updater.specifications(2026, [(dt.date(2026, 2, 28), "和平紀念日", "Peace Memorial Day")])

    def test_cross_year_substitute_keeps_calendar_year(self):
        entries = updater.specifications(2027, [(dt.date(2027, 12, 31), "補假", "Substitute Holiday")])
        self.assertEqual("NEWYEARSDAY-SUBSTITUTE-01", entries[0][1])
        self.assertEqual(dt.date(2027, 12, 31), entries[0][0])

    def test_previous_year_observation(self):
        entries = updater.specifications(2022, [(dt.date(2022, 1, 1), "開國紀念日", "New Year's Day")])
        self.assertEqual(dt.date(2021, 12, 31), entries[0][4])


if __name__ == "__main__":
    unittest.main()
