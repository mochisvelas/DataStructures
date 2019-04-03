using System;
using System.Collections.Generic;
using System.Text;

namespace DStructures
{
    class TreeNode<Key, Value> where Key : IComparable<Key>
    {

        public Key key;
        public Value value;
        public TreeNode<Key, Value> parentNode;
        public TreeNode<Key, Value> rightNode;
        public TreeNode<Key, Value> leftNode;

        public TreeNode(Key key, Value value)
        {

            this.key = key;
            this.value = value;
            parentNode = null;
            rightNode = null;
            leftNode = null;
        }

        public TreeNode(Key key, Value value, TreeNode<Key, Value> parent)
        {

            this.key = key;
            this.value = value;
            parentNode = parent;
            rightNode = null;
            leftNode = null;
        }

    }
}
