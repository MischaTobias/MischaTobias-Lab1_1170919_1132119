using System;
//using System.Collections.Generic;
using CustomGenerics.Structures;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenerics.Interfaces
{
    public abstract class LinearDataStructureBase<T>
    {
        protected abstract void Insert(Node<T> Node);
        protected abstract void Delete();
        protected abstract T Get();
    }
}
