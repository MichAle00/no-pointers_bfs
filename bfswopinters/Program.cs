namespace bfswopointers;

class Program
{
    class Node<T>
    {
        internal Node<T> Left { get; set; }
        internal Node<T> Right { get; set; }
        internal Node<T> Parent { get; set; }
        internal T Data { get; set; }


        internal Node(T data, Node<T> parent)
        {
            Data = data;
            Parent = parent;
            Left = null;
            Right = null;
        }
    }

    class Tree<X>
    {
        internal Node<X> Root { get; set; }
        private Random count = new Random();

        public bool Insert(X data)
        {
            return Insert(data, Root, Root);
        }
        
        private bool Insert(X data, Node<X> node, Node<X> parent)
        {
            if (Root == null)
            {
                Root = new Node<X>(data, parent);
                return true;
            }

            if (data == null) return false;

            if (count.Next() % 2 == 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node<X>(data, node);
                    return true;
                }
                else
                {
                    Insert(data, node.Left, node);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new Node<X>(data, node);
                    return true;
                }
                else
                {
                    Insert(data, node.Right, node);
                }
            }
            return true;
        }

        public void PrintTree()
        {
            PrintTree(Root);
        }

        private void PrintTree(Node<X> node)
        {
            if (node == null) return;
            PrintTree(node.Left);
            PrintTree(node.Right);
            Console.WriteLine(node.Data);
        }

        public void BFS(X data)
        {
            Queue<Node<X>> nodes = new Queue<Node<X>>();
            List<Node<X>> visited = new List<Node<X>>();
            nodes.Enqueue(Root);
            
            do
            {
                Node<X> node = nodes.Dequeue();
                visited.Add(node);
                if (node.Data.Equals(data))
                {
                    Console.WriteLine("The route is: ");
                    for (int i = 0; i < visited.Count; i++)
                    {
                        Console.Write($"{visited[i].Data}");
                        if (i == visited.Count - 1)
                        {
                            break;
                        }
                        Console.Write("->");
                    }

                    return;
                }
                else
                {
                    visited.Append(node);
                    if (node.Left != null)
                    {
                        nodes.Enqueue(node.Left);
                    }
                    
                    if (node.Right != null)
                    {
                        nodes.Enqueue(node.Right);
                    }
                }
            } while (nodes.Count != 0);
            
            Console.WriteLine("Not found");
        }
    }
    
    public static void Main(string[] args)
    {
        Tree<int> tree = new Tree<int>();

        tree.Insert(1);
        tree.Insert(2);
        tree.Insert(3);
        tree.Insert(4);
        tree.Insert(5);
        tree.Insert(6);
        tree.Insert(7);
        tree.Insert(8);
        tree.Insert(9);

        tree.BFS(8);
    }
}