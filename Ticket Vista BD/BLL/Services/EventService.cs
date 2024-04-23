using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EventService
    {
        public static List<EventDTO> Get()
        {
            var data = DataAccessFactory.EventData().Read();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Employee, EmployeInfoEventDTO>();
                c.CreateMap<Event, EventDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<EventDTO>>(data);
            return mapped;
        }

        public static EventDTO Get(int id)
        {
            var data = DataAccessFactory.EventData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Employee, EmployeInfoEventDTO>();
                c.CreateMap<Event, EventDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<EventDTO>(data);
            return mapped;
        }

        public static bool Create(EventDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<EventDTO, Event>();
            });

            var mapper = new Mapper(cfg);
            var evnt = mapper.Map<Event>(obj);

            var result = DataAccessFactory.EventData().Create(evnt);

            return result;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.EventData().Delete(id);

        }
        public static bool Update(EventUpdateDTO obj)
        {

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<EventUpdateDTO, Event>();
            });
            var mapper = new Mapper(cfg);
            var evnt = mapper.Map<Event>(obj);

            var result = DataAccessFactory.EventData().Update(evnt);

            return result;
        }
       
    }
}
