
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Wpf_CrazyE_Demo.Models;
using Wpf_CrazyE_Demo.Services;

namespace Wpf_CrazyE_Demo.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        public DelegateCommand PlaceOrderCommand { get; set; }
        public DelegateCommand SelectMenuItemCommand { get; set; }

        private int count;

        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                this.RaisePropertyChanged("Count");
            }
        }

        private Restaurant resaurant;

        public Restaurant Resaurant
        {
            get { return resaurant; }
            set
            {
                resaurant = value;
                this.RaisePropertyChanged("Resaurant");
            }
        }

        private List<DishMenuItemViewModel> disMenu;

        public List<DishMenuItemViewModel> DisMenu
        {
            get { return disMenu; }
            set
            {
                disMenu = value;
                this.RaisePropertyChanged("DisMenu");
            }
        }
        public MainWindowViewModel()
        {
            this.LoadResaurant();
            this.LoadDishMenu();
            this.PlaceOrderCommand = new DelegateCommand(new System.Action(this.PlaceOrderCommandExecute));
            this.SelectMenuItemCommand = new DelegateCommand(new System.Action(this.SelectMenuItemExecute));
        }

        private void LoadResaurant()
        {
            this.Resaurant = new Restaurant();
            this.Resaurant.Name = "Crazy猴子";
            this.Resaurant.Address = "连云港花果山水帘洞";
            this.Resaurant.PhoneNumber = "87878787";
        }

        private void LoadDishMenu()
        {
            XmlDataService ds = new XmlDataService();
            var dishes = ds.GetAllDishes();
            this.DisMenu = new List<DishMenuItemViewModel>();
            foreach (var dish in dishes)
            {
                DishMenuItemViewModel item = new DishMenuItemViewModel();
                item.Dish = dish;
                this.DisMenu.Add(item);
            }
        }
        private void PlaceOrderCommandExecute()
        {
            var selectDishs = this.DisMenu.Where(i => i.IsSelected == true).Select(i => i.Dish.Name).ToList();
            MockOrderService orderservice = new MockOrderService();
            orderservice.PlaceOrder(selectDishs);
            MessageBox.Show("订餐成功！");
        }
        private void SelectMenuItemExecute()
        {
            this.Count = this.DisMenu.Count(i => i.IsSelected == true);
        }



    }
}
