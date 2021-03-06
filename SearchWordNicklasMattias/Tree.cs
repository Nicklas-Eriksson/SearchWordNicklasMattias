using System;

namespace SearchWordNicklasMattias
{
    /// <summary>
    /// Abstract data structure for holding search results.
    /// </summary>
    public class Tree
    {
        public Node Root;

        /// <summary>
        /// Adds node with string comparison where that node should be added.
        /// </summary>
        /// <param name="Root">Root node.</param>
        /// <param name="newNode">Next node to be filled.</param>
        public void AddNode(Node Root, Node newNode)
        {
            if (Root == null)
            {
                Root = newNode;
            }

            Node temp;
            temp = Root;

            if (string.Compare(newNode.Data, temp.Data) < 0)
            {
                if (temp.Left == null)
                {
                    temp.Left = newNode;
                }
                else
                {
                    temp = temp.Left;
                    AddNode(temp, newNode);
                }
            }
            else if (string.Compare(newNode.Data, temp.Data) > 0)
            {
                if (temp.Right == null)
                {
                    temp.Right = newNode;
                }
                else
                {
                    temp = temp.Right;
                    AddNode(temp, newNode);
                }
            }
        }

        /// <summary>
        /// creates a new node with overload string.
        /// </summary>
        /// <param name="data">Result.</param>
        /// <returns>Node.</returns>
        public Node AddNode(string data)
        {
            Node newNode = new Node(data);

            if (Root == null)
            {
                Root = newNode;
            }

            return newNode;
        }

        /// <summary>
        /// Prints out the tree in a recursive manner.
        /// Recursion allows for traversion through the tree checking next node and printing out data.
        /// </summary>
        /// <param name="nextNode">Next node.</param>
        public void DisplayTree(Node nextNode)
        {
            Node temp;
            temp = nextNode;
            if (temp == null)
            {
                return;
            }

            DisplayTree(temp.Left);
            Console.Write($"{temp.Data} ");
            DisplayTree(temp.Right);
        }
    }
}
