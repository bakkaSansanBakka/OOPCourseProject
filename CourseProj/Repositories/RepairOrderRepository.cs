using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProj.Context;
using CourseProj.MVVM.Model;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace CourseProj.Repositories
{
    public class RepairOrderRepository : IRepository<RepairOrder>
    {
        private readonly MyContext db;

        public RepairOrderRepository(MyContext context)
        {
            db = context;
        }
        public IEnumerable<RepairOrder> GetAll()
        {
            return db.RepairOrders;
        }

        public RepairOrder Get(int id)
        {
            return db.RepairOrders.First(i => i.Id == id);
        }

        public void Create(RepairOrder item)
        {
            db.RepairOrders.Add(item);
        }

        public void Update(RepairOrder item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            RepairOrder order = db.RepairOrders.Find(id);
            if (order != null)
                db.RepairOrders.Remove(order);
        }
    }
}
