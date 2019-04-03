using System;
using System.Collections.Generic;
using System.Text;

namespace DStructures
{
    public class Tree<Key, Value> where Key : IComparable<Key>
    {

        TreeNode<Key, Value> rootNode;

        public Tree()
        {

            rootNode = null;
        }

        public void Insert(Key key, Value value)
        {

            if (rootNode == null)
            {
                rootNode = new TreeNode<Key, Value>(key, value);
            }
            else
            {
                rootNode = InsertNode(key, value, rootNode);
            }
        }

        private TreeNode<Key, Value> InsertNode(Key key, Value value, TreeNode<Key, Value> actualNode)
        {

            if (rootNode == null)
            {
                actualNode = new TreeNode<Key, Value>(key, value);
                return actualNode;
            }
            else if (key.CompareTo(actualNode.key) >= 0)
            {
                actualNode.rightNode = InsertNode(key, value, actualNode.rightNode);
            }
            else
            {
                actualNode.leftNode = InsertNode(key, value, actualNode.leftNode);
            }

            return actualNode;
        }

        public void WipeOut()
        {
            rootNode = null;
        }

        //private TreeNode<Key, Value> SearchNode(Key key) { }
    }
}
