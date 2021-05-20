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
    public class OrderRepository : IRepository<JewelryOrder>
    {
        private readonly MyContext db;

        public OrderRepository(MyContext context)
        {
            db = context;
        }
        public IEnumerable<JewelryOrder> GetAll()
        {
            return db.JewelryOrders.Include(p => p.Delivery)
                .Include(c => c.JewelryItem)
                .Include(b => b.User);
        }

        public JewelryOrder Get(int id)
        {
            return db.JewelryOrders.Include(p => p.Delivery)
                .Include(c => c.JewelryItem)
                .Include(b => b.User).First(i => i.Id == id);
        }

        public void Create(JewelryOrder item)
        {
            db.JewelryOrders.Add(item);
        }

        public void Update(JewelryOrder item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            JewelryOrder order = db.JewelryOrders.Find(id);
            if (order != null)
                db.JewelryOrders.Remove(order);
        }
    }
}
