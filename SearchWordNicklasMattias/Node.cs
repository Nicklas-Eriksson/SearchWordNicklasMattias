using System;

namespace SearchWordNicklasMattias
{
    public class Node
    {
        public string Data;
        public Node Left, Right;

        public Node(string data)
        {
            this.Data = data;
            Left = null;
            Right = null;

        }

        public Node Root;

    }
}

