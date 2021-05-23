using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProj.Context;

namespace CourseProj.Repositories
{
    public class UnitOfwork : IDisposable
    {
        private readonly MyContext _dbContext;

        private JewelryItemRepository _jewelryItemRepository;
        private UserRepository _userRepository;
        private OrderRepository _orderRepository;
        private RepairOrderRepository _repairOrderRepository;

        public UnitOfwork()
        {
            _dbContext = new MyContext();
        }

        public JewelryItemRepository JewelryItemRepository
        {
            get
            {
                if (_jewelryItemRepository == null)
                    _jewelryItemRepository = new JewelryItemRepository(_dbContext);
                return _jewelryItemRepository;
            }
        }

        public OrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new OrderRepository(_dbContext);
                return _orderRepository;
            }
        }

        public RepairOrderRepository RepairOrderRepository
        {
            get
            {
                if (_repairOrderRepository == null)
                    _repairOrderRepository = new RepairOrderRepository(_dbContext);
                return _repairOrderRepository;
            }
        }

        public UserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_dbContext);
                return _userRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }


        public void Dispose()
        {
        }
    }
}
