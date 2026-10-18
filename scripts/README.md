# Taiwan holiday updates

`python3 scripts/update_taiwan_holidays.py --output /path/to/main/src/Nager.Date/HolidayProviders/TaiwanHolidayProvider.cs` downloads [DGPA dataset 14718](https://data.gov.tw/dataset/14718)
through its metadata API, selects the last published non-Google CSV resource for
each year (including revisions), and regenerates `TaiwanHolidayProvider.cs`.
Python 3.11+ and its standard library are sufficient. No API key is required.

The holiday PR data covers 2017–2027. The library uses this data offline and
returns no holidays for unpublished years. These are government administrative
office calendars: private employers and sector-specific holidays may differ.
Ordinary weekends, military-only holidays and compensatory working days are not
returned as public holidays. Named holidays on weekends retain their original
`Date`; published substitute dates are represented by `ObservedRuleSet` and
exposed as `ObservedDate`. Children's Day and Tomb-Sweeping Day remain separate
holidays even when their dates overlap. A December 31 substitute for the next
year's New Year's Day remains an explicit entry in that year's calendar.
Adjusted days off remain separate entries. The standard weekend provider does
not model working Saturdays. IDs use holiday names with per-holiday indices,
including separate indices for the three days of Lunar New Year.

The output is a single `TaiwanHolidayProvider` containing annual
`HolidaySpecification` arrays, matching the provider's existing source format.
It does not use an auto-generated marker or a tuple dictionary. Substitute-date
relationships are reviewed in `OBSERVED_DATES`; an unrecognized substitute date
stops generation for review instead of guessing which holiday it belongs to.

The updater rejects incomplete calendars, duplicate dates, unknown translations,
unknown flags and removal of previously published years before writing output.
New holiday names require an English translation in the script; the workflow
fails for review instead of guessing. Data is licensed under the
[Government Data Open License, version 1.0](https://data.gov.tw/license).

The **Update Taiwan holidays** workflow runs only when manually triggered through
**Actions → Update Taiwan holidays → Run workflow**. It tests the script and
downloads the published calendars. If generated data is unchanged, it finishes
without creating a branch or PR. If data changes, it tests the .NET solution,
then creates or updates the PR branch and a single PR targeting `main`.

The workflow and scripts live on the `script` branch. Each run checks out `main`
into `source/` and the triggered script commit into `updater/`. Only generated
calendar changes from `source/` are committed to the PR branch; scripts are not
included in that PR. `TAIWAN_PR_BRANCH` (repository Actions variable) defaults to
`automation/update-taiwan-holidays`. The initial Taiwan provider PR must be merged
into `main` before calendar-only updates can run.

GitHub requires a `workflow_dispatch` workflow to exist on the default branch
before it can be manually dispatched, even with `--ref script`. Keeping `main`
completely unchanged means this workflow is prepared on `script` but manual
Actions dispatch is not enabled yet. If a minimal dispatch workflow is later
allowed on `main`, select `script` when triggering this workflow.

In **Settings → Actions → General → Workflow permissions**, enable **Allow GitHub
Actions to create and approve pull requests**. No custom token is required.
Because PRs created with `GITHUB_TOKEN` do not trigger the usual PR workflow,
.NET tests run before PR creation in this workflow.

Run updater tests offline with:

```sh
python3 -m unittest discover -s scripts/tests -v
```
