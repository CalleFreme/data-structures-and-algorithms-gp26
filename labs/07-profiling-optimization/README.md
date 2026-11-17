# Lab 7 — Profile and Optimize

## Why this lab?
A program can produce the correct answer and still do far more work than necessary. In this lab you will practice **evidence-based optimization**: identify a costly operation, change one thing, and explain the difference using both measurements and reasoning.

**Your goal is not to achieve a particular speedup.** Your goal is to preserve correct behavior and make a credible case for an improvement.

**Connection to Frontier Dispatch:** This is practice for the assignment's performance analysis and before/after evidence. The enemy scanner is a separate example; you do **not** need to copy its classes or optimization into your assignment.

## What you'll work with
- `src/DSA.Lab07.Core/ThreatScanner.cs` — the implementation to investigate and improve.
- `src/DSA.Lab07.Core/Enemy.cs` and `ScanResult.cs` — the input and result types.
- `src/DSA.Lab07.App/Program.cs` — a fixed example workload and a simple elapsed-time measurement.
- `tests/DSA.Lab07.Tests/ThreatScannerTests.cs` — correctness checks.
- `HINTS.md` — optional clues if you get stuck.

The starter is **intentionally inefficient but correct**. It scans enemies repeatedly to total the threat of enemies whose IDs appear in `activeEnemyIds`.

## Run the starter
From the directory containing `DSA.Lab07.sln`, run:

```bash
dotnet restore DSA.Lab07.sln
dotnet test DSA.Lab07.sln
dotnet run --project src/DSA.Lab07.App
```

If the tests pass, you have a correctness baseline. The app prints a threat sum, enemy visits, membership comparisons/checks, and elapsed time. Your times may vary across runs and machines.

## Work through the investigation

### 1. Establish a baseline
Run the tests and the app **several times** before changing anything. Record:
- the workload (enemy count, active ID count, and repetitions from `Program.cs`);
- whether all tests pass;
- the threat sum and the counters;
- several elapsed times (not just the fastest one).

For a fair before/after comparison, leave the workload unchanged. In particular, don't reduce the enemy count or repetitions just to obtain better timings.

### 2. Explain where the work happens
Read `ThreatScanner.Scan` from the outside in. Identify the operation performed for every visited enemy, and ask:
- How much work can it take to decide whether one enemy ID is active?
- How does that cost change as the active ID collection grows?
- Is the current representation well suited to repeated **membership checks**?

Write down your hypothesis *before* changing the code. You do not have to optimize unrelated arithmetic or rewrite the whole scanner.

### 3. Make one justified change
Choose a data representation or preparation step that makes the repeated membership query cheaper. Keep the public behavior and input/output contracts intact. Be able to explain where any setup work occurs and why it is worthwhile for this workload.

### 4. Check correctness and measure again
Run the tests, then repeat the **same** app workload several times. Check that the threat sum and enemy-visit count are unchanged. Compare elapsed times across runs, and explain any remaining variability.

**Important counter detail:** In the starter, `MembershipChecks` counts individual ID comparisons in a linear search. With a different lookup strategy, that counter may measure lookup calls rather than individual comparisons. Those are **not identical units**. Be explicit about what your revised counter counts; use timing plus complexity reasoning, not the raw counter difference alone, as evidence.

### 5. Explain the result
Write a short explanation (roughly 4–6 sentences, or a small before/after table plus explanation):

| Question | What to include |
| --- | --- |
| Baseline | What was repeatedly expensive, and why? |
| Change | What representation or step changed? |
| Correctness | What remained the same? Which tests passed? |
| Evidence | What did repeated measurements show with the same workload? |
| Trade-off | What setup work or extra memory did the change introduce? |

## Done when
- [ ] Tests pass before and after.
- [ ] You can identify the original repeated operation.
- [ ] The improved version returns the same results.
- [ ] You have comparable baseline and improved measurements.
- [ ] You can justify both the improvement and its cost.

## Transfer the method to Frontier Dispatch
Use the same workflow on a **real operation in your assignment**: choose something that matters to your implementation, establish a correct baseline, measure or count meaningful work, make a justified change, test again, and report what the evidence supports. Relevant candidates might involve repeated location/connection lookups or route-related operations **if your implementation and measurements show a bottleneck**.

Do not optimize blindly, change assignment requirements, or assume that the lab's particular data structure is automatically the best choice for Frontier Dispatch. Correctness and a clear explanation come first.
