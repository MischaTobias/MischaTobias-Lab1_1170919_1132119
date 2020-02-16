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
    public class List<T> : LinearDataStructureBase<T>, IEnumerable<T>
    {
        private CustomGenerics.Structures.Node<T> First;
        private CustomGenerics.Structures.Node<T> Last;

        public void EnQueue(T value)//Para las colas
        {
            CustomGenerics.Structures.Node<T> NewNode = new CustomGenerics.Structures.Node<T>() 
            { Value = value, Next = null, Previous = null };
            Insert(NewNode);
        }

        public void DeQueue()
        {
            Delete();
        }

        protected override void Insert(Node<T> NewNode)
        {
            if (First == null)
            {
                First = NewNode;
                Last = NewNode; 
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
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
