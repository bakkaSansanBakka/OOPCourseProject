using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProj.Repositories
{
    public class UnitOfWorkFactory
    {
        public UnitOfwork CreateUnitOfWork()
        {
            return new UnitOfwork();
        }
    }
}
