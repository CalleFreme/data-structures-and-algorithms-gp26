# Friday Clinic — Correctness, Tests and Performance Reasoning

This is a guided clinic, not a new large lab. Work on paper, in pairs, or in a scratch file unless your teacher asks you to edit Lab 1 directly.

## Part 1 — “It worked once” is not a correctness argument

For each implementation below:

1. predict what is wrong;
2. find the smallest input that demonstrates the problem;
3. describe one test that would catch it;
4. only then propose a fix.

### Bug A — the final element disappears

```csharp
public static int LinearSearch(int[] values, int target)
{
    for (int i = 0; i < values.Length - 1; ++i)
    {
        if (values[i] == target)
        {
            return i;
        }
    }

    return -1;
}
```

### Bug B — the initial binary-search range

```csharp
int low = 0;
int high = values.Length;
```

The rest of the binary-search algorithm uses `values[middle]`.

What input/target can expose the problem?

### Bug C — the search range can stop shrinking

```csharp
if (values[middle] < target)
{
    low = middle;
}
else
{
    high = middle - 1;
}
```

Why can this become a problem? Trace a tiny example.

### Bug D — insertion sort cannot move into index 0

```csharp
while (j > 0 && values[j] > valueToInsert)
{
    values[j + 1] = values[j];
    --j;
}
```

Find an array that exposes the bug.

---

## Part 2 — Build a small test set

Suppose you are testing binary search on sorted integer arrays.

Choose a **small but meaningful** set of cases. Your goal is not maximum test count. Your goal is confidence.

Consider:

- empty input;
- one element;
- first element;
- middle element;
- last element;
- missing value below the range;
- missing value between existing values;
- missing value above the range.

Which cases would you definitely keep, and why?

## Part 3 — Read a test

```csharp
[Test]
public void BinarySearch_FindsLastElement()
{
    int[] values = { 2, 5, 8, 12, 16 };

    int result = SearchAlgorithms.BinarySearch(values, 16);

    Assert.That(result, Is.EqualTo(4));
}
```

Identify:

- **Arrange** — what state/input is prepared?
- **Act** — what behavior is executed?
- **Assert** — what claim are we checking?

Then write one additional test using the same structure.

## Part 4 — Big-O versus measurements

Two students benchmark the same algorithms and get different timings.

Student A:

```text
n = 100,000
linear search:  72 us
binary search:   0.10 us
```

Student B:

```text
n = 100,000
linear search: 110 us
binary search:   0.18 us
```

Discuss:

1. Does one result invalidate the other?
2. What could explain the difference?
3. What conclusion is safer: “binary search always takes 0.10 us” or “binary search grows much more slowly with n than linear search on sorted data”?
4. Why do we need both theoretical reasoning and measurements?

## Part 5 — Choose the right claim

Mark each statement as **reasonable**, **too strong**, or **wrong**, and explain briefly.

1. “O(n) means the method takes n milliseconds.”
2. “For a list of five values, a simple linear search can be completely reasonable.”
3. “Binary search is faster, so I should always use it.”
4. “A benchmark can tell me exactly how an algorithm behaves for every machine and input.”
5. “Tests can increase confidence, but a few passing tests do not mathematically prove every possible behavior is correct.”

## End-of-week checkpoint

By the end of Friday, try to be able to answer:

- What is the difference between correctness and performance?
- What is an edge case?
- Why do we test boundaries?
- What does O(n) say, and what does it not say?
- Why does binary search need sorted data?
- Why might we still choose a theoretically slower algorithm for a small/simple problem?
