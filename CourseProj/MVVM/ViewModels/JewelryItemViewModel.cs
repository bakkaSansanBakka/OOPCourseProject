using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CourseProj.Core;
using CourseProj.Core.Commands;
using CourseProj.MVVM.Model;
using CourseProj.MVVM.ViewModels.Base;
using CourseProj.Repositories;

namespace CourseProj.MVVM.ViewModels
{
    class JewelryItemViewModel : ViewModel
    {
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        private string _name;
        private string _description;
        private string _image;
        private float _price;
        public JewelryItem _itemEdit;
        public ItemOperationType OperationType { get; }

        public ICommand AddOrEditJewelryItemCommand { get; }
        public ICommand NavigateToStoreAdminCommand { get; set; }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string Description
        {
            get => _description;
            set => Set(ref _description, value);
        }

        public string Image
        {
            get => _image;
            set => Set(ref _image, value);
        }

        public float Price
        {
            get => _price;
            set => Set(ref _price, value);
        }

        public JewelryItemViewModel(NavigationStore navigationStore, AuthenticationStore authenticationStore, UnitOfWorkFactory unitOfWorkFactory,
            ItemOperationType itemOperationType, JewelryItem itemEdit = null, string name = null, string description = null, float price = 0, 
            string image = @"E:\2 курс\2 семестр\OOP 2\курсач\CourseProject\OOPCourseProject\CourseProj\Images/placeholder.png")
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _itemEdit = itemEdit;
            OperationType = itemOperationType;

            NavigateToStoreAdminCommand = new NavigateCommand<StoreAdminViewModel>(navigationStore, () => new StoreAdminViewModel(navigationStore, authenticationStore, unitOfWorkFactory));

            if (itemOperationType == ItemOperationType.Add)
            {
                Name = name;
                Description = description;
                Price = price;
                Image = image;

                AddOrEditJewelryItemCommand = new AddJewelryItemCommand(this, _unitOfWorkFactory);
            }
            if (itemOperationType == ItemOperationType.Edit && itemEdit != null)
            {
                _itemEdit = itemEdit;
                Name = _itemEdit.JewelryName;
                Price = _itemEdit.Price;
                Description = _itemEdit.Description;
                Image = _itemEdit.Image;

                AddOrEditJewelryItemCommand = new EditJewelryItemCommand(this, _unitOfWorkFactory);
            }
        }
    }
}
