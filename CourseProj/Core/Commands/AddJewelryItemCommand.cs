using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProj.MVVM.Model;
using CourseProj.MVVM.ViewModels;
using CourseProj.Repositories;

namespace CourseProj.Core.Commands
{
    class AddJewelryItemCommand : Command
    {
        private readonly JewelryItemViewModel _jewelryItemViewmodel;
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        public AddJewelryItemCommand(JewelryItemViewModel jewelryItemViewmodel, UnitOfWorkFactory unitOfWorkFactory)
        {
            _jewelryItemViewmodel = jewelryItemViewmodel;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_jewelryItemViewmodel.Name) && !string.IsNullOrEmpty(_jewelryItemViewmodel.Image) && _jewelryItemViewmodel.Price != 0 && !string.IsNullOrEmpty(_jewelryItemViewmodel.Description);
        }

        public override async void Execute(object parameter)
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                JewelryItem newItem = new JewelryItem()
                {
                    JewelryName = _jewelryItemViewmodel.Name,
                    Image = _jewelryItemViewmodel.Image,
                    Price = _jewelryItemViewmodel.Price,
                    Description = _jewelryItemViewmodel.Description,
                    JewelryOrders = new List<JewelryOrder>()
                };

                unitOfWork.JewelryItemRepository.Create(newItem);
                await unitOfWork.SaveAsync();
            }

            _jewelryItemViewmodel.Name = string.Empty;
            _jewelryItemViewmodel.Image = @"E:\2 курс\2 семестр\OOP 2\курсач\CourseProject\OOPCourseProject\CourseProj\Images\placeholder.png";
            _jewelryItemViewmodel.Price = 0;
            _jewelryItemViewmodel.Description = string.Empty;
        }
    }
}
