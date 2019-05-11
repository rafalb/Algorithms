using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Trees
{
    public class BinarySearchTree<T> where T : IComparable
    {
        private class Node
        {
            public Node(Node parent, T value)
            {
                this.parent = parent;
                Value = value;
            }

            private Node parent;
            private Node leftSon;
            private Node rightSon;

            public T Value { get; private set; }

            public override string ToString()
            {
                return Value.ToString();
            }

            public void Insert(T newValue)
            {
                if (Comparer<T>.Default.Compare(newValue, Value) < 0)
                {
                    if (leftSon == null)
                    {
                        leftSon = new Node(this, newValue);
                    }
                    else
                    {
                        leftSon.Insert(newValue);
                    }
                }
                else
                {
                    if (rightSon == null)
                    {
                        rightSon = new Node(this, newValue);
                    }
                    else
                    {
                        rightSon.Insert(newValue);
                    }
                }
            }

            public void AddSortedValues(T[] values, ref int index)
            {
                if (leftSon != null)
                {
                    leftSon.AddSortedValues(values, ref index);
                }

                values[index] = Value;
                index++;

                if (rightSon != null)
                {
                    rightSon.AddSortedValues(values, ref index);
                }
            }

            public bool Contains(T value)
            {
                Node node = this;

                while (node != null)
                {
                    int comparison = Comparer<T>.Default.Compare(value, node.Value);

                    if (comparison == 0)
                    {
                        return true;
                    }
                    else if (comparison < 0)
                    {
                        node = node.leftSon;
                    }
                    else
                    {
                        node = node.rightSon;
                    }
                }

                return false;
            }

            public void Remove(T value, ref Node newRoot)
            {
                int comparison = Comparer<T>.Default.Compare(value, Value);

                if (comparison == 0)
                {
                    Node formerLeftSon = leftSon;
                    Node formerRightSon = rightSon;

                    RemoveSelf();

                    if (parent == null)
                    {
                        if (formerLeftSon != null && formerRightSon != null)
                        {
                            newRoot = formerLeftSon.parent;
                        }
                        else if (formerLeftSon != null)
                        {
                            newRoot = formerLeftSon;
                        }
                        else
                        {
                            newRoot = formerRightSon;
                        }
                    }
                }
                else if (comparison < 0)
                {
                    if (leftSon != null)
                    {
                        leftSon.Remove(value, ref newRoot);
                    }
                }
                else
                {
                    if (rightSon != null)
                    {
                        rightSon.Remove(value, ref newRoot);
                    }
                }
            }

            private void RemoveSelf()
            {
                Node newSon;

                if (leftSon != null && rightSon != null)
                {
                    newSon = rightSon;

                    while (newSon.leftSon != null)
                    {
                        newSon = newSon.leftSon;
                    }

                    if (newSon.parent.leftSon == newSon)
                    {
                        newSon.parent.leftSon = newSon.rightSon;

                        if (newSon.rightSon != null)
                        {
                            newSon.rightSon.parent = newSon.parent;
                        }
                    }

                    newSon.leftSon = leftSon;
                    leftSon.parent = newSon;

                    if (newSon.parent != this)
                    {
                        newSon.rightSon = rightSon;
                        rightSon.parent = newSon;
                    }
                }
                else
                {
                    newSon = leftSon != null ? leftSon : rightSon;
                }

                if (parent != null)
                {
                    if (parent.leftSon == this)
                    {
                        parent.leftSon = newSon;
                    }
                    else
                    {
                        parent.rightSon = newSon;
                    }
                }

                if (newSon != null)
                {
                    newSon.parent = parent;
                }
            }
        }

        private Node root;

        public int NodeCount { get; private set; }

        public T RootValue
        {
            get { return root.Value; }
        }

        public void Add(T value)
        {
            NodeCount += 1;

            if (root == null)
            {
                root = new Node(null, value);
            }
            else
            {
                root.Insert(value);
            }
        }

        public void Add(params T[] values)
        {
            foreach (var value in values)
            {
                Add(value);
            }
        }

        public void Remove(T value)
        {
            if (Contains(value))
            {
                NodeCount -= 1;
            }

            if (root != null)
            {
                root.Remove(value, ref root);
            }
        }

        public T[] GetSortedValues()
        {
            var sortedValues = new T[NodeCount];

            if (root != null)
            {
                int index = 0;
                root.AddSortedValues(sortedValues, ref index);
            }

            return sortedValues;
        }

        public bool Contains(T value)
        {
            return root == null ? false : root.Contains(value);
        }
    }
}
