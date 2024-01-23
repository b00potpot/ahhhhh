using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class Window3 : Window
    {
         private MyViewModel _viewModel;
        public Window3(MyViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void SUBMIT_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateNumbers())
            {
                DisplayInformationInNotepad(string );
            }
            else
            {
                MessageBox.Show("Invalid numbers. Please enter correct numbers in all textboxes.");
            }
        }

        private bool ValidateNumbers()
        {
            return ValidateNumber(pincode_1.Text, 1) && ValidateNumber(pincode_2.Text, 1) &&
                   ValidateNumber(pincode_3.Text, 2) && ValidateNumber(pincode_4.Text, 3) &&
                   ValidateNumber(pincode_5.Text, 0) && ValidateNumber(pincode_6.Text, 4);
        }

        private bool ValidateNumber(string input, decimal expectedValue)
        {
            if (decimal.TryParse(input, out decimal parsedValue))
            {
                return parsedValue == expectedValue;
            }
            return false;
        }

        private void DisplayInformationInNotepad(string transactionType)
        {
            string information;

            if (transactionType == "Deposit")
            {
                Window5 window5Instance = new Window5(_viewModel);
                if (decimal.TryParse(Window5.Deposit_Amount.Text, out decimal depositAmount))
                {
                    information = $"Username: Oira\r\nAmount Deposited: {depositAmount}\r\nRemaining Balance: {_viewModel.Balance}\r\nDate: {DateTime.Now}\r\nTransaction: Deposit";
                }
                else
                {
                    MessageBox.Show("Invalid deposit amount. Please enter a valid number.");
                    return; 
                }
            }
            else if (transactionType == "Withdrawal")
            {
                Window2 window2Instance = new Window2(_viewModel);
                if (decimal.TryParse(Window2.AmountWithdraw.Text, out decimal withdrawalAmount))
                {
                    information = $"Username: Oira\r\nAmount Withdrawn: {withdrawalAmount}\r\nRemaining Balance: {_viewModel.Balance}\r\nDate: {DateTime.Now}\r\nTransaction: Withdrawal";
                }
                else
                {
                    MessageBox.Show("Invalid withdrawal amount. Please enter a valid number.");
                    return; 
                }
            }
            else
            {
                MessageBox.Show("Invalid transaction type.");
                return;
            }

            try
            {
                Process.Start("notepad.exe", "-").StandardInput.WriteLine(information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Notepad: {ex.Message}");
            }
        }

        
    }
}