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
    public class SalaryService
    {
        public static bool Create(SalaryDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<SalaryDTO, Salary>();
            });
            var mapper = new Mapper(cfg);
            var salary = mapper.Map<Salary>(obj);

            var result = DataAccessFactory.SalaryData().Create(salary);

            return result;
        }

        public static List<SalaryViewDTO> Get()
        {
            var data = DataAccessFactory.SalaryData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Salary, SalaryViewDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<SalaryViewDTO>>(data);
            return mapped;
        }

        public static SalaryViewDTO Get(int id)
        {
            var data = DataAccessFactory.SalaryData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Salary, SalaryViewDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<SalaryViewDTO>(data);
            return mapped;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.SalaryData().Delete(id);

        }


        public static bool Update(SalaryViewDTO obj)
        {

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<SalaryViewDTO, Salary>();
            });
            var mapper = new Mapper(cfg);
            var salary = mapper.Map<Salary>(obj);

            var result = DataAccessFactory.SalaryData().Update(salary);

            return result;
        }

    }
}
