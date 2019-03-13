using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BST
{
    
    public class BTree<T> : ICollection<T>, IEnumerable<T> where T : IComparable<T>
    {    

       
        public BTree()
        {
            NumberOfNodes = 0;
        }

        public BTree(BNode<T> Root)
        {
            this.Root = Root;
            NumberOfNodes = 0;
        }   
                 
        
        public BNode<T> Root { get; set; }
        
        private int NumberOfNodes { get; set; }
        
        public bool IsEmpty { get { return Root == null; } }
        
        public T MinValue
        {
            get
            {
                if (IsEmpty)
                    throw new Exception("The tree is empty");
                BNode<T> TempNode = Root;
                while (TempNode.Left != null)
                    TempNode = TempNode.Left;
                return TempNode.Value;
            }
        }

        
        public T MaxValue
        {
            get
            {
                if (IsEmpty)
                    throw new Exception("The tree is empty");
                BNode<T> TempNode = Root;
                while (TempNode.Right != null)
                    TempNode = TempNode.Right;
                return TempNode.Value;
            }
        }
        

        public IEnumerator<T> GetEnumerator()
        {
            foreach (BNode<T> TempNode in Traversal(Root))
            {
                yield return TempNode.Value;
            }
        }


        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (BNode<T> TempNode in Traversal(Root))
            {
                yield return TempNode.Value;
            }
        }

        public void Add(T item)
        {
            if (Root == null)
            {
                Root = new BNode<T>(item);
                ++NumberOfNodes;
            }
            else
            {
                Insert(item);
            }
        }

        public void Clear()
        {
            Root = null;
        }

        public bool Contains(T item)
        {
            if (IsEmpty)
                return false;

            BNode<T> TempNode = Root;

            while (TempNode != null)
            {
                int ComparedValue = TempNode.Value.CompareTo(item);
                if (ComparedValue == 0)
                    return true;
                else if (ComparedValue < 0)
                    TempNode = TempNode.Left;
                else
                    TempNode = TempNode.Right;
            }
            return false;
        }        

        public int Count
        {
            get { return NumberOfNodes; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            BNode<T> Item = Find(item);
            if (Item == null)
                return false;
            List<T> Values = new List<T>();
            foreach (BNode<T> TempNode in Traversal(Item.Left))
            {
                Values.Add(TempNode.Value);
            }
            foreach (BNode<T> TempNode in Traversal(Item.Right))
            {
                Values.Add(TempNode.Value);
            }
            if (Item.Parent.Left == Item)
            {
                Item.Parent.Left = null;
            }
            else
            {
                Item.Parent.Right = null;
            }
            Item.Parent = null;
            foreach (T Value in Values)
            {
                this.Add(Value);
            }
            return true;
        }        
        
        private BNode<T> Find(T item)
        {
            foreach (BNode<T> Item in Traversal(Root))
                if (Item.Value.Equals(item))
                    return Item;
            return null;
        }
        
        private IEnumerable<BNode<T>> Traversal(BNode<T> Node)
        {
            if (Node.Left != null)
            {
                foreach (BNode<T> LeftNode in Traversal(Node.Left))
                    yield return LeftNode;
            }
            yield return Node;
            if (Node.Right != null)
            {
                foreach (BNode<T> RightNode in Traversal(Node.Right))
                    yield return RightNode;
            }
        }
                
        private void Insert(T item)
        {
            BNode<T> TempNode = Root;
            bool Found = false;
            while (!Found)
            {
                int ComparedValue = TempNode.Value.CompareTo(item);
                if (ComparedValue < 0)
                {
                    if (TempNode.Left == null)
                    {
                        TempNode.Left = new BNode<T>(item, TempNode);
                        ++NumberOfNodes;
                        return;
                    }
                    else
                    {
                        TempNode = TempNode.Left;
                    }
                }
                else if (ComparedValue > 0)
                {
                    if (TempNode.Right == null)
                    {
                        TempNode.Right = new BNode<T>(item, TempNode);
                        ++NumberOfNodes;
                        return;
                    }
                    else
                    {
                        TempNode = TempNode.Right;
                    }
                }
                else
                {
                    TempNode = TempNode.Right;
                }
            }
        }

    }
    
    public class BNode<T>
    {
        
        public BNode()
        {
        }
        
        public BNode(T Value)
        {
            this.Value = Value;
        }
        
        public BNode(T Value, BNode<T> Parent)
        {
            this.Value = Value;
            this.Parent = Parent;
        }
     
        public BNode(T Value, BNode<T> Parent, BNode<T> Left, BNode<T> Right)
        {
            this.Value = Value;
            this.Right = Right;
            this.Left = Left;
            this.Parent = Parent;
        }
        
        public T Value { get; set; }

        public BNode<T> Parent { get; set; }
        
        public BNode<T> Left { get; set; }
       
        public BNode<T> Right { get; set; }       
        
        internal bool Visited { get; set; }       

        public override string ToString()
        {
            return Value.ToString();
        }

        
    }    

}
