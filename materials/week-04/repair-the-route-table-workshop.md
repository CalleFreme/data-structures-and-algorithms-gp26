# Week 4 Group Exercise — Repair the Route Table

**Groups:** 3–4  
**Time:** about 30 minutes  
**Rule:** do not jump from the graph to the final route. Show the frontier and updates.

## Weighted graph

```text
S --4--> A --1--> C --3--> G
|         \        \
1          7        3
v           \        v
B --2------> A        G
| \
5  12
|    \
v     v
C     G
```

Use this exact edge list if the drawing is unclear:

```text
S -> A : 4
S -> B : 1
B -> A : 2
B -> C : 5
B -> G : 12
A -> C : 1
A -> G : 7
C -> G : 3
```

All edge costs are non-negative.

---

## Part A — Initial state

Start at `S`.

Fill in:

```text
best known costs:
S = ____
A = ____
B = ____
C = ____
G = ____

frontier:
________________________
```

Which node must be removed first?

---

## Part B — Process S

Relax the outgoing edges from `S`.

Complete:

| Neighbor | Old best | Candidate through S | Update? | cameFrom |
|---|---:|---:|---|---|
| A | ∞ | 0 + 4 = ___ | | |
| B | ∞ | 0 + 1 = ___ | | |

Then write the frontier in priority order:

```text
________________________________________
```

Which node is next?

---

## Part C — The important update

Process `B`.

For each outgoing edge from B, calculate the candidate cost.

| Neighbor | Old best | Candidate through B | Update? | New best |
|---|---:|---:|---|---:|
| A | 4 | 1 + 2 = ___ | | |
| C | ∞ | 1 + 5 = ___ | | |
| G | ∞ | 1 + 12 = ___ | | |

Question:

> `A : 4` may already be sitting in the priority queue. After finding `A : 3`, what can we do if our queue does not support decrease-key?

Write your answer:

____________________________________________________________________

---

## Part D — Continue the trace

Continue until `G` can be finalized.

Use this table. Add rows if needed.

| Step | Removed candidate | Stale? | Important relaxation/update | Frontier after step |
|---:|---|---|---|---|
| 0 | — | — | start S = 0 | S:0 |
| 1 | | | | |
| 2 | | | | |
| 3 | | | | |
| 4 | | | | |
| 5 | | | | |
| 6 | | | | |

Record the final best cost to G:

```text
G = ______
```

---

## Part E — Reconstruct the route

Write the final predecessor links that matter:

```text
cameFrom[A] = ______
cameFrom[C] = ______
cameFrom[G] = ______
```

Start at `G` and follow predecessors backward:

```text
G <- ______ <- ______ <- ______ <- S
```

Reverse that sequence:

```text
S -> ______ -> ______ -> ______ -> G
```

Check the total cost by summing the edges on your reconstructed route.

---

## Part F — Why not stop early?

At some point `G` is first discovered with a relatively expensive cost.

Why is this rule wrong?

> “Stop as soon as the goal is first discovered.”

Write one precise sentence.

---

## Part G — Budget adaptation

Now ignore the specific goal and instead ask:

> Which locations are reachable from `S` with a maximum total cost of **4**?

List them with their cheapest costs:

```text
________________________________________
```

What information from the Dijkstra trace did you reuse?

This is the conceptual bridge to the assignment’s `ReachabilityQuery` phase.

---

## Optional extension — heuristic idea

Assume every node also has a position and `h(n)` estimates the remaining cost from `n` to `G`.

Dijkstra prioritizes:

```text
g(n)
```

A* prioritizes:

```text
g(n) + h(n)
```

Discuss:

1. What would happen if `h(n) = 0` for every node?
2. Why could a useful heuristic reduce the number of expanded nodes?
3. What danger appears if the heuristic overestimates the true remaining cost?

You do not need to implement A* for this exercise.
