using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OIRA

{
    public partial class Class1 : Window
    {
        private MyViewModel _viewModel;

        public Class1()
        {
            _viewModel = new MyViewModel();
        }

        private void OpenWindow2_Click(object sender, RoutedEventArgs e)
        {

            Window2 window2 = new Window2(_viewModel);
            window2.Show();
        }
        private void OpenWindow3_Click(object sender, RoutedEventArgs e)
        {
            Window3 window3 = new Window3(_viewModel);
            window3.Show();
        }
       
    }
    public class MyViewModel : INotifyPropertyChanged
    {
        private decimal _balance;

        public decimal Balance
        {
            get { return _balance; }
            set
            {
                if (_balance != value)
                {
                    _balance = value;
                    OnPropertyChanged(nameof(Balance));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void Withdraw(decimal amount)
        {
            if (_balance >= amount)
            {
                _balance -= amount;
                OnPropertyChanged(nameof(Balance));
            }

        }
        public void Deposit(decimal amount)
        {
            _balance += amount;
            OnPropertyChanged(nameof(Balance));
        }
    }
}
