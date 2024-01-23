using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OIRA
{

    public partial class Window2 : Window
    {
        private MyViewModel _viewModel;

        public Window2(MyViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }

        private void Withdraw_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(AmountWithdraw.Text, out decimal withdrawalAmount) && withdrawalAmount > 0)
            {
                _viewModel.Withdraw(withdrawalAmount);
                Close();
            }
            else
            {
                MessageBox.Show("Invalid withdrawal amount. Please enter a valid positive number.");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            AmountWithdraw.Text = AmountWithdraw.Text;
        }
    }
}
      