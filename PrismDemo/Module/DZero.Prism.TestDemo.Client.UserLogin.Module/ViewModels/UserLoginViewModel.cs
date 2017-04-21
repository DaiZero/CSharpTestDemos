﻿using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DZero.Prism.TestDemo.Client.UserLogin.Module.ViewModels
{
    public class UserLoginViewModel : BindableBase
    {
        private bool? _dialogResult;
        public bool? DialogResult
        {
            get { return _dialogResult; }
            set
            {
                _dialogResult = value;
                //RaisePropertyChanged("DialogResult");// OnPropertyChanged("DialogResult");OnPropertyChanged方法已过时

                //BindableBase中的SetProperty方法将负责为你启动任何RaisePropertyChanged事件以及照顾任何所需的验证。
                SetProperty(ref _dialogResult, value, "DialogResult");
            }
        }

        ICommand _confirm;
        public ICommand Confirm
        {
            get
            {
                if (_confirm == null)
                {
                    _confirm = new DelegateCommand(OnConfirm);
                }
                return _confirm;
            }
        }

        void OnConfirm()
        {
            MessageBox.Show("登录成功！");
            this.DialogResult = true;
        }

        ICommand _cancel;
        public ICommand Cancel
        {
            get
            {
                if (_cancel == null)
                {
                    _cancel = new DelegateCommand(OnCancle);
                }
                return _cancel;
            }
        }

        void OnCancle()
        {
            MessageBox.Show("重新登录！");
            this.DialogResult = false;
        }
    }
}

