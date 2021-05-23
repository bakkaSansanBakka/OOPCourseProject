using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProj.MVVM.ViewModels.Base;

namespace CourseProj.MVVM.ViewModels
{
    class EnumViewModel<TEnum> : ViewModel where TEnum : struct, Enum
    {
        private IList<TEnum> _items;
        private TEnum _selectedItem;
        public event Action OnSelectionChanged = null!;

        public EnumViewModel()
        {
            _items = Enum.GetValues<TEnum>().ToList();
            _selectedItem = Items[0];
        }

        public IList<TEnum> Items
        {
            get => _items;
            set => Set(ref _items, value);
        }

        public TEnum SelectedItem
        {
            get => _selectedItem;
            set
            {
                Set(ref _selectedItem, value);
                OnSelectionChanged?.Invoke();
            }
        }
    }
}
