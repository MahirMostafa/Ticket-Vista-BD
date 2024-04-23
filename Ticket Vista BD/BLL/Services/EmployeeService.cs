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
    public class EmployeeService
    {
        public static List<EmployeeViewDTO> Get()
        {
            var data = DataAccessFactory.EmployeeData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Employee, EmployeeViewDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<EmployeeViewDTO>>(data);
            return mapped;
        }

        public static EmployeeViewDTO Get(int id)
        {
            var data = DataAccessFactory.EmployeeData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Employee, EmployeeViewDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<EmployeeViewDTO>(data);
            return mapped;
        }


        public static EmployeeDTO UnprotectedGet(int id)
        {
            var data = DataAccessFactory.EmployeeData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<EmployeeDTO>(data);
            return mapped;
        }


        public static bool Create(EmployeeDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<EmployeeDTO, Employee>();
            });
            var mapper = new Mapper(cfg);
            var employee = mapper.Map<Employee>(obj);

            var result = DataAccessFactory.EmployeeData().Create(employee);

            return result;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.EmployeeData().Delete(id);

        }


        public static bool Update( EmployeeUpdateDTO obj)
        {

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<EmployeeUpdateDTO, Employee>();
            });
            var mapper = new Mapper(cfg);
            var employee = mapper.Map<Employee>(obj);

            var result = DataAccessFactory.EmployeeData().Update(employee);

            return result;
        }

        public static bool UpdatePass(EmployeeUpdatePasswordDTO obj)
        {

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<EmployeeUpdatePasswordDTO, Employee>();
            });
            var mapper = new Mapper(cfg);
            var employee = mapper.Map<Employee>(obj);

            var result = DataAccessFactory.EmployeePassChange().UpdatePass(employee);

            return result;
        }


    }
}
