using System;
using System.Collections.Generic;

namespace DSA.Lab06
{
    /// <summary>
    /// Optional Lab 6B extension.
    /// A* keeps the same best-known g-cost as Dijkstra but prioritizes g + h.
    /// g(n) = cheapest cost found so far from start to node n.
    /// h(n) = estimated remaining cost from n to goal (the heuristic).
    /// f(n) = g(n) + h(n), the priority used to choose which node to explore next.
    /// </summary>
    public sealed class AStarRouteFinder
    {
        public RouteResult FindRoute(
            WeightedGraph graph,
            string start,
            string goal,
            // ISet<string> is a set of node IDs. ? allows null; = null makes this argument optional.
            ISet<string>? blocked = null)
        {
            if (graph == null)
            {
                // nameof(graph) produces the parameter name "graph" for the error message.
                throw new ArgumentNullException(nameof(graph));
            }

            // Neither an unknown endpoint nor a blocked endpoint can be part of a route.
            if (!graph.ContainsNode(start) || !graph.ContainsNode(goal))
            {
                return RouteResult.NotFound(0);
            }

            // && short-circuits: Contains is only called if blocked is not null.
            if ((blocked != null && blocked.Contains(start)) ||
                (blocked != null && blocked.Contains(goal)))
            {
                return RouteResult.NotFound(0);
            }

            if (start == goal)
            {
                // new[] lets C# infer a string array: the route contains just the starting node.
                return RouteResult.Success(new[] { start }, 0, 0);
            }

            // Manhattan distance is |x - goal.X| + |y - goal.Y|.
            // For A* to guarantee a cheapest route, h must never overestimate the true
            // remaining cost. Coordinates and edge costs must make Manhattan a valid
            // lower bound; arbitrary weighted graphs do not automatically satisfy this.
            WeightedNode goalNode = graph.GetNode(goal);
            // var asks the compiler to infer the type from the right-hand side; it is still typed.
            // Dictionary<string, int> maps a node ID to its best-known g-cost (often called gScore).
            var bestCost = new Dictionary<string, int>();
            // cameFrom[child] = parent records the previous node on the best route found so far.
            var cameFrom = new Dictionary<string, string>();
            // The frontier is A*'s "open" queue. <string> means its values are node IDs;
            // each entry also has an integer priority, and the smallest priority comes out first.
            var frontier = new MinFrontier<string>();

            // Reaching start costs 0, so its initial f = 0 + h(start).
            bestCost[start] = 0;
            frontier.Enqueue(start, Heuristics.Manhattan(graph.GetNode(start), goalNode));

            int expandedNodes = 0;

            while (frontier.Count > 0)
            {
                // Entry is a type nested inside MinFrontier<string>; it holds Value and Priority.
                MinFrontier<string>.Entry entry = frontier.Dequeue();
                string current = entry.Value;

                // TryGetValue returns a bool saying whether the key exists. The out parameter
                // also gives us the stored value: "out int currentG" declares that variable here
                // and lets the method assign it. A missing key returns false and assigns 0;
                // that 0 is not a known route cost, so ! (logical NOT) makes us skip the entry.
                if (!bestCost.TryGetValue(current, out int currentG))
                {
                    continue;
                }

                // checked(...) throws OverflowException if this integer sum exceeds int's range,
                // instead of wrapping around and potentially making a huge cost look cheap.
                int expectedPriority = checked(currentG + Heuristics.Manhattan(graph.GetNode(current), goalNode));
                // A cheaper route may have been enqueued after this entry. We leave old entries
                // in the queue instead of changing their priorities; discard any whose saved f
                // no longer matches the best g + h. This is the "stale entry" check.
                if (entry.Priority != expectedPriority)
                {
                    continue;
                }

                // ++ adds one. Count entries that pass the stale check, including the goal.
                ++expandedNodes;

                // Stop when the goal is removed as the best valid frontier entry, not when
                // first seen as a neighbor: its first discovered route might be more expensive.
                if (current == goal)
                {
                    return BuildSuccess(start, goal, currentG, expandedNodes, cameFrom);
                }

                // foreach visits each outgoing edge: edge.To is the neighbor and edge.Cost
                // is the cost of moving from current to that neighbor.
                foreach (WeightedEdge edge in graph.GetOutgoing(current))
                {
                    if (blocked != null && blocked.Contains(edge.To))
                    {
                        continue;
                    }

                    // Relax the edge: compare the route through current with the neighbor's
                    // best-known route. candidateG is g(current) + cost(current, neighbor).
                    int candidateG = checked(currentG + edge.Cost);
                    // || short-circuits: if the neighbor has no known cost, accept this first
                    // route without comparing against known (which is 0 when lookup fails).
                    // Otherwise, only a strictly cheaper route updates the records.
                    if (!bestCost.TryGetValue(edge.To, out int known) || candidateG < known)
                    {
                        bestCost[edge.To] = candidateG;
                        cameFrom[edge.To] = current;
                        // Queue by f = g + h, but keep only g in bestCost: h is an estimate,
                        // not a cost actually paid. A later improvement can enqueue this node again.
                        int f = checked(candidateG + Heuristics.Manhattan(graph.GetNode(edge.To), goalNode));
                        frontier.Enqueue(edge.To, f);
                    }
                }
            }

            // An empty frontier means every available route was exhausted without reaching goal.
            return RouteResult.NotFound(expandedNodes);
        }

        // static means this helper needs no AStarRouteFinder instance state; its inputs suffice.
        private static RouteResult BuildSuccess(
            string start,
            string goal,
            int totalCost,
            int expandedNodes,
            Dictionary<string, string> cameFrom)
        {
            // Parent links point backward, so collect goal -> ... -> start first.
            var reversed = new List<string>();
            string current = goal;
            reversed.Add(current);

            while (current != start)
            {
                current = cameFrom[current];
                reversed.Add(current);
            }

            // Reverse the list in place to return start -> ... -> goal. totalCost is the
            // goal's g-cost (the sum of edge costs), not a sum of frontier priorities.
            reversed.Reverse();
            return RouteResult.Success(reversed, totalCost, expandedNodes);
        }
    }
}
