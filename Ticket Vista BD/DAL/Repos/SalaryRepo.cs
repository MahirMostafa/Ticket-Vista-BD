using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class SalaryRepo : Repo, IRepo<Salary, int, bool> 
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public bool Create(Salary obj)
        {
            db.Salarys.Add(obj);
            return db.SaveChanges() > 0 ;
           
        }


        public bool Delete(int id)
        {
            var data = Read(id);
            db.Salarys.Remove(data);
            return db.SaveChanges() > 0;

        }

        public List<Salary> Read()
        {
            return db.Salarys.ToList();
        }

        public Salary Read(int id)
        {
            return db.Salarys.Find(id);
        }

        public bool Update(Salary obj)
        {
            var data = db.Salarys.Find(obj.Id);
            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
     
        }

    }
}
