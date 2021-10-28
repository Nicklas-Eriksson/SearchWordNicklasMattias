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

