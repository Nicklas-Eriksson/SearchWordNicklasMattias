using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchWordNicklasMattias
{
    public class Tree
    {
        public Node Root;
        public void AddNode(Node Root, Node newNode)
        {
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

        public Node AddNode(string data)
        {
            Node newNode = new Node(data);

            if (Root == null)
            {
                Root = newNode;

            }
            return newNode;
        }

        public void DisplayTree(Node nextNode)
        {
            Node temp;
            temp = nextNode;
            if (temp == null)
                return;
            DisplayTree(temp.Left);
            Console.Write(temp.Data + " ");
            DisplayTree(temp.Right);
        }
    }
}
