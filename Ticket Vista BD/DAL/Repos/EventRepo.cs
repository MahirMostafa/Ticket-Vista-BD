using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class EventRepo : Repo, IRepo<Event, int, bool>
    {
        public int Count()
        {
            return db.Events.Count();
        }
        public bool Create(Event obj)
        {
            db.Events.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = Read(id);
            db.Events.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Event> Read()
        {
            return db.Events.ToList();
        }

        public Event Read(int id)
        {
            return db.Events.Find(id);
        }

        public bool Update(Event obj)
        {
            var data = db.Events.Find(obj.Id);
            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
