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
    public class AdvertiseService
    {
        public static bool Create(AdvertiseCreateDTO obj ,int id)
        {
            var data = new Advertise();
            data.AdvertiserId = id;
            data.Title = obj.Title; 
            data.Description = obj.Description;
            data.TicketPrice = obj.TicketPrice;
            data.Status = "Pending";
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<AdvertiseCreateDTO, Advertise>();
                c.CreateMap<AdvertiseCreateDTO, AdvertiseDTO>();

            });
            var mapper = new Mapper(cfg);
            var advertise = mapper.Map<Advertise>(data);

            var result = DataAccessFactory.AdvertiseData().Create(advertise);

            return result;
        }

        public static List<AdsViewDTO> GetAllAds()
        {
            var data = DataAccessFactory.AdsData().ViewAll();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Advertise, AdsViewDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<AdsViewDTO>>(data);
            return mapped;
        }

        public static List<PendingAdsDTO> GetPendingAds()
        {
            var data = DataAccessFactory.AdsData().ViewPendings();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Advertise, PendingAdsDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PendingAdsDTO>>(data);
            return mapped;
        }
        public static List<AdsViewDTO> History(int id)
        {
            var data = DataAccessFactory.AdsData().History(id); 
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Advertise, AdsViewDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<AdsViewDTO>>(data);
            return mapped;
        }

        public static bool ApproveAd(int id)
        {
            var data = DataAccessFactory.AdvertiseData().Read(id);   
            if (data != null)
            {
                data.Status = "Approved";

                var result = DataAccessFactory.AdvertiseData().Update(data);
                return result;
            }
            return false;
        }

        public static bool DeclineeAd(int id)
        {
            var data = DataAccessFactory.AdvertiseData().Read(id);   
            if (data != null)
            {
                data.Status = "Declined";

                var result = DataAccessFactory.AdvertiseData().Update(data);
                return result;
            }
            return false;
        }

        public static List<PendingAdsDTO> ViewApproved(int id) 
        {
            var data = DataAccessFactory.AdsData().ViewApproved(id); 
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Advertise, PendingAdsDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PendingAdsDTO>>(data);
            return mapped;
        }

        public static List<PendingAdsDTO> ViewDeclined(int id)
        {
            var data = DataAccessFactory.AdsData().ViewDeclined(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Advertise, PendingAdsDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PendingAdsDTO>>(data);
            return mapped;
        }

        public static List<PendingAdsDTO> ViewPendingIndividual(int id)
        {
            var data = DataAccessFactory.AdsData().ViewPendingIndividual(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Advertise, PendingAdsDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PendingAdsDTO>>(data);
            return mapped;
        }




    }
}
