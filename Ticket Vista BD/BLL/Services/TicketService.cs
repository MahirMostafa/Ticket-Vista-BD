using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TicketService
    {
        public static bool Create(TicketDTO ticket)
        {
  
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<TicketDTO, Ticket>();
            });
            var mapper = new Mapper(cfg);
            var Ticket = mapper.Map<Ticket>(ticket);

            var result = DataAccessFactory.TicketData().Create(Ticket);

            return result;
        }
    }
}
