# Lab 8 — Loading and Query Optimization

## Why this lab?
Fast queries often depend on how data is prepared. If the same raw data is parsed and searched over and over, it can be worth doing more work **once at load time** to make repeated queries cheaper.

In this lab you'll investigate that trade-off: **preparation time and memory vs. repeated-query cost**.

**Connection to Frontier Dispatch:** This reinforces the reasoning behind choosing data representations for frequent location and connection lookups. It also supports the assignment's performance analysis. This quest example is separate from the assignment; do **not** rebuild Frontier Dispatch around these quest classes.

## What you'll work with
- `src/DSA.Lab08.Core/PreparedQuestStore.cs` — the class to improve.
- `src/DSA.Lab08.Core/QuestParser.cs` — converts a raw text line into a `QuestRecord` and counts parse calls.
- `src/DSA.Lab08.Core/QuestRecord.cs` — parsed quest data.
- `src/DSA.Lab08.App/Program.cs` — times preparation and repeated queries.
- `tests/DSA.Lab08.Tests/PreparedQuestStoreTests.cs` — required behavior, including no reparsing after preparation.
- `HINTS.md` — optional implementation clues.

The starter keeps quest records as raw strings such as `Q7|West|8`. Its query methods currently reparse and scan raw lines each time. This makes the **existing answers mostly correct**, but leaves the preparation contract deliberately unimplemented.

## Run the starter
From the directory containing `DSA.Lab08.sln`, run:

```bash
dotnet restore DSA.Lab08.sln
dotnet test DSA.Lab08.sln
dotnet run --project src/DSA.Lab08.App
```

**Expected starting state:** Some tests should pass, while the tests concerning parse-once preparation and repeated queries **should fail**. This is intentional: the tests describe what you are meant to implement. Read the failing assertion rather than changing or deleting the test.

The app prints preparation time, repeated-query time, parser calls, and a checksum. The starter may have a low preparation time because it postpones work until queries; that alone does not make it the better design.

## Work through the investigation

### 1. Understand the existing cost
Inspect `PreparedQuestStore` and follow what happens when `FindById` or `GetByRegion` is called repeatedly.

Ask yourself:
- Which work is repeated unnecessarily?
- What is the cost of searching one ID or one region when there are many records?
- Which part could happen once, before any queries are made?

Run the app and record the preparation and query times, parse count, and checksum. Note the test failures.

### 2. Define what preparation should guarantee
After the store has been constructed:
- each input line should have been parsed **exactly once**;
- `FindById(id)` should return the matching quest, or `null` if it is missing;
- `GetByRegion(region)` should return quests from that region (or an empty collection);
- neither query method should need to parse the raw input again.

Think about how records can be stored for the two different access patterns. The same data may need more than one index. You can use `HINTS.md` if you need guidance.

### 3. Implement the preparation step
Modify **only what is necessary** in `PreparedQuestStore`. Parse and organize the incoming records during construction, then make the query methods use the prepared representation. Preserve the public API and expected results.

### 4. Re-run tests and compare fairly
Run all tests again. The preparation and no-reparsing tests should now pass alongside the correctness tests.

Run the app several times before and after. Compare:
- **Preparation time:** may increase, because work now happens up front.
- **Repeated-query time:** should generally decrease for this workload.
- **Parser calls:** should stop increasing after construction.
- **Checksum:** should remain unchanged.

Do not compare query time alone and declare that one design is always better: the trade-off depends on how often data is queried, the size of the dataset, and the extra memory required for the indexes. For a fairer overall comparison, consider the sum of preparation and query time for this particular workload.

### 5. Explain the trade-off
Write a short explanation using these questions:

| Question | What to discuss |
| --- | --- |
| Original bottleneck | Why did the starter repeat work? |
| New representation | What do you prepare and why does it fit each query? |
| Correctness | Do the tests pass and the results agree? |
| Evidence | What changed in preparation time, query time, and parse count? |
| Trade-off | When is preprocessing worthwhile, and when might it not be? |

## Done when
- [ ] All tests pass, including parse-once and no-reparsing checks.
- [ ] Query methods no longer parse raw quest lines.
- [ ] Missing IDs and empty regions are handled correctly.
- [ ] You have measured both preparation and repeated-query costs.
- [ ] You can explain the memory/preparation vs. query-time trade-off.

## Optional thought experiment: caching and changing data
Suppose computing a region summary is expensive, but quest data never changes. When would caching that summary be safe? What would have to happen to the cache if quests could be added, removed, or changed at runtime?

## Transfer the reasoning to Frontier Dispatch
In the individual assignment, consider which operations happen repeatedly and which data can be organized once. For example, frequent `FindLocationById` calls may suggest direct ID lookup; frequent outgoing-connection queries may suggest storing connections by their source location. Those are **examples of questions to investigate**, not extra required changes or automatic solutions.

If your current assignment representation already supports efficient lookups, **you do not need to rebuild it because of this lab**. Prioritize required correctness, your priority queue, route finding, reachability, and documented evidence. Use preprocessing or additional indexes only when they make sense for your actual workload, and explain their costs as well as their benefits.
