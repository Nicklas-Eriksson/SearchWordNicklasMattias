using System;

namespace SearchWordNicklasMattias
{
    public class Node
    {
        public string Data;

        public Node Left;
        public Node Right;

        public Node(string res)
        {
            Insert(res);
        }

        public Node()
        {
            Root = null;
        }

        public void Insert(string data)
        {
            this.Data = data;
        }

        public void PrintNode()
        {
            Console.WriteLine(Data);
        }

        public Node Root;

        public void AddNode(string result, Node fillNode)
        {
            fillNode.Data = result;

            var currentNode = Root;

            if (currentNode == null)
            {
                currentNode = fillNode;
            }
            else
            {
                Node parentNode;

                parentNode = currentNode;
                if (currentNode.Left == null)
                {
                    currentNode.Left = fillNode;
                }
                else if (currentNode.Right == null)
                {
                    currentNode.Right = fillNode;
                }
                else
                {
                    currentNode = currentNode.Left;
                    if (currentNode == null)
                    {
                        parentNode.Left = fillNode;
                    }
                    else
                    {
                        currentNode = currentNode.Right;
                        parentNode.Right = fillNode;
                    }
                }
            }
        }
    }
}
