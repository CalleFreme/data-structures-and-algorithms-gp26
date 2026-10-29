using System;
using System.Collections.Generic;

namespace DSA.Lab04A
{
    /// <summary>
    /// Recursive algorithms over a rooted hierarchy.
    ///
    /// The key idea is structural recursion:
    /// solve the current node, then apply the same operation to each child subtree.
    /// </summary>
    public static class HierarchyTraversal
    {
        public static int CountNodes<T>(HierarchyNode<T> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            int count = 1;
            foreach (HierarchyNode<T> child in root.Children)
            {
                count += CountNodes(child);
            }

            return count;
        }

        public static bool Contains<T>(HierarchyNode<T> root, T target)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            if (EqualityComparer<T>.Default.Equals(root.Value, target))
            {
                return true;
            }

            foreach (HierarchyNode<T> child in root.Children)
            {
                if (Contains(child, target))
                {
                    return true;
                }
            }

            return false;
        }

        public static IReadOnlyList<T> DepthFirstPreOrder<T>(HierarchyNode<T> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            var result = new List<T>();
            AddPreOrder(root, result);
            return result;
        }

        public static int MaxDepth<T>(HierarchyNode<T> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            int deepestChild = -1;
            foreach (HierarchyNode<T> child in root.Children)
            {
                deepestChild = Math.Max(deepestChild, MaxDepth(child));
            }

            return deepestChild + 1;
        }

        private static void AddPreOrder<T>(HierarchyNode<T> node, List<T> result)
        {
            result.Add(node.Value);

            foreach (HierarchyNode<T> child in node.Children)
            {
                AddPreOrder(child, result);
            }
        }
    }
}
