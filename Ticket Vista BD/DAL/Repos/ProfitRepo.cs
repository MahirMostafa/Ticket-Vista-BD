using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DAL.Repos
{
    internal class ProfitRepo : Repo , ICalc<int>
    {
        public int Amount(int id)
        {
            var totalSale = db.Tickets
                  .Where(t => t.EventId == id)
                  .Sum(t => t.TotalPrice);

            var totalTicketsSold = db.Tickets.
                Where(t => t.EventId == id)
                .Sum (t => t.TicketQuantity);

            var data = db.Events.Find(id);
            var advertiseId = data.AdvertiseId;
            var advertise = db.Advertises.Find(advertiseId);
            var actualTicketTotalPrice = advertise.TicketPrice * totalTicketsSold;
            var Profit = totalSale - actualTicketTotalPrice;
            return Profit;
        }

        public int TotalAmount()
        {
            var data = db.Events.ToList();
            int TotalProfit = 0;
            foreach (var evnt in data)
            {
                TotalProfit += Amount(evnt.Id);
            }
            return TotalProfit;
           
        }

        public int TotalEventTicket(int id)
        {
            var TotalTickets = db.Tickets.
            Where(t => t.EventId == id)
            .Sum(t => t.TicketQuantity);
            return TotalTickets;
        }

        public int EventPayable(int id)
        {
            var totalTickets = TotalEventTicket(id);

            var data = db.Events.Find(id);
            var advertiseId = data.AdvertiseId;
            var advertise = db.Advertises.Find(advertiseId);
            var TotalEventPayable = advertise.TicketPrice * totalTickets;
            return TotalEventPayable;

        }

        public int EventSale(int id)
        {
            var totalSale = db.Tickets
                  .Where(t => t.EventId == id)
                  .Sum(t => t.TotalPrice);
            return totalSale;
        }
    }
}
