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
    public class BuyerService
    {
        public static List<BuyerDTO> Get()
        {
            var data = DataAccessFactory.BuyerData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Buyer, BuyerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<BuyerDTO>>(data);
            return mapped;
        }

        public static bool Create(BuyerDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<BuyerDTO, Buyer>();
            });
            var mapper = new Mapper(cfg);
            var buyer = mapper.Map<Buyer>(obj);

            var result = DataAccessFactory.BuyerData().Create(buyer);

            return result;
        }



        public static BuyerDTO UnprotectedGet(int id)
        {
            var data = DataAccessFactory.BuyerData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Buyer, BuyerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<BuyerDTO>(data);
            return mapped;
        }

    }
}
