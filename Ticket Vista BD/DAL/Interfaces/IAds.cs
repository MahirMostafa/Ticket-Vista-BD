using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAds <Type, ID>
    {
        List<Type> ViewAll();
        List<Type> ViewPendings();
        List<Type> History(ID id);
        List<Type> ViewApproved(ID id);
        List<Type> ViewDeclined(ID id);
        List<Type> ViewPendingIndividual(ID id);

    }
}
