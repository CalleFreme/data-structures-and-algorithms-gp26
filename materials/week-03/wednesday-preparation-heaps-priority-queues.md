# Preparation for Thursday: Binary Heaps and Priority Queues

**Estimated time: 20–25 minutes**

On Thursday we will study **priority queues** and **binary min-heaps**, then apply them in **Lab 4B — Priority Queue**.

This connects directly to the “cheapest waiting candidate” problem from the Frontier Dispatch workshop.

You do **not** need to know how a heap works before the lecture.

> **Important:** Work from the required operations first. Do not search for “heap implementation” before making your predictions.

## 1. The waiting-candidate problem

Suppose a pathfinding-like system has discovered these candidates:

```text
Candidate    Current total cost
A            12
B             4
C             9
D             6
```

The rule is:

> Always process the candidate with the smallest current cost next.

Answer:

1. Which candidate should be processed first?
2. After it is taken out of the waiting collection, which candidate should be next?
3. If a new candidate `E` with cost `3` is added, which candidate should now be next?

The important collection operations are:

```text
Add(candidate, cost)
PeekCheapest()
TakeCheapest()
Count
```

## 2. First representation: unsorted List

Suppose the waiting candidates are stored as:

```text
[A:12, B:4, C:9, D:6]
```

and new candidates are simply appended.

Predict the cost of these operations as the collection grows:

| Operation | What work is needed? | Prediction |
| --- | --- | --- |
| Add a new candidate | append to end | cheap / expensive? |
| Peek at the cheapest | ? | cheap / expensive? |
| Take the cheapest | ? | cheap / expensive? |

For `TakeCheapest`, describe what the program must do before it knows which candidate to remove.

## 3. Second representation: always keep it sorted

Now imagine maintaining:

```text
[B:4, D:6, C:9, A:12]
```

Then we add:

```text
E:7
```

The collection should become:

```text
[B:4, D:6, E:7, C:9, A:12]
```

Answer:

1. Why is finding the cheapest candidate now easy?
2. What work may be needed when inserting `E:7`?
3. Which representation makes **insertion** easier?
4. Which representation makes **finding the minimum** easier?

The point is not to decide that one List strategy is “bad”. It is to notice that each organizes the cost differently.

## 4. A tree-shaped compromise

Consider these priorities:

```text
4, 6, 9, 12, 7
```

They can be drawn as:

```text
        4
      /        6     9
    /    12  7
```

Check only this rule:

> Every parent has a priority less than or equal to its children.

Answer:

1. Is `4 <= 6` and `4 <= 9`?
2. Is `6 <= 12` and `6 <= 7`?
3. Is the whole structure globally sorted from left to right?
4. Where is the smallest value guaranteed to be?

This rule is the central **min-heap invariant**.

A heap does **not** promise that every value is globally sorted. It promises enough ordering to make a particular operation cheap.

## 5. Tree shape vs heap rule

Compare:

### Shape A

```text
        2
      /        5     7
    / \   /
   9  8  10
```

### Shape B

```text
        2
      /        5     7
      \            8    10
```

Without searching for the formal definition, which one looks easier to store compactly level-by-level in an array?

Why?

On Thursday we will formalize this as the **complete binary tree** shape used by a binary heap.

## 6. From tree to array

Take:

```text
        4
      /        6     9
    /    12  7
```

Store it level by level:

```text
Index:  0  1  2  3  4
Value:  4  6  9 12  7
```

Answer:

1. At what index is the root?
2. Which indices contain the children of index `0`?
3. Which indices contain the children of index `1`?
4. Can you see a numerical pattern?

Optional challenge: predict formulas for the left child, right child and parent of index `i`.

Do not worry if you cannot. We will derive them together.

## 7. Predict what insertion must repair

Start with this valid min-heap:

```text
        4
      /        6     9
    /    12  7
```

Now add priority `3`.

Because the tree shape must remain compact, imagine placing it at the next open position:

```text
        4
      /        6     9
    / \   /
   12  7  3
```

What rule is now broken?

What general kind of action could repair it?

You do **not** need to know the final algorithm name yet. Describe the idea in ordinary language.

## 8. Assignment connection

The Frontier Dispatch assignment eventually asks you to implement your own:

```text
MinPriorityQueue<T>
```

as a binary min-heap.

Do **not** jump directly to that implementation as preparation.

Thursday's Lab 4B uses a different class/domain so you can first understand:

```text
required operation
→ priority queue abstraction
→ heap representation
→ invariant
→ repair after insertion/removal
→ complexity
```

Then you will transfer that understanding to the assignment contract yourself.

> **Stop here.** On Thursday we will derive the array-index formulas, trace sift-up and sift-down, explain why heap height is logarithmic, and connect the structure to the assignment's Phase 3.
