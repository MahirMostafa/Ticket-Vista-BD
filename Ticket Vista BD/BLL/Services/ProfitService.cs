using BLL.DTOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProfitService
    {
        //public static int EventProfit(int id)
        //{
        //    return DataAccessFactory.ProfitData().Amount(id);
        //}


        public static EventProfitDTO EventProfit(int id)
        {
            var eventprofit = new EventProfitDTO();
            eventprofit.EventId = id;
            eventprofit.TotalTicketsSold = DataAccessFactory.ProfitData().TotalEventTicket(id);
            eventprofit.TotalSale = DataAccessFactory.ProfitData().EventSale(id);
            eventprofit.TotalPayable = DataAccessFactory.ProfitData().EventPayable(id);
            eventprofit.TotalEventProfit = DataAccessFactory.ProfitData().Amount(id);
            return eventprofit;
        }


        public static int AllEventProfit()
        {
            return DataAccessFactory.ProfitData().TotalAmount();
        }

    }
}
