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
     public class AdminService
    {
        public static List<AdminViewDTO> Get()
        {
            var data = DataAccessFactory.AdminData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Admin, AdminViewDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<AdminViewDTO>>(data);
            return mapped;
        }

        public static AdminViewDTO Get(int id)
        {
            var data = DataAccessFactory.AdminData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Admin, AdminViewDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<AdminViewDTO>(data);
            return mapped;
        }

        public static AdminDTO UnprotectedGet(int id)
        {
            var data = DataAccessFactory.AdminData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<AdminDTO>(data);
            return mapped;
        }

        public static bool Create(AdminDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<AdminDTO, Admin>();
            });
            var mapper = new Mapper(cfg);
            var admin = mapper.Map<Admin>(obj);

            var result = DataAccessFactory.AdminData().Create(admin);

            return result;
        }

        public static bool Delete(int id) 
        {
            return DataAccessFactory.AdminData().Delete(id);

        }

        public static bool Update( AdminUpdateDTO obj)
        {

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<AdminUpdateDTO, Admin>();
            });
            var mapper = new Mapper(cfg);
            var admin = mapper.Map<Admin>(obj);

            var result = DataAccessFactory.AdminData().Update(admin);

            return result;
        }


    }
}
