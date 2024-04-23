using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public  interface ICalc<Type>
    {
        int Amount(int id);
        int TotalAmount();
        int TotalEventTicket(int id);
        int EventPayable(int id);
        int EventSale(int id);
    }
}
