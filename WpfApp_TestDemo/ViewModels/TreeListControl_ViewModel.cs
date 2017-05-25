using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using WpfApp_TestDemo.Command;
using WpfApp_TestDemo.Views;

namespace WpfApp_TestDemo.ViewModels
{
    class TreeListControl_ViewModel : NotificationObject
    {
        public TreeListControl_ViewModel()
        {
            Employees = new ObservableCollection<Employee>(Employee.GetEmployees());
            //Employees = Employee.GetEmployees();
            SelectedEmployee = new Employee();
            CopyVisibility = Visibility.Hidden;
            PasteVisibility = Visibility.Hidden;
            this.CopyCommand = new DelegateCommand();
            this.CopyCommand.ExecuteAction = new Action<object>(this.Copy);

            this.PasteCommand = new DelegateCommand();
            this.PasteCommand.ExecuteAction = new Action<object>(this.Paste);
        }


        private ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
        {
            get
            {
                if (_employees == null)
                    _employees = new ObservableCollection<Employee>();
                return _employees;
            }
            set
            {
                _employees = value;
                this.RaisePropertyChange("Employees");
            }
        }

        private Employee _selectedEmployee;

        public Employee SelectedEmployee
        {
            get
            {
                if (_selectedEmployee != null && !string.IsNullOrEmpty(_selectedEmployee.Name))
                {
                    CopyVisibility = Visibility.Visible;
                    Console.WriteLine("SelectedEmployee.Get");
                    Console.WriteLine($"ID：{_selectedEmployee.ID}，Name：{_selectedEmployee.Name}，Department：{_selectedEmployee.Department}，Position：{_selectedEmployee.Position}");
                }
                else
                {
                    CopyVisibility = Visibility.Hidden;
                }
                return _selectedEmployee;
            }
            set
            {
                _selectedEmployee = value;
                if (_selectedEmployee != null && !string.IsNullOrEmpty(_selectedEmployee.Name))
                {
                    CopyVisibility = Visibility.Visible;
                    Console.WriteLine("SelectedEmployee.Set");
                    Console.WriteLine($"ID：{_selectedEmployee.ID}，Name：{_selectedEmployee.Name}，Department：{_selectedEmployee.Department}，Position：{_selectedEmployee.Position}");
                }
                else
                {
                    CopyVisibility = Visibility.Hidden;
                }
                this.RaisePropertyChange("SelectedEmployee");
            }
        }


        private Employee _copyEmployee;

        public Employee CopyEmployee
        {
            get
            {
                if (_copyEmployee != null && !string.IsNullOrEmpty(_copyEmployee.Name))
                {
                    PasteVisibility = Visibility.Visible;
                    Console.WriteLine("CopyEmployee.Get");
                    Console.WriteLine($"ID：{_copyEmployee.ID}，Name：{_copyEmployee.Name}，Department：{_copyEmployee.Department}，Position：{_copyEmployee.Position}");
                }
                else
                {
                    PasteVisibility = Visibility.Hidden;
                }
                return _copyEmployee;
            }
            set
            {
                _copyEmployee = value;

                if (_copyEmployee != null && !string.IsNullOrEmpty(_copyEmployee.Name))
                {
                    PasteVisibility = Visibility.Visible;
                    Console.WriteLine("CopyEmployee.Set");
                    Console.WriteLine($"ID：{_copyEmployee.ID}，Name：{_copyEmployee.Name}，Department：{_copyEmployee.Department}，Position：{_copyEmployee.Position}");
                }
                else
                {
                    PasteVisibility = Visibility.Hidden;
                }
                this.RaisePropertyChange("CopyEmployee");
            }
        }

        private Visibility _copyVisibility;

        public Visibility CopyVisibility
        {
            get { return _copyVisibility; }
            set
            {
                _copyVisibility = value;
                this.RaisePropertyChange("CopyVisibility");
            }
        }


        public DelegateCommand CopyCommand { get; set; }

        private void Copy(object paramemter)
        {
            CopyEmployee =new Employee();
            CopyEmployee.ID = SelectedEmployee.ID;
            CopyEmployee.Name = SelectedEmployee.Name;
            CopyEmployee.ParentID = SelectedEmployee.ParentID;
            CopyEmployee.Position = SelectedEmployee.Position;
            CopyEmployee.Department = SelectedEmployee.Department;
        }


        private Visibility _pasteVisibility;

        public Visibility PasteVisibility
        {
            get { return _pasteVisibility; }
            set
            {
                _pasteVisibility = value;
                this.RaisePropertyChange("PasteVisibility");
            }
        }


        public DelegateCommand PasteCommand { get; set; }

        private void Paste(object paramemter)
        {

            CopyEmployee.ID = Guid.NewGuid().ToString();
            CopyEmployee.ParentID = SelectedEmployee.ID;
            Employees.Add(CopyEmployee);
        }
    }

}
