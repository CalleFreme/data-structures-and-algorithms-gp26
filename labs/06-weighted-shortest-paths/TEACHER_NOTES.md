# Teacher Notes — Lab 6

## Intended starter signal

Supplied tests:

```text
4 passing
7 failing
3 explicit/skipped optional A* tests
```

The four passing tests establish:

- graph adjacency works;
- the supplied min-frontier behaves correctly;
- `start == goal` contract works;
- unknown goal returns not found.

The seven failing tests all depend on the missing Dijkstra loop/reconstruction.

Do not let students interpret them as seven separate TODOs.

---

## Core teaching model

Keep this visible:

```text
BFS
Queue frontier
next = oldest discovered

Dijkstra
min-priority frontier
next = smallest best-known total cost
```

Then add the state Dijkstra needs:

```text
bestCost
cameFrom
```

Do not use a simple permanent `visited` set in exactly the BFS sense. A node can be discovered and later improved before it is finalized.

---

## Key operation: relaxation

Students should be able to say:

```text
candidate = bestCost[current] + edge.Cost

if candidate improves neighbor:
    update bestCost
    update cameFrom
    enqueue improved candidate
```

If they cannot narrate this from a hand-drawn example, they are not ready to debug the implementation.

---

## Stale-entry variant

The supplied `MinFrontier<T>` does not provide decrease-key.

We deliberately teach the common duplicate-entry pattern:

```text
enqueue improved entry
leave old entry in heap
skip old entry later when its priority != bestCost[node]
```

This avoids making decrease-key another implementation topic.

Students may ask whether this is “wasteful”. Answer: yes, it trades some duplicate queue entries for simpler queue semantics; it remains correct and is widely useful when the queue API lacks decrease-key.

---

## Correct stopping rule

Do not stop when the goal is first discovered.

Stop when the goal is dequeued as the current non-stale minimum candidate.

With non-negative edge costs, no later route can then improve it.

---

## Route reconstruction

`bestCost` answers “how much?”

`cameFrom` answers “which route?”

Update `cameFrom[neighbor]` only when the candidate improves the best known cost.

Then backtrack from goal to start and reverse.

---

## Suggested live-code boundary

Recommended:

1. Start from the workshop trace.
2. Show the already supplied dictionaries/frontier initialization.
3. Live-code the `while (frontier.Count > 0)` loop through **stale-entry checking and one relaxation block**.
4. Stop before route reconstruction.
5. Trace reconstruction on the board and let students implement it.

If the room is struggling, also live-code a small private `BuildSuccess` helper.

Do not live-code A*.

---

## Common bugs

### Treating first discovery as final

Symptom: direct expensive edge wins even when a later path is cheaper.

Coach with:

> “What happened to B when it changed from 5 to 4 in the preparation?”

### Using `visited` exactly like BFS

Symptom: student refuses to revisit/update an already discovered node.

Coach with:

> “Discovered is not finalized. What information tells us whether this candidate is better?”

### Wrong priority

Symptom: queue priority is only `edge.Cost` rather than total start-to-neighbor cost.

Coach with:

> “What does the priority represent: this one road, or the whole known route from start?”

### `cameFrom` updated on worse route

Symptom: total cost is right but path reconstruction is wrong.

Coach with:

> “Should predecessor change when the candidate does not improve the best cost?”

### Stop on goal discovery

Symptom: early expensive goal route returned.

Coach with:

> “Can another cheaper frontier candidate still lead to the goal?”

### Stale entries processed

Symptom: expanded count too high, repeated work, or wrong logic if old priority is treated as authoritative.

Coach with:

> “Which value is authoritative now: the queue entry or bestCost?”

---

## Complexity nuance

Textbook binary-heap Dijkstra is commonly stated as:

```text
O((V + E) log V)
```

The supplied lab uses duplicate entries rather than decrease-key. There may be up to O(E) successful relaxation entries in the heap, making a more implementation-specific bound roughly:

```text
O((V + E) log E)
```

For first-year explanations, accept the standard `O((V+E) log V)` when students clearly describe a binary-heap Dijkstra model. For higher-quality analysis, reward students who notice the duplicate-entry implementation detail and state assumptions.

---

## Assignment bridge

The individual assignment requires:

- least-cost route;
- total cost;
- actual reconstructed route;
- start==goal;
- unreachable goal;
- non-negative costs;
- prepared representation;
- useful diagnostic information.

Lab 6A covers the reasoning behind all of those without using the assignment API.

Phase 5 `ReachabilityQuery` should be presented as an adaptation:

```text
Dijkstra computes cheapest reachable costs
+
change stopping/result rule around a max budget
```

Do not introduce it as a completely unrelated algorithm.

---

## Optional A* extension

Only students with a stable Dijkstra should continue.

Core idea:

```text
Dijkstra priority = g
A* priority = g + h
```

Keep `bestCost` as `g`.

The optional blocked-node parameter intentionally previews traversal constraints without matching the assignment API exactly.
