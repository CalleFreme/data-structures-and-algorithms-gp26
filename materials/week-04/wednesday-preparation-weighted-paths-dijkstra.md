# Preparation for Thursday: Weighted Paths and Dijkstra

**Estimated time: 20–25 minutes**

On Tuesday we explored an **unweighted** graph using BFS and DFS.

On Thursday the graph changes in one important way:

> Different connections can have different travel costs.

That means discovery order is no longer enough to answer:

> “What is the cheapest route?”

You are **not expected to know or implement Dijkstra before Thursday**. The goal of this preparation is to make a few predictions that we can test and formalize together.

---

## 1. Retrieve Tuesday’s graph-search pattern

From Lab 5, we separated three things:

```text
graph representation
+
frontier
+
visited / discovered information
```

And the frontier policy changed the traversal:

```text
BFS -> Queue -> oldest discovered next
DFS -> Stack -> newest discovered next
```

Write one sentence answering:

> What does the frontier represent?

Do this before reading on.

---

## 2. Fewest edges is not always cheapest

Consider this weighted graph:

```text
A --10--> G
\
 2
  \
   B --2--> C --2--> G
```

There are two routes from `A` to `G`:

```text
A -> G
A -> B -> C -> G
```

Before calculating anything, predict:

1. Which route uses fewer edges?
2. Which route has the lower total cost?
3. Would ordinary BFS necessarily choose the route with the lowest **travel cost**?

Then calculate both totals.

The important distinction is:

```text
fewest edges
!=
lowest total edge cost
```

---

## 3. A better route can be discovered later

Now consider:

```text
A --5--> B
|
2
v
C --2--> B
```

Starting at `A`:

- the direct route gives a current known cost to `B` of `5`;
- reaching `C` costs `2`;
- going from `C` to `B` costs another `2`.

Fill this in:

```text
old known cost to B = ____
new candidate via C = ____ + ____ = ____
```

Then answer:

> If the new candidate is cheaper, what should our algorithm do with the old value for B?

On Thursday we will give this comparison/update operation a name: **relaxation**.

For now, remember the idea:

```text
candidate = cost to current + edge cost

if candidate < best cost known for neighbor:
    update the best cost
```

---

## 4. Which waiting candidate should be processed next?

Suppose our current frontier contains:

```text
B : 5
C : 2
D : 8
```

The number is the best total cost we currently know from the start to that candidate.

Which one should be processed next if our goal is to discover least-cost routes?

Write your answer before continuing.

This should connect directly to Lab 4B:

```text
need the smallest current priority next
-> priority queue
```

So compare:

```text
BFS
frontier = Queue
next = oldest discovered

Dijkstra
frontier = min-priority queue
next = smallest known total cost
```

---

## 5. Do not confuse “discovered” with “finished”

Suppose we discover `B` with cost `5`, so we add:

```text
B : 5
```

Later we find a better route and add:

```text
B : 4
```

A simple priority queue may now contain **both** entries temporarily.

Predict what should happen when the old `B : 5` entry eventually reaches the front.

Choose one:

A. Process B again using cost 5.  
B. Ignore the old entry because we already know a better cost.  
C. Reset B’s best cost back to 5.

Be ready to explain your choice.

This is one practical way to implement Dijkstra when the priority queue does not support a special “decrease priority” operation.

---

## 6. How could we reconstruct the actual route?

Knowing only:

```text
best cost to G = 17
```

is not enough if the game needs to show the route.

Suppose every time we improve a node, we also remember:

```text
cameFrom[child] = current
```

For example:

```text
cameFrom[B] = A
cameFrom[D] = B
cameFrom[G] = D
```

Starting at `G`, how could you recover:

```text
A -> B -> D -> G
```

Hint: follow the links **backward**, then reverse the result.

---

## 7. When should the search stop?

Imagine we first **discover** the goal with total cost 12.

But another frontier candidate has total cost 7 and might lead to a cheaper route to the goal.

Should we stop immediately when the goal is first discovered?

Write **yes or no**, with one sentence explaining why.

On Thursday we will distinguish:

```text
goal discovered
vs
goal removed from the priority queue with its current best cost
```

---

## 8. Why non-negative edge costs matter

Dijkstra’s reasoning relies on connection costs being non-negative.

You do not need to prove this formally, but think about this question:

> If a route could contain a later edge with cost `-100`, could a node that currently looks cheapest become much cheaper only after taking an apparently expensive detour?

The Frontier Dispatch assignment uses **non-negative connection costs**, which is the setting we will use.

---

## 9. Connection to Frontier Dispatch

The assignment’s route-finding phase requires you to implement Dijkstra using:

- your prepared world representation;
- your own `MinPriorityQueue<T>`;
- best-known total costs;
- the actual reconstructed route;
- important edge cases such as `start == goal` and unreachable goals.

Thursday’s Lab 6 uses a **different practice graph and API**. Transfer the reasoning, not the class names.

The intended sequence is:

```text
representation
-> priority queue
-> graph traversal
-> weighted shortest paths
-> adapt the reasoning to travel-budget reachability
```

Do not jump ahead to A* before Dijkstra is correct and explainable.

---

# Optional supplementary reading

These are **not required before Thursday**. They are for students who want another explanation or more depth.

### Practical visual explanation

- **Red Blob Games — Introduction to the A* Algorithm**  
  https://www.redblobgames.com/pathfinding/a-star/introduction.html  
  Excellent interactive explanation of breadth-first search, Dijkstra and A* as related frontier-search strategies.

- **Red Blob Games — Implementation of A***  
  https://www.redblobgames.com/pathfinding/a-star/implementation.html  
  Useful after the lecture if you want to compare implementation patterns. Do not copy it into the assignment; the assignment has its own contracts and required priority queue.

### Historical / advanced reading

- **E. W. Dijkstra — “A note on two problems in connexion with graphs” (1959)**  
  The original short paper behind the algorithm. Interesting historically, but much denser than what you need for this course.

### Production C# comparison

- After you have implemented and understood the course heap, you can also inspect Microsoft’s documentation for `PriorityQueue<TElement, TPriority>` to see what a production standard-library abstraction looks like. The assignment still requires your own heap for its assessed priority-queue phase.

---

## Bring to Thursday

Bring these four predictions:

1. Why BFS is insufficient when edge costs differ.
2. What should happen when a cheaper route to an already discovered node is found.
3. Why Dijkstra wants a min-priority queue.
4. How `cameFrom` information could reconstruct a route.
