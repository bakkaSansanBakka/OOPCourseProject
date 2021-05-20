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
    public class JewelryItemRepository : IRepository<JewelryItem>
    {
        private readonly MyContext db;

        public JewelryItemRepository(MyContext context)
        {
            db = context;
        }

        public IEnumerable<JewelryItem> GetAll()
        {
            return db.JewelryItems;
        }

        public JewelryItem Get(int id)
        {
            return db.JewelryItems.First(j => j.Id == id);
        }

        public void Create(JewelryItem item)
        {
            db.JewelryItems.Add(item);
        }

        public void Update(JewelryItem item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            JewelryItem jewelryItem = db.JewelryItems.Find(id);
            if (jewelryItem != null)
                db.JewelryItems.Remove(jewelryItem);
        }
    }
}
