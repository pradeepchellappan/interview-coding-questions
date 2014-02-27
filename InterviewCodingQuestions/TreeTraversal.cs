using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCodingQuestions
{
    /// <summary>
    /// Represents a node in a tree.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Node<T>
    {
        /// <summary>
        /// The left node of the current node.
        /// </summary>
        public Node<T> Left { get; set; }

        /// <summary>
        /// The right node of the current node.
        /// </summary>
        public Node<T> Right { get; set; }

        /// <summary>
        /// The data stored in the node.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Initializes a new instance of the Node class.
        /// </summary>
        /// <param name="data">
        /// The data to be stored in the node.
        /// </param>
        public Node(T data) { this.Data = data; }
    }

    /// <summary>
    /// Represents the tree. 
    /// This is really node necessary. Since Node{T} 
    /// is sufficient to represent a tree.
    /// </summary>
    /// <typeparam name="T">
    /// The type of data stored in the tree nodes.
    /// </typeparam>
    class Tree<T>
    {
        /// <summary>
        /// The root node of the tree.
        /// </summary>
        public Node<T> Root { get; set; }
    }

    /// <summary>
    /// Contains methods to traverse the tree in different ways.
    /// </summary>
    class TreeTraversal
    {
        /// <summary>
        /// 
        /// </summary>
        public void TraverseTree()
        {
            var tree = CreateTree();
            
            InOrderDepthFirstTraverse(tree.Root);
            Console.WriteLine("====================");

            PreOrderDepthFirstTraverse(tree.Root);
            Console.WriteLine("====================");

            PostOrderDepthFirstTraverse(tree.Root);
            Console.WriteLine("====================");

            BreadthFirstTraverse(tree.Root);
        }

        /// <summary>
        /// In-order depth-first traversal of a tree.
        /// </summary>
        /// <typeparam name="T">
        /// The type of data stored in the node.
        /// </typeparam>
        /// <param name="node">
        /// The node to be traversed.
        /// </param>
        private void InOrderDepthFirstTraverse<T>(Node<T> node)
        {
            if (node == null)
                return;

            InOrderDepthFirstTraverse(node.Left);
            Console.WriteLine(node.Data);
            InOrderDepthFirstTraverse(node.Right);
        }

        /// <summary>
        /// Pre-order depth-first traversal of a tree.
        /// </summary>
        /// <typeparam name="T">
        /// The type of data stored in the node.
        /// </typeparam>
        /// <param name="node">
        /// The node to be traversed.
        /// </param>
        private void PreOrderDepthFirstTraverse<T>(Node<T> node)
        {
            if (node == null)
                return;

            Console.WriteLine(node.Data);
            PreOrderDepthFirstTraverse(node.Left);
            PreOrderDepthFirstTraverse(node.Right);
        }

        /// <summary>
        /// Post-order depth-first traversal of a tree.
        /// </summary>
        /// <typeparam name="T">
        /// The type of data stored in the node.
        /// </typeparam>
        /// <param name="node">
        /// The node to be traversed.
        /// </param>
        private void PostOrderDepthFirstTraverse<T>(Node<T> node)
        {
            if (node == null)
                return;

            PostOrderDepthFirstTraverse(node.Left);
            PostOrderDepthFirstTraverse(node.Right);
            Console.WriteLine(node.Data);
        }

        /// <summary>
        /// Traverses a tree in breadth-first manner.
        /// </summary>
        /// <typeparam name="T">
        /// The type of data stored in the tree nodes.
        /// </typeparam>
        /// <param name="rootNode">
        /// The root node of the tree.
        /// </param>
        private void BreadthFirstTraverse<T>(Node<T> rootNode)
        {
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(rootNode);

            while(queue.Count != 0)
            {
                var currentNode = queue.Dequeue();
                if (currentNode.Left != null)
                    queue.Enqueue(currentNode.Left);

                if (currentNode.Right != null)
                    queue.Enqueue(currentNode.Right);

                Console.WriteLine(currentNode.Data);
            }
        }

        /// <summary>
        /// Helper method to create a simple tree which looks like this:
        ///         5
        ///       /  \
        ///      3     7
        ///     / \   / \
        ///    1   4 6   8
        /// 
        /// </summary>
        /// <returns></returns>
        private Tree<int> CreateTree()
        {
            
            Node<int> root = new Node<int>(5);
            root.Left = new Node<int>(3);
            root.Right = new Node<int>(7);
            root.Left.Left = new Node<int>(1);
            root.Left.Right = new Node<int>(4);
            root.Right.Left = new Node<int>(6);
            root.Right.Right = new Node<int>(8);

            Tree<int> tree = new Tree<int>();
            tree.Root = root;
            return tree;
        }
    }
}
