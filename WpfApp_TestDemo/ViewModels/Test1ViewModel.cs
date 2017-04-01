using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp_TestDemo.Command;

namespace WpfApp_TestDemo.ViewModels
{
    class Test1ViewModel : NotificationObject
    {
        private double input1;

        public double Input1
        {
            get { return input1; }
            set
            {
                input1 = value;
                this.RaisePropertyChange("Input1");
            }
        }

        private double input2;

        public double Input2
        {
            get { return input2; }
            set
            {
                input2 = value;
                this.RaisePropertyChange("Input2");
            }
        }

        private double result;

        public double Result
        {
            get { return result; }
            set
            {
                result = value;
                this.RaisePropertyChange("Result");
            }
        }

        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }

        private void Add(object paramemter)
        {
            this.Result = this.Input1 + this.Input2;
        }

        private void Save(object paramemter)
        {
            SaveFileDialog sfdlg = new SaveFileDialog();
            sfdlg.ShowDialog();
        }

        public Test1ViewModel()
        {
            this.AddCommand = new DelegateCommand();
            this.AddCommand.ExecuteAction = new Action<object>(this.Add);

            this.SaveCommand = new DelegateCommand();
            this.SaveCommand.ExecuteAction = new Action<object>(this.Save);
        }
    }
}
