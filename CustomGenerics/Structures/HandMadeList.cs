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
        private CustomGenerics.Structures.Node<T> First;
        private CustomGenerics.Structures.Node<T> Last;

        public void EnQueue(T value)//Para las colas
        {
            CustomGenerics.Structures.Node<T> NewNode = new CustomGenerics.Structures.Node<T>() 
            { Value = value, Next = null, Previous = null };
            Insert(NewNode);
        }

        public T DeQueue()
        {
            var value = Get();
            Delete();
            return value;
        }

        protected override void Insert(Node<T> NewNode)
        {
            if (First == null)
            {
                First = NewNode;
                Last = NewNode;
                NewNode.Next = NewNode;
                NewNode.Previous = NewNode;
            }
            else 
            {
                NewNode.Next = First;
                NewNode.Previous = Last;
                First = NewNode;
                Last.Next = First;
                (First.Next).Previous = First;
            }
        }

        protected override void Delete()
        {
            if (this.Count() <= 1)
            {
                First = null;
                Last = null;
            }
            else
            {
                Last = Last.Previous;
                Last.Next = First;
            }
        }

        protected override T Get()
        {
            return Last.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var listCopy = this;
            while (listCopy.First != null)
            {
                yield return listCopy.DeQueue();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
    