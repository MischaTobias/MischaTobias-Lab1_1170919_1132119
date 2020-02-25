using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomGenerics.Interfaces;
using CustomGenerics.Structures;

namespace CustomGenerics.Structures
{
    public class HandMadeList<T> : LinearDataStructureBase<T>, IEnumerable<T>
    {
        public CustomGenerics.Structures.Node<T> First;
        public CustomGenerics.Structures.Node<T> Last;
        public int count;

        public HandMadeList()
        {
            First = null;
            Last = null;
            count = 0;
        }

        public void Add(T value)//Para las colas
        {
            CustomGenerics.Structures.Node<T> NewNode = new CustomGenerics.Structures.Node<T>() 
            { Value = value, Next = null, Previous = null };
            Insert(NewNode);
        }

        public T GetAndDelete()
        {
            var value = Get();
            Delete();
            return value;
        }

        public Node<T> GetT(int position)
        {
            Node<T> node = First;
            for (int i = 0; i < position; i++)
            {
                node = node.Next;
            }
            return node;
        }

        protected override void Insert(Node<T> NewNode)
        {
            if (First == null)
            {
                First = NewNode;
                Last = NewNode;
                NewNode.Next = null;
                NewNode.Previous = null;
            }
            else 
            {
                NewNode.Next = First;
                NewNode.Previous = Last;
                First = NewNode;
                Last.Next = First;
                (First.Next).Previous = First;
            }
            count++;
        }

        protected override void Delete()
        {
            if (this.count <= 1)
            {
                First = null;
                Last = null;
            }
            else
            {
                Last = Last.Previous;
                Last.Next = First;
                count--;
            }
        }

        protected override T Get()
        {
            return Last.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var listCopy = this;
            var current = listCopy.First;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
    