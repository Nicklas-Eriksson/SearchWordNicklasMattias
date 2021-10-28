using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchWordNicklasMattias
{
    //Alla meningar med hits
    public class Node
    {
        public List<Node> nodeList = new List<Node>();
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
            foreach (var node in nodeList)
            {
                Console.WriteLine(node.Data);
            }
        }

        public Node Root;

        public void AddNode(string result)
        {
            var fillNode = new Node();
            fillNode.Data = result;

            Node currentNode = Root;

            if (currentNode == null)
            {
                currentNode = fillNode;
            }
            else
            {
                Node parentNode;

                while (true)
                {
                    parentNode = currentNode;
                    if (currentNode.Left == null)
                    {
                        currentNode.Left = fillNode;
                        break;
                    }
                    else if (currentNode.Right == null)
                    {
                        currentNode.Right = fillNode;
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.Left;
                        if (currentNode == null)
                        {
                            parentNode.Left = fillNode;
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.Right;
                            parentNode.Right = fillNode;
                            break;
                        }
                    }
                }
                nodeList.Add(currentNode);
            }
        }
    }
}
