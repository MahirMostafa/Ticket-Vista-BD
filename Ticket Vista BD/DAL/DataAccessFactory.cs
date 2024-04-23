using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {

        public static IAuth<Buyer> BuyerAuthData()
        {
            return new BuyerRepo();
        }
        public static IAuth<Admin> AdminAuthData()
        {
            return new AdminRepo();
        }
        public static IAuth<Employee> EmployeeAuthData()
        {
            return new EmployeeRepo();
        }
        public static IAuth<Advertiser> AdvertiserAuthData()
        {
            return new AdvertiserRepo();
        }

        public static IRepo<Token, String, Token> TokenData()
        {
            return new TokenRepo();
        }
        public static IRepo<Buyer, int, bool> BuyerData()
        {
            return new BuyerRepo();
        }

        public static IRepo<Advertiser, int, bool> AdvertiserData()
        {
            return new AdvertiserRepo();
        }

        public static IRepo<Admin, int, bool> AdminData()
        {
            return new AdminRepo();
        }


        public static IRepo<Employee, int, bool> EmployeeData()
        {
            return new EmployeeRepo();
        }
        public static IPassChng<Employee> EmployeePassChange()
        {
            return new EmployeeRepo();
        }
        public static IRepo<Event, int, bool> EventData()
        {
            return new EventRepo();
        }

        public static IRepo<Salary, int, bool> SalaryData()
        {
            return new SalaryRepo();
        }

        public static IFinance<int> AdminTSalary()
        {
            return new AdminRepo();
        }

        public static IFinance<int> EmployeeTSalary()
        {
            return new EmployeeRepo();
        }

        public static IRepo<Advertise, int, bool> AdvertiseData()
        {
            return new AdvertiseRepo();
        }

        public static ICalc<int> ProfitData()
        {
            return new ProfitRepo();    
        }
     
        public static IRepo<Ticket, int, bool> TicketData()
        {
            return new TicketRepo();
        }

        public static IAds<Advertise, int> AdsData()
        {
            return new AdvertiseRepo();
        }
        
    }
}
