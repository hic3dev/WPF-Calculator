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

namespace Calculator
{
    public partial class MainWindow : Window
    {
        bool isNewEntry = true; 
        double lastNumber;
        double result;
        string selectedOperator; 
        public MainWindow()
        {
            InitializeComponent();
        }
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string str = button.Content.ToString();

            if (Display.Text == "0" || isNewEntry)
            {
                Display.Text = str;
                isNewEntry = false;
            }
            else
            {
                Display.Text += str;
            }
        }
        private void OperationButton_Click(Object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            lastNumber = double.Parse(Display.Text);

            selectedOperator = button.Content.ToString();

            isNewEntry = true;
        }
        private void ResultButton_Click(Object sender, RoutedEventArgs e) 
        {
            double secondNumber = double.Parse(Display.Text);
            switch (selectedOperator)
            {
        case "+":
                    result = lastNumber + secondNumber;
                    break;
                case "-":
                    result = lastNumber - secondNumber;
                    break;
                case "*":
                    result = lastNumber * secondNumber;
                    break;
                case "/":
                    if (secondNumber != 0)
                        result = lastNumber / secondNumber;
                    else
                        MessageBox.Show("На ноль делить нельзя!");
                    break;
                }
            Display.Text = result.ToString();

            isNewEntry = true ;
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
            lastNumber = 0;
            result = 0;
            selectedOperator = "";
            isNewEntry = true;
        }
        private void CE_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
            isNewEntry = true;
        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (Display.Text.Length > 1)
            {
                Display.Text = Display.Text.Substring(0, Display.Text.Length - 1);
            }
            else
            {
                Display.Text = "0";
                isNewEntry = true;
            }
        }
    }
}
