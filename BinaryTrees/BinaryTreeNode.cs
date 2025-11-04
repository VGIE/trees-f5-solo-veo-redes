
using System;
using System.ComponentModel.Design;
using System.Diagnostics.Tracing;
using System.Xml;
namespace BinaryTrees
{
    public class BinaryTreeNode<TKey, TValue> where TKey : IComparable<TKey>
    {
        public TKey Key;
        public TValue Value;
        public BinaryTreeNode<TKey, TValue> LeftChild;
        public BinaryTreeNode<TKey, TValue> RightChild;

        public BinaryTreeNode(TKey key, TValue value)
        {
            //TODO #1: Initialize member variables/attributes
            this.Key = key;
            this.Value = value;
            LeftChild = null;
            RightChild = null;
            
        }

        public string ToString(int depth)
        {
            string output = null;

            string leftSpace = null;
            for (int i = 0; i < depth; i++) leftSpace += " ";
            if (leftSpace != null) leftSpace += "->";

            if (Value != null)
                output += $"{leftSpace}[{Key.ToString()}-{Value.ToString()}]\n";

            if (LeftChild != null)
                output += $"{LeftChild?.ToString(depth + 1)}";

            if (RightChild != null)
                output += $"{RightChild?.ToString(depth + 1)}";

            return output;
        }

        public bool Add(BinaryTreeNode<TKey, TValue> node)
        {
            if (Key.CompareTo(node.Key) < 0)
            {
                if (this.LeftChild == null)
                {
                    LeftChild = new BinaryTreeNode<TKey, TValue>(node.Key, node.Value);
                    return true;
                }
                else
                    LeftChild.Add(node);

            }
            else if (Key.CompareTo(node.Key) > 0)
            {
                if (this.RightChild == null)
                {
                    RightChild = new BinaryTreeNode<TKey, TValue>(node.Key, node.Value);
                    return true;
                }
                else
                    RightChild.Add(node);
                return false;

            }
            else
            {
                this.Value = node.Value;
            }
             return false;
            //TODO #2: Add the new node following the order:
            //          -If the current node (this) has a higher key that the new node (use CompareTo()), the new node should be on this node's left.
            //              a) If the left child is null, the added node should be this node's left node side
            //              b) Else, we should ask the LeftChild to add it recursively
            //          -If the current node has a lower key that the new node (use CompareTo()), the new node should be on this node's right side.
            //          -If the current node and the new node have the same key, just update this node's value with the new node's value

        }

        public int Count()
        {
            int count = 1;
            if (this != null)
            {
                if (LeftChild != null)
                {
                    count += LeftChild.Count();
                }
                if (RightChild != null)
                {
                    count += RightChild.Count();
                }

                //TODO #3: Return the total number of elements in this tree

                return count;
            }
            return 0;
            
        }

        public int Height()
        {
            //TODO #4: Return the height of this tree
            if (this != null)
            {
                int max = 0;
                if (LeftChild != null)
                {
                    int height = LeftChild.Height();
                    if (max -1< height)
                        max = height+1;
                }
                 if (RightChild != null)
                {
                    int height = RightChild.Height();
                    if (max -1< height)
                        max = height+1;
                }

                return max;

            }
            return -1;
            
        }

        public TValue Get(TKey key)
        {

            if (Key.CompareTo(key) < 0)
            {

                if (LeftChild == null)
                    return default;
                else
                {
                    return LeftChild.Get(key);
                }
            }
            else if (Key.CompareTo(key) > 0)
            {

                if (RightChild == null)
                    return default;
                else
                {
                    return RightChild.Get(key);
                }
            }
            else
            {
                return this.Value;
            }
            //TODO #5: Find the node that has this key:
            //          -If the current node (this) has a higher key that the new node (use CompareTo()), the key we are searching for should be on this node's left side.
            //              a) If the left child is null, return null. We haven't found it
            //              b) Else, we should ask the LeftChild to find the node recursively. It must be below LeftChild
            //          -If the current node has a lower key that the new node (use CompareTo()), the key should be on this node's right side.
            //          -If the current node and the new node have the same key, just return this node's value. We found it

        }



        public BinaryTreeNode<TKey, TValue> Remove(TKey key)
        {

            if (Key.CompareTo(key) == 0)
            {
                if (RightChild == null && LeftChild == null)
                    return null;
                else if (RightChild != null && LeftChild == null)
                {
                    return RightChild;
                }
                else if (LeftChild != null && RightChild == null)
                    return LeftChild;
                else
                {
                    LeftChild.Add(RightChild);
                    return LeftChild;
                }
            }
            else if (Key.CompareTo(key) > 0)
            {
                if (RightChild != null)
                {
                    BinaryTreeNode<TKey, TValue> re= RightChild.Remove(key);
                    if (RightChild.Key.CompareTo(key) == 0)
                    {
                        this.RightChild = RightChild.Remove(key);
                    }
                return re;
                }
            else
                return null;
            }
            else if (Key.CompareTo(key) < 0)
            {
                if (LeftChild != null)
                {
                    BinaryTreeNode<TKey, TValue> re= LeftChild.Remove(key);
                    if (LeftChild.Key.CompareTo(key) == 0)
                        this.LeftChild = LeftChild.Remove(key);
                    return re;
                }
                else
                    return null;
            }

            return null; 
            
           
            //TODO #6: Remove the node that has this key. The parent may need to update one of its children,
            //so this method returns the node with which this node needs to be replaced. If this node isn't the
            //one we are looking for, we will return this, so that the parent node can replace LeftChild/RightChild
            //with the same node it had.


        }

        public int KeysToArray(TKey[] keys, int index)
        {
            if (LeftChild != null)
                index = LeftChild.KeysToArray(keys, index);
            keys[index] = Key;
            index++;
            if (RightChild != null)
                index = RightChild.KeysToArray(keys, index);
            return index;
        }

        public int ValuesToArray(TValue[] values, int index)
        {
            if (LeftChild != null)
                index = LeftChild.ValuesToArray(values, index);
            values[index] = Value;
            index++;
            if (RightChild != null)
                index = RightChild.ValuesToArray(values, index);
            return index;
        }
    }
}