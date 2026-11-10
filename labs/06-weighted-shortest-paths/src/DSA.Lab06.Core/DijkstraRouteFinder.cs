using System;
using System.Collections.Generic;

namespace DSA.Lab06
{
    public sealed class DijkstraRouteFinder
    {
        public RouteResult FindRoute(WeightedGraph graph, string start, string goal)
        {
            if (graph == null)
            {
                throw new ArgumentNullException(nameof(graph));
            }

            if (!graph.ContainsNode(start) || !graph.ContainsNode(goal))
            {
                return RouteResult.NotFound(0);
            }

            if (start == goal)
            {
                return RouteResult.Success(new[] { start }, 0, 0);
            }

            var bestCost = new Dictionary<string, int>();
            var cameFrom = new Dictionary<string, string>();
            var frontier = new MinFrontier<string>();

            bestCost[start] = 0;
            frontier.Enqueue(start, 0);

            int expandedNodes = 0;

            while (frontier.Count > 0)
            {
                MinFrontier<string>.Entry entry = frontier.Dequeue();
                string current = entry.Value;

                if (!bestCost.TryGetValue(current, out int currentBest) || entry.Priority != currentBest)
                {
                    continue; // stale queue entry: a cheaper route was discovered later
                }

                ++expandedNodes;

                if (current == goal)
                {
                    return BuildSuccess(start, goal, currentBest, expandedNodes, cameFrom);
                }

                foreach (WeightedEdge edge in graph.GetOutgoing(current))
                {
                    int candidate = checked(currentBest + edge.Cost);

                    if (!bestCost.TryGetValue(edge.To, out int known) || candidate < known)
                    {
                        bestCost[edge.To] = candidate;
                        cameFrom[edge.To] = current;
                        frontier.Enqueue(edge.To, candidate);
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
