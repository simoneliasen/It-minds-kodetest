using System;
using System.Collections.Generic;

namespace WhatTheFind {

    public static class Extensions {
        /// <summary>
        /// Find any node in an object graph that satisfy a given predicate and return it.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="root">The root node.</param>
        /// <param name="predicate">The given condition to satisfy.</param>
        /// <param name="getChildren">Child selector.</param>
        /// <returns>Node satisfying the condition, else null.</returns>

        public static T FindWhere<T>(this T root, Func<T, bool> predicate, Func<T, IEnumerable<T>> getChildren)
            where T : class
        {

            // if result is found in root return root value
            if (predicate(root))
            {
                return root;
            }

            // Container for the found node
            T nodeFound = null;

            /// Check if the child selector of the root node isn't null
            if (getChildren(root) != null)
            {
                // Traverse the tree in the order A, B, BA, BB, BC, BCA, BCAA
                foreach (var child in getChildren(root))
                {
                    // look for children
                    var returnedVar = FindWhere(child, predicate, getChildren);

                    // if child is found
                    if (returnedVar != null)
                    {
                        nodeFound = returnedVar;
                    }
                }

                // return result
                return nodeFound;
            }
            // if correct value isn't found
            return null;
        }
    }

    public class Node {
        public int Value { get; set; }
        public IEnumerable<Node> Children { get; set; }
    }


    public class Program {
        public static void Main(string[] args)
        {
            // N-ary tree demo
            var nodeBCAA = new Node { Value = 12 };
            var nodeBCAB = new Node { Value = 11 };
            var nodeBCAC = new Node { Value = 10 };
            var nodeBCA = new Node { Value = 9, Children = new List<Node> { nodeBCAA, nodeBCAB, nodeBCAC } };
            var nodeBCB = new Node { Value = 8 };
            var nodeBCC = new Node { Value = 7 };
            var nodeBC = new Node { Value = 6, Children = new List<Node> { nodeBCA, nodeBCB, nodeBCC } };
            var nodeBB = new Node { Value = 5 };
            var nodeBA = new Node { Value = 4 };
            var nodeC = new Node { Value = 3 };
            var nodeB = new Node { Value = 2, Children = new List<Node> { nodeBA, nodeBB, nodeBC } };
            var nodeA = new Node { Value = 1 };
            var root = new Node { Value = 0, Children = new List<Node> { nodeA, nodeB, nodeC } };

            // Run search
            var nodeSearch = root.FindWhere(x => x.Value == 12, x => x.Children);


            // Check for null value
            if (nodeSearch is null)
            {
                Console.WriteLine("Node was not present in tree");
            }
            else
            {
                Console.WriteLine($"Found the node with value: {nodeSearch.Value}");
            }

            Console.ReadLine();

        }



    }
}
