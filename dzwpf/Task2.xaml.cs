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
using System.Data;

namespace dzwpf
{
    /// <summary>
    /// Логика взаимодействия для Task2.xaml
    /// </summary>
    /// string content = (sender as Button).Content.ToString();
    public partial class Task2 : Window
    {
        public Task2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string content = (sender as Button).Content.ToString();
            DataTable data = new DataTable();

            if (content == "=")
            {
                try
                {
                    string s = Convert.ToString(data.Compute(Result.Text.Replace(",", "."), ""));
                    History.Text = Result.Text;
                    Result.Text = s;
                }
                catch { MessageBox.Show("Ошибочка"); }
            }
            else if (content == "C")
            {
                Result.Text = null;
            }
            else if (content == "CE")
            {
                if (Result.Text.Length > 0)
                {
                    char[] symbols = { '*', '+', '-', '/' };
                    int end = Result.Text.LastIndexOfAny(symbols);
                    string new_string = Result.Text.Substring(0, end + 1);
                    Result.Text = new_string;
                }
            }
            else if (content == "<")
            {
                if (Result.Text.Length > 0)
                {
                    string new_string = Result.Text.Substring(0, Result.Text.Length - 1);
                    Result.Text = new_string;
                }
            }
            else
                Result.Text += content;


        }
    }
}
