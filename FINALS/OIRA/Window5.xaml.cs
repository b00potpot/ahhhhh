using System;
using System.Collections.Generic;
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
    public partial class Window5 : Window
    {
        private MyViewModel _viewModel;

        public Window5(MyViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(Deposit_Amount.Text, out decimal depositAmount))
            {
                _viewModel.Deposit(depositAmount);
            }
            else
            {
                MessageBox.Show("Invalid deposit amount. Please enter a valid number.");
            }
        }

        
    }
}
