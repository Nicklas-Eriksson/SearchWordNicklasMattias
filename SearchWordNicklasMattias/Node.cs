namespace SearchWordNicklasMattias
{
    public class Node
    {
        public string Data;
        public Node Left, Right;
        public Node Root;

        public Node(string data)
        {
            this.Data = data;
            Left = null;
            Right = null;

        }
    }
}

