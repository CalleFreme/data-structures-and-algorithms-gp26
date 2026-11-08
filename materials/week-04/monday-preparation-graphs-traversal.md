# Preparation for Tuesday: Graphs and Graph Traversal

**Estimated time: 20–25 minutes**

On Tuesday we will move from hierarchical trees to **general graphs**, then study how **Breadth-First Search (BFS)** and **Depth-First Search (DFS)** explore them.

You do **not** need to know BFS or DFS before the lecture.

> **Important:** Make your predictions before searching for definitions or implementations. The goal is to arrive with a model we can test and refine together.

---

## 1. When a tree is no longer enough

Consider this dungeon:

```text
Entrance -> Hall
Entrance -> StoreRoom
Hall -> Courtyard
StoreRoom -> Courtyard
Courtyard -> Hall
Courtyard -> BossRoom
```

Think about the shape.

1. Can `Courtyard` be reached from more than one place?
2. Can following connections eventually bring us back to a place we have already seen?
3. Does every node have exactly one parent?
4. Does this still behave like the rooted tree structure from Lab 4A?

Write down what is different.

A **graph** allows more general relationships than the tree used in Lab 4A.

---

## 2. Nodes and directed edges

For this preparation, treat:

```text
room = node
one-way connection = directed edge
```

From:

```text
Entrance -> Hall
Entrance -> StoreRoom
Hall -> Courtyard
```

answer:

1. What are the nodes?
2. How many directed edges are shown?
3. If `Hall -> Entrance` is not written, should you assume it exists?
4. If a door works both ways, how could we represent that using directed edges?

---

## 3. First representation: one global edge list

Imagine the graph is stored as:

```text
(Entrance, Hall)
(Entrance, StoreRoom)
(Hall, Courtyard)
(StoreRoom, Courtyard)
(Courtyard, Hall)
(Courtyard, BossRoom)
```

Now answer:

> Which rooms can I go to directly from `Courtyard`?

Describe what a program using only this list would have to inspect.

If the graph contains **100,000 edges**, what repeated work happens every time we ask for the outgoing neighbors of one node?

Do not worry about Big-O notation yet. Describe the work in ordinary language.

---

## 4. Reorganize around the operation

Another representation could prepare the same information like this:

```text
Entrance  -> [Hall, StoreRoom]
Hall      -> [Courtyard]
StoreRoom -> [Courtyard]
Courtyard -> [Hall, BossRoom]
BossRoom  -> []
```

Compare this with the global edge list.

1. Which representation makes the question  
   **"What are Courtyard's outgoing neighbors?"** easier to answer repeatedly?
2. What work must be done up front to build this representation?
3. Does this representation use additional memory?
4. Which idea from Lab 3 does this remind you of?

On Tuesday we will call this an **adjacency representation**.

---

## 5. What happens without remembering where we have been?

Look at:

```text
Hall -> Courtyard
Courtyard -> Hall
```

Imagine an exploration algorithm that simply says:

```text
visit current node
then visit every neighbor
```

but never remembers previous nodes.

Predict what can happen:

```text
Hall
-> Courtyard
-> ?
-> ?
-> ?
```

What information would prevent this?

Which collection from earlier in the course is well suited to repeatedly asking:

> "Have I already discovered this node?"

---

## 6. Two different waiting policies

Suppose we start at `Entrance`.

After processing `Entrance`, these are waiting:

```text
Hall
StoreRoom
```

Then processing `Hall` discovers:

```text
Courtyard
```

Consider two policies.

### Policy A

> Process the candidate that has been waiting the longest.

Which earlier data structure matches this?

```text
?
```

### Policy B

> Process the most recently discovered candidate first.

Which earlier data structure matches this?

```text
?
```

These policies lead to two different graph traversals.

On Tuesday:

```text
Queue → Breadth-First Search
Stack → Depth-First Search
```

---

## 7. Predict BFS by hand

Use this graph:

```text
A -> B
A -> C
B -> D
B -> E
C -> F
```

Start with:

```text
Queue:   [A]
Visited: {A}
```

Assume neighbors are considered left to right.

Without running code, complete the likely processing order:

```text
A, __, __, __, __, __
```

Then think:

> Why does this feel like moving outward one layer at a time?

---

## 8. Predict DFS by hand

Use the same graph:

```text
A -> B
A -> C
B -> D
B -> E
C -> F
```

Now use a stack so that the first listed neighbor is explored first.

Predict a depth-first order beginning:

```text
A, B, ...
```

Do not worry if your exact order differs. Be ready to explain **which item was waiting on the stack at each step**.

---

## 9. Connection to the individual assignment

Frontier Dispatch contains locations and connections, so graph ideas are directly relevant.

However:

> **Do not treat BFS as the assignment's weighted route-finding solution.**

BFS chooses the next node by discovery order.

The assignment's connections have travel costs, so later we need to choose by **smallest known total cost** instead.

That is where Thursday's weighted-path material and the priority queue from Lab 4B connect.

For Tuesday, focus on:

```text
graph representation
neighbors
frontier
visited
BFS
DFS
cycles
reachability
```

> **Stop here.** You are not expected to implement Dijkstra before it is taught.
