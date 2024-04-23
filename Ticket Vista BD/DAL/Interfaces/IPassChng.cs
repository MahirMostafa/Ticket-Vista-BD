using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPassChng <Type>
    {
        bool UpdatePass(Type obj);
    }
}
