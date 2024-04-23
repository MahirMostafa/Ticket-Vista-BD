using BLL.DTOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class FinanceService
    {
        public static FinanceDTO  Finance()
        {
           int Totaladmin = DataAccessFactory.AdminData().Count();  
           int TotalAdminSalary = DataAccessFactory.AdminTSalary().TotalSal();
           int TotalEmployees = DataAccessFactory.EmployeeData().Count();  
           int TotalEmployeeSalary = DataAccessFactory.EmployeeTSalary().TotalSal();   

            return new FinanceDTO
            {
                TotalAdmins = Totaladmin,
                TotalAdminSalary = TotalAdminSalary,
                TotalEmployees = TotalEmployees,
                TotalEmployeeSalary=TotalEmployeeSalary,
                TotalAdminsAndEmployeeSalary =TotalAdminSalary+TotalEmployeeSalary,
            };
        }
    }
}
