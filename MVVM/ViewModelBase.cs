﻿using MVVM.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace MVVM
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModelBase()
        {
            Type TViewModel = GetType();

            IEnumerable<PropertyInfo> Commands = TViewModel.GetProperties()
                .Where(PI => PI.PropertyType == typeof(ICommand) || PI.PropertyType.GetInterfaces().Contains(typeof(ICommand)));

            foreach (PropertyInfo pi in Commands)
            {
                ICommand cmd = (ICommand)pi.GetMethod.Invoke(this, null);
                PropertyChanged += (s, e) => cmd.RaiseCanExecuteChanged();
            }
        }

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
