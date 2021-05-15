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
    public class UserRepository : IRepositoryAsync<User>
    {
        private readonly MyContext db;

        public UserRepository(MyContext context)
        {
            db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users.Where(p => p.UserName != "admin");
        }

        public async Task<User> Get(int id)
        {
            return await db.Users.FindAsync(id);
        }

        public Task<User> GetByUserName(string userName)
        {
            return db.Users.FirstOrDefaultAsync(p => p.UserName == userName);
        }

        public void Create(User item)
        {
            db.Users.Add(item);
        }

        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }
    }
}
