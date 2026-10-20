# Preparation for Thursday: Algorithmic Growth

**Estimated time: 15–20 minutes**

On Thursday we will begin reasoning more formally about how algorithms behave as the amount of data grows.

You do **not** need to know Big-O notation before the session. This preparation is only about building an intuition for growth.

> **Important:** Do the predictions before searching for definitions or answers. The purpose is to arrive on Thursday with something to compare against.

## 1. One pass through the data

Imagine an algorithm that checks every player exactly once:

```csharp
foreach (Player player in players)
{
    Check(player);
}
```

Complete the table using your best prediction:

| Number of players | Approximate number of `Check` calls |
| ---: | ---: |
| 10 | 10 |
| 20 | ? |
| 100 | ? |
| 1,000 | ? |

**Prediction:** If the number of players doubles, what happens to the amount of work?

Write down your answer before continuing.

## 2. Every item compared with every item

Now imagine an algorithm where every player is compared with every player:

```csharp
for (int i = 0; i < players.Count; ++i)
{
    for (int j = 0; j < players.Count; ++j)
    {
        Compare(players[i], players[j]);
    }
}
```

Complete the table:

| Number of players | Approximate number of `Compare` calls |
| ---: | ---: |
| 10 | 100 |
| 20 | ? |
| 100 | ? |
| 1,000 | ? |

**Prediction:** If the number of players doubles, what happens to the amount of work?

Write down your answer.

## 3. Compare the two

Think briefly about these questions:

1. Which of the two algorithms do you expect to become expensive sooner as the input grows?
2. For a very small number of players, do you expect the difference to matter much? Why or why not?
3. What information would you want before deciding whether an algorithm is “fast enough” in a real game?

## 4. Optional refresher

If arrays, loops, or basic C# collections feel rusty, spend the remaining time reviewing:

- array / `List<T>` indexing;
- `foreach` and `for` loops;
- `List<T>` basics;
- `Dictionary<TKey, TValue>` at a high level.

> **Stop here.** On Thursday we will give these growth patterns names, compare them more carefully, and connect them to searching and sorting.
