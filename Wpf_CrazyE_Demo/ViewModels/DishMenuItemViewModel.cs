
using Prism.Mvvm;
using Wpf_CrazyE_Demo.Models;

namespace Wpf_CrazyE_Demo.ViewModels
{
    class DishMenuItemViewModel : BindableBase
    {
        public Dish Dish { get; set; }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                this.RaisePropertyChanged("IsSelected");
            }
        }
    }
}
