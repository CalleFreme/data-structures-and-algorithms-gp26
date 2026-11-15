# Week 5 Monday — Debug the Pathfinder and Guide the Search

**Time:** about 35 minutes  
**Groups:** 3–4

Students already completed **Repair the Route Table** last Thursday. This exercise is different: diagnose broken reasoning/code and make the smallest correct repair.

## Part A — The wrong priority

```csharp
foreach (WeightedEdge edge in graph.GetOutgoing(current))
{
    int candidate = currentBest + edge.Cost;
    if (!bestCost.TryGetValue(edge.To, out int known) || candidate < known)
    {
        bestCost[edge.To] = candidate;
        cameFrom[edge.To] = current;
        frontier.Enqueue(edge.To, edge.Cost); // ???
    }
}
```

1. What is wrong?
2. Give a small graph where it can matter.
3. What should the priority represent?

## Part B — BFS-style visited logic

```csharp
if (visited.Add(edge.To))
{
    bestCost[edge.To] = candidate;
    cameFrom[edge.To] = current;
    frontier.Enqueue(edge.To, candidate);
}
```

Suppose `A -> B` costs 5, `A -> C` costs 2, and `C -> B` costs 2. Explain precisely what goes wrong.

## Part C — Predecessor drift

```csharp
int candidate = currentBest + edge.Cost;
cameFrom[edge.To] = current;

if (!bestCost.TryGetValue(edge.To, out int known) || candidate < known)
{
    bestCost[edge.To] = candidate;
    frontier.Enqueue(edge.To, candidate);
}
```

How could the final total cost be correct while the reconstructed route is wrong? Where should the `cameFrom` update move?

## Part D — Goal discovered too early

```csharp
if (edge.To == goal)
{
    return BuildSuccess(...); // immediately when first discovered
}
```

Use `S -> G = 12`, `S -> A = 2`, `A -> B = 2`, `B -> G = 2`. Explain why the rule is wrong and state the safe stopping rule used in this course.

## Part E — A* on a small grid

Grid movement: 4 directions, cost 1 per move. `#` is blocked.

```text
S . . . . . .
. . # # . . .
. . . # . . .
. . . . . . .
. . . . . . G
```

Use Manhattan distance:

```text
h(n) = |x_goal - x| + |y_goal - y|
```

After expanding `S=(0,0)`, the frontier contains `(1,0)` and `(0,1)`.

1. Calculate `g`, `h`, and `f=g+h` for both.
2. Which one does A* prefer? If tied, explain what that means.
3. What stays the same between Dijkstra and A*?
4. What changes?
5. What happens if `h=0` everywhere?
