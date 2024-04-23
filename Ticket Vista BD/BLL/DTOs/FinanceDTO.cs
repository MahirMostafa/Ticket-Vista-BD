using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class FinanceDTO
    {
        public int TotalAdmins { get; set; }
        public int TotalAdminSalary { get; set; }
        public int TotalEmployees { get; set; }
        public int TotalEmployeeSalary { get; set; }
        public int TotalAdminsAndEmployeeSalary { get; set; }   

    }
}
