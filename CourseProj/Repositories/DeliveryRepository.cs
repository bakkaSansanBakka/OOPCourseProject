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
    public class DeliveryRepository : IRepositoryAsync<Delivery>
    {
        private readonly MyContext db;

        public DeliveryRepository(MyContext context)
        {
            db = context;
        }

        public IEnumerable<Delivery> GetAll()
        {
            return db.Deliveries;
        }

        public async Task<Delivery> Get(int id)
        {
            return await db.Deliveries.FindAsync(id);
        }

        public void Create(Delivery item)
        {
            db.Deliveries.Add(item);
        }

        public void Update(Delivery item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Delivery delivery = db.Deliveries.Find(id);
            if (delivery != null)
                db.Deliveries.Remove(delivery);
        }
    }
}
