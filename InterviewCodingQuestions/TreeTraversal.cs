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

            ////PreOrderDepthFirstTraverse(tree.Root);
            ////Console.WriteLine("====================");

            ////PostOrderDepthFirstTraverse(tree.Root);
            ////Console.WriteLine("====================");

            ////BreadthFirstTraverse(tree.Root);
            ////Console.WriteLine("====================");

            ////FindParentInBinarySearchTree();
            ////Console.WriteLine("====================");

            FindNodeInTree();
            Console.WriteLine("====================");
        }

        /// <summary>
        /// Find specified node in a tree.
        /// </summary>
        public void FindNodeInTree()
        {
            var tree = CreateTree();

            var node = FindNodeInTree(tree, 77);

            Console.WriteLine(node == null ? "Node not found" : "Found node with data " + node.Data);
        }

        /// <summary>
        /// Given a tree and some data, find the node that stores the data.
        /// </summary>
        /// <typeparam name="T">The type of data stored in the tree nodes.</typeparam>
        /// <param name="tree">The tree.</param>
        /// <param name="data">The data which is stored in the node to be found.</param>
        private Node<T> FindNodeInTree<T>(Tree<T> tree, T data) where T: IComparable<T>
        {
            var currentNode = tree.Root;

            while(currentNode != null)
            {
                int compareResult = data.CompareTo(currentNode.Data);

                if (compareResult == 0)
                    return currentNode;
                else if (compareResult < 0)
                    currentNode = currentNode.Left;
                else
                    currentNode = currentNode.Right;
            }

            return null; // not found.
        }

        /// <summary>
        /// Given a node (or the id of the node), find its parent node.
        /// </summary>
        public void FindParentInBinarySearchTree()
        {
            var tree = CreateTree();

            try
            {
                var parentNode = FindParent(tree.Root, new Node<int>(1));
                Console.WriteLine(parentNode == null ? "Specified node is root node." : "Parent node = " + parentNode.Data.ToString());
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Given the root node of a tree and an arbitrary node in the tree, 
        /// find the parent node of the arbitrary node.
        /// This function assumes that the data stored in the nodes are unique (for comparison purposes).
        /// </summary>
        /// <typeparam name="T">The type of data stored in the tree nodes.</typeparam>
        /// <param name="rootNode">The root node</param>
        /// <param name="childNode">The node whose parent needs to be found</param>
        /// <returns>
        /// The parent node. Null is returned if the specified node is the root node (and hence no parent).
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the specified node was not found in the tree.
        /// </exception>
        private Node<T> FindParent<T>(Node<T> rootNode, Node<T> childNode) where T:IComparable<T>
        {
            var currentNode = rootNode;
            Node<T> parentNode = null;

            while (currentNode != null)
            {
                int compareValue = childNode.Data.CompareTo(currentNode.Data);

                // Found node.
                if (compareValue == 0)
                    return parentNode;

                // Decide whether to go down the left subtree or right subtree.
                if (compareValue < 0)
                {
                    parentNode = currentNode;
                    currentNode = currentNode.Left;
                }
                else
                {
                    parentNode = currentNode;
                    currentNode = currentNode.Right;
                }
            }

            if (currentNode == null)
                throw new InvalidOperationException("The specified not is not in the tree.");

            return parentNode;
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
