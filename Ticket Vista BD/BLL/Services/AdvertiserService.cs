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
    public class AdvertiserService
    {
        public static List<AdvertiserDTO> Get()
        {
            var data = DataAccessFactory.AdvertiserData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Advertiser, AdvertiserDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<AdvertiserDTO>>(data);
            return mapped;
        }

        public static bool Create(AdvertiserDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<AdvertiserDTO, Advertiser>();
            });
            var mapper = new Mapper(cfg);
            var advertiser = mapper.Map<Advertiser>(obj);

            var result = DataAccessFactory.AdvertiserData().Create(advertiser);

            return result;
        }


        public static AdvertiserDTO UnprotectedGet(int id)
        {
            var data = DataAccessFactory.AdvertiserData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Advertiser, AdvertiserDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<AdvertiserDTO>(data);
            return mapped;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.AdvertiserData().Delete(id);

        }

        public static bool Update(AdvertiserUpdateDTO obj)
        {

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<AdvertiserUpdateDTO, Advertiser>();
            });
            var mapper = new Mapper(cfg);
            var client = mapper.Map<Advertiser>(obj);

            var result = DataAccessFactory.AdvertiserData().Update(client);

            return result;
        }
    }
}
