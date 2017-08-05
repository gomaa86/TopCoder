using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class BNode
    {
        public BNode Left;
        public BNode Right;
        public int Depth = -1;
        public bool IsLeaf = false;
    }

    class BinaryTreeNode
    {
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }
        public int Data { get; set; }
    }

    class BFS
    {
        private Queue<BinaryTreeNode> _searchQueue;
        private BinaryTreeNode _root;
        public BFS(BinaryTreeNode rootNode)
        {
            _searchQueue = new Queue<BinaryTreeNode>();
            _root = rootNode;
        }

        public bool Search(int data)
        {
            BinaryTreeNode _current = _root;
            _searchQueue.Enqueue(_root);
            while (_searchQueue.Count != 0)
            {
                _current = _searchQueue.Dequeue();
                if (_current.Data == data)
                {
                    return true;
                }
                else
                {
                    _searchQueue.Enqueue(_current.Left);
                    _searchQueue.Enqueue(_current.Right);
                }
            }
            return false;
        }

        public List<LinkedList<BNode>> FindLevelLinkList(BNode root)
        {
            Queue<BNode> q = new Queue<BNode>();
            // List of all nodes starting from root.
            List<BNode> list = new List<BNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                BNode current = q.Dequeue();
                if (current == null)
                    continue;
                q.Enqueue(current.Left);
                q.Enqueue(current.Right);
                list.Add(current);
            }

            // Add tree nodes of same depth into individual LinkedList. Then add all LinkedList into a List
            LinkedList<BNode> LL = new LinkedList<BNode>();
            List<LinkedList<BNode>> result = new List<LinkedList<BNode>>();
            LL.AddLast(root);
            int currentDepth = 0;
            foreach (BNode node in list)
            {
                if (node != root)
                {
                    if (node.Depth == currentDepth)
                    {
                        LL.AddLast(node);
                    }
                    else
                    {
                        result.Add(LL);
                        LL = new LinkedList<BNode>();
                        LL.AddLast(node);
                        currentDepth++;
                    }
                }
            }

            // Add the last linkedlist
            result.Add(LL);
            return result;
        }
    }
}
