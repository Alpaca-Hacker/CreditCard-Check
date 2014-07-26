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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CardCheck;

namespace CreditCard_Check
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            string fileName = Environment.CurrentDirectory+@"\CardData.txt";
            InitializeComponent();
            try
            {
                CardData init = new CardData(fileName); // Initalise card data
            }
            catch
            {
                OutputBox.Text = "Data file not found!";
            }
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            string cardNumber = Input.Text;
            if (cardNumber.Length != 16)
            {
                OutputBox.Text = "NOT ENOUGH NUMBERS!";
                return;
            }
            try
            {

                if (!CardCheck.CardCheck.CheckNumber(cardNumber))
                {
                    OutputBox.Text = "*** INVALID CARD ***";

                    return;
                }
                OutputBox.Text = CardData.BankInfo(cardNumber);
            }
            catch (FormatException)
            {
                OutputBox.Text = "Please use numbers only. No dashes or spaces needed.";
            }



        }
    }
}
