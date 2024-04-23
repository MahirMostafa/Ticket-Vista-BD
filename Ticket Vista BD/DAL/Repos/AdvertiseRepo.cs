using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AdvertiseRepo : Repo, IRepo<Advertise, int, bool>, IAds<Advertise, int>
    {
       public int Count()
        {
            return db.Advertises.Count() ;
        }

        public bool Create(Advertise obj)
        {
            db.Advertises.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data =Read(id);
            db.Advertises.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Advertise> History(int id)
        {
            return db.Advertises.Where(a => a.AdvertiserId == id).ToList(); 


        }

        public List<Advertise> Read()
        {
            return db.Advertises.ToList();
        }

        public Advertise Read(int id)
        {
            var data = db.Advertises.Find(id);
            return data;
        }

        public bool Update(Advertise obj)
        {
            var data = db.Advertises.Find(obj.Id);
            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public List<Advertise> ViewAll()
        {
            return db.Advertises.ToList();

        }

        public List<Advertise> ViewPendings()
        {
            return db.Advertises.Where(a => a.Status == "Pending").ToList();

        }

        public List<Advertise> ViewApproved(int id)

        {
            return db.Advertises.Where(a => a.Status == "Approved" && a.AdvertiserId == id).ToList();
        }
        public List<Advertise> ViewDeclined(int id)

        {
            return db.Advertises.Where(a => a.Status == "Declined" && a.AdvertiserId == id).ToList();
        }

        public List<Advertise> ViewPendingIndividual(int id)
        {
            return db.Advertises.Where(a => a.Status == "Pending" && a.AdvertiserId == id).ToList();

        }
    }
}
