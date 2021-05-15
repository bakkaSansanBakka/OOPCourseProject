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

        private DeliveryRepository _deliveryRepository;
        private JewelryItemRepository _jewelryItemRepository;
        private UserRepository _userRepository;
        private OrderRepository _orderRepository;

        public UnitOfwork()
        {
            _dbContext = new MyContext();
        }

        public DeliveryRepository DeliveryRepository
        {
            get
            {
                if (_deliveryRepository == null)
                    _deliveryRepository = new DeliveryRepository(_dbContext);
                return _deliveryRepository;
            }
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
