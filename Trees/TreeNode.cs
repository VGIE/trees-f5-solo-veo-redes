
using System;
using System.Collections;
using Lists;

namespace Trees
{
    public class TreeNode<T>
    {
        private T Value;
        //TODO #1: Declare a member variable called "Children" as a list of TreeNode<T> objects
        List<TreeNode<T>> Children;


        public TreeNode(T value)
        {
            //TODO #2: Initialize member variables/attributes
            Value = value;
            Children = new List<TreeNode<T>>();

        }

        public string ToString(int depth, int index)
        {
            //TODO #3: Uncomment the code below

            string output = null;
            string leftSpace = null;
            for (int i = 0; i < depth; i++) leftSpace += " ";
            if (leftSpace != null) leftSpace += "->";

            output += $"{leftSpace}[{Value}]\n";

            for (int childIndex = 0; childIndex < Children.Count(); childIndex++)
            {
                TreeNode<T> child = Children.Get(childIndex);
                output += child.ToString(depth + 1, childIndex);
            }
            return output;


        }

        public TreeNode<T> Add(T value)
        {
            //TODO #4: Add a new instance of class GenericTreeNode<T> with Value=value. Return the instance we just created
            TreeNode<T> newNode = new TreeNode<T>(value);
            Children.Add(newNode);


            return newNode;

        }

        public int Count()
        {

            int counter = 1;


            foreach (TreeNode<T> i in Children)
            {
                if (i.Children.Count() != 0)
                {
                    counter += i.Count();
                }
                else
                {
                    counter++;
                }
            }

            return counter;

        }

        public int Height()
        {
            int max = 0;
            if (this != null)
            {
                if (Children != null && Children.Count() != 0)
                {


                    foreach (TreeNode<T> i in Children)
                    {
                        int height = i.Height();

                        if (max - 1 < height)
                        {
                            max = height + 1;
                        }

                    }
                }
                return max;
            }
            return -1;
        }




        public void Remove(T value)
        {
            //TODO #7: Remove the child node that has Value=value. Apply recursively
            int index = 0;
            if (this != null)
            {
                if (Children != null && Children.Count() != 0)
                {
                    foreach (TreeNode<T> i in Children)
                    {

                        if (i.Value.Equals(value))
                        {
                            Children.Remove(index);
                        }
                        else
                        {
                            i.Remove(value);
                            index++;
                        }
                    }
                }
            }

        }

        public TreeNode<T> Find(T value)
        {
            if (this != null)
            {

                if (value.Equals(Value))
                {
                    return this;
                }
                else
                {
                    if (Children != null && Children.Count() != 0)
                    {

                        foreach (TreeNode<T> i in Children)
                        {
                            TreeNode<T> candidate = i.Find(value);
                            if (candidate != null)
                            {
                                return candidate;
                            }

                        }

                    }
                }

            }
            return null;
        }


        public void Remove(TreeNode<T> node)
        {
            //TODO #9: Same as #6, but this method is given the specific node to remove, not the value
            if (this != null)
            {
                if (Children != null && Children.Count() != 0)
                {
                    foreach (TreeNode<T> i in Children)
                    {
                        int index = Children.Count() - 1;
                        if (i.Equals(node))
                        {
                            Children.Remove(index);
                        }
                        else
                        {
                            i.Remove(node);
                        }
                    }
                }
            }
        }
    }
            
}