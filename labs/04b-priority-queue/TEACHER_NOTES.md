# Teacher Notes - Lab 4B

## Intended starter state

- 10 supplied tests total.
- 3 pass: linear baseline, empty Count, peek-on-empty.
- 7 fail because heap mutation methods are incomplete.

## Core teaching target

Keep the abstraction layers explicit:

```text
pathfinding/work scheduler needs "cheapest next"
→ priority queue is the behavior/API
→ binary min-heap is one representation implementing it
```

Connect to Lab 4A without implying heaps use linked nodes. The logical heap is a complete binary tree; the implementation deliberately stores it in a List.

## Key invariant

```text
parent priority <= child priority
```

Do not require global sorting.

## Expected complexity

```text
Linear baseline:
Enqueue O(1) amortized
Peek/Dequeue minimum O(n)

Binary min-heap:
Enqueue O(log n)
Peek minimum O(1)
Dequeue minimum O(log n)
```

## Common bugs

- forgetting the single-item dequeue case;
- using the larger child during sift-down;
- continuing past a leaf;
- incrementing/decrementing Count separately even though `List.Count` is authoritative;
- expecting equal priorities to be stable;
- testing whether the List is sorted rather than whether the heap invariant holds.

## Suggested live-code boundary

Trace one sift-up on the board and optionally implement `Enqueue` + `SiftUp`. Let students complete `DequeueNext` + `SiftDown` themselves.
