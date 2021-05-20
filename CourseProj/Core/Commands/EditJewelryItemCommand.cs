using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProj.MVVM.ViewModels;
using CourseProj.Repositories;

namespace CourseProj.Core.Commands
{
    class EditJewelryItemCommand : Command
    {
        private readonly JewelryItemViewModel _jewelryItemViewModel;
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        public EditJewelryItemCommand(JewelryItemViewModel jewelryItemViewModel, UnitOfWorkFactory unitOfWorkFactory)
        {
            _jewelryItemViewModel = jewelryItemViewModel;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_jewelryItemViewModel.Name) && !string.IsNullOrEmpty(_jewelryItemViewModel.Image) && _jewelryItemViewModel.Price != 0 && !string.IsNullOrEmpty(_jewelryItemViewModel.Description);
        }

        public override async void Execute(object parameter)
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var itemEdit = unitOfWork.JewelryItemRepository.Get(_jewelryItemViewModel._itemEdit.Id);
                itemEdit.JewelryName = _jewelryItemViewModel.Name;
                itemEdit.Price = _jewelryItemViewModel.Price;
                itemEdit.Image = _jewelryItemViewModel.Image;
                itemEdit.Description = _jewelryItemViewModel.Description;

                unitOfWork.JewelryItemRepository.Update(itemEdit);
                await unitOfWork.SaveAsync();
                _jewelryItemViewModel.NavigateToStoreAdminCommand.Execute(null);
            }
        }
    }
}
