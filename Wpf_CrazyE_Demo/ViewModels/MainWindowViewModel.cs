
using Prism.Commands;
using Prism.Mvvm;
using System;
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

        private Restaurant restaurant;

        public Restaurant Restaurant
        {
            get { return restaurant; }
            set
            {
                restaurant = value;
                this.RaisePropertyChanged("Restaurant");
            }
        }

        private List<DishMenuItemViewModel> dishMenu;

        public List<DishMenuItemViewModel> DishMenu
        {
            get { return dishMenu; }
            set
            {
                dishMenu = value;
                this.RaisePropertyChanged("DishMenu");
            }
        }
        public MainWindowViewModel()
        {
            this.LoadResaurant();
            this.LoadDishMenu();
            this.PlaceOrderCommand = new DelegateCommand(new Action(this.PlaceOrderCommandExecute));
            this.SelectMenuItemCommand = new DelegateCommand(new Action(this.SelectMenuItemExecute));
        }

        private void LoadResaurant()
        {
            this.Restaurant = new Restaurant();
            this.Restaurant.Name = "Crazy猴子";
            this.Restaurant.Address = "连云港花果山水帘洞";
            this.Restaurant.PhoneNumber = "87878787";
        }

        private void LoadDishMenu()
        {
            XmlDataService ds = new XmlDataService();
            var dishes = ds.GetAllDishes();
            this.DishMenu = new List<DishMenuItemViewModel>();
            foreach (var dish in dishes)
            {
                DishMenuItemViewModel item = new DishMenuItemViewModel();
                item.Dish = dish;
                this.DishMenu.Add(item);
            }
        }
        private void PlaceOrderCommandExecute()
        {
            var selectDishs = this.DishMenu.Where(i => i.IsSelected == true).Select(i => i.Dish.Name).ToList();
            MockOrderService orderservice = new MockOrderService();
            orderservice.PlaceOrder(selectDishs);
            MessageBox.Show("订餐成功！");
        }
        private void SelectMenuItemExecute()
        {
            this.Count = this.DishMenu.Count(i => i.IsSelected == true);
        }



    }
}
