using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenerics.Interfaces
{
    interface ILinearDataStructure<T>
    {
        void Insert();
        void Delete();
        T Get();
    }
}
