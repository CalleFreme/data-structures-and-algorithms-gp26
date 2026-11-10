using System;
using System.Collections.Generic;

namespace DSA.Lab06
{
    /// <summary>
    /// Optional Lab 6B extension.
    /// A* keeps the same best-known g-cost as Dijkstra but prioritizes g + h.
    /// </summary>
    public sealed class AStarRouteFinder
    {
        public RouteResult FindRoute(
            WeightedGraph graph,
            string start,
            string goal,
            ISet<string>? blocked = null)
        {
            if (graph == null)
            {
                throw new ArgumentNullException(nameof(graph));
            }

            if (!graph.ContainsNode(start) || !graph.ContainsNode(goal))
            {
                return RouteResult.NotFound(0);
            }

            if ((blocked != null && blocked.Contains(start)) ||
                (blocked != null && blocked.Contains(goal)))
            {
                return RouteResult.NotFound(0);
            }

            if (start == goal)
            {
                return RouteResult.Success(new[] { start }, 0, 0);
            }

            WeightedNode goalNode = graph.GetNode(goal);
            var bestCost = new Dictionary<string, int>();
            var cameFrom = new Dictionary<string, string>();
            var frontier = new MinFrontier<string>();

            bestCost[start] = 0;
            frontier.Enqueue(start, Heuristics.Manhattan(graph.GetNode(start), goalNode));

            int expandedNodes = 0;

            while (frontier.Count > 0)
            {
                MinFrontier<string>.Entry entry = frontier.Dequeue();
                string current = entry.Value;

                if (!bestCost.TryGetValue(current, out int currentG))
                {
                    continue;
                }

                int expectedPriority = checked(currentG + Heuristics.Manhattan(graph.GetNode(current), goalNode));
                if (entry.Priority != expectedPriority)
                {
                    continue;
                }

                ++expandedNodes;

                if (current == goal)
                {
                    return BuildSuccess(start, goal, currentG, expandedNodes, cameFrom);
                }

                foreach (WeightedEdge edge in graph.GetOutgoing(current))
                {
                    if (blocked != null && blocked.Contains(edge.To))
                    {
                        continue;
                    }

                    int candidateG = checked(currentG + edge.Cost);
                    if (!bestCost.TryGetValue(edge.To, out int known) || candidateG < known)
                    {
                        bestCost[edge.To] = candidateG;
                        cameFrom[edge.To] = current;
                        int f = checked(candidateG + Heuristics.Manhattan(graph.GetNode(edge.To), goalNode));
                        frontier.Enqueue(edge.To, f);
                    }
                }
            }

            return RouteResult.NotFound(expandedNodes);
        }

        private static RouteResult BuildSuccess(
            string start,
            string goal,
            int totalCost,
            int expandedNodes,
            Dictionary<string, string> cameFrom)
        {
            var reversed = new List<string>();
            string current = goal;
            reversed.Add(current);

            while (current != start)
            {
                current = cameFrom[current];
                reversed.Add(current);
            }

            reversed.Reverse();
            return RouteResult.Success(reversed, totalCost, expandedNodes);
        }
    }
}
