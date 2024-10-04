using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfKalkulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            {
                InitializeComponent();
            }
        }

        private void BtnL1_Click(object sender, RoutedEventArgs e)
        {
           TbMain.Text += "1";
        }

        private void BtnL2_Click(object sender, RoutedEventArgs e)
        {
            TbMain.Text += "2";
        }

        private void BtnL3_Click(object sender, RoutedEventArgs e)
        {
            TbMain.Text += "3";
        }

        private void BtnL4_Click(object sender, RoutedEventArgs e)
        {
            TbMain.Text += "4";
        }

        private void BtnL5_Click(object sender, RoutedEventArgs e)
        {
            TbMain.Text += "5";
        }

        private void BtnL6_Click(object sender, RoutedEventArgs e)
        {
            TbMain.Text += "6";
        }

        private void BtnL7_Click(object sender, RoutedEventArgs e)
        {
            TbMain.Text += "7";
        }

        private void BtnL8_Click(object sender, RoutedEventArgs e)
        {
            TbMain.Text += "8";
        }

        private void BtnL9_Click(object sender, RoutedEventArgs e)
        {
            TbMain.Text += "9";
        }

        private void BtnL0_Click(object sender, RoutedEventArgs e)
        {
            TbMain.Text += "0";
        }

        private void BtnZP_Click(object sender, RoutedEventArgs e)
        {
            TbMain.Text += " + ";
        }

        private void BtnZM_Click(object sender, RoutedEventArgs e)
        {
            TbMain.Text += " - ";
        }

        private void BtnZMn_Click(object sender, RoutedEventArgs e)
        {
            TbMain.Text += " * ";
        }

        private void BtnZDz_Click(object sender, RoutedEventArgs e)
        {
            TbMain.Text += " / ";
        }

        private void BtnRowno_Click(object sender, RoutedEventArgs e)
        {
            string[] tab = TbMain.Text.Split(' ');
            int tblength = tab.Length;


            for (int i = 0; i < tblength -1; i++)
            {
                try
                {
                    if (tab[i] == "+" && tab[i + 1] != "-" && tab[i + 1] != "+" && tab[i + 1] != "*" && tab[i + 1] != "/")
                    {
                        string wynik = Convert.ToString(tab[0]) + " + " + Convert.ToString(tab[i + 1]) + " = " + Convert.ToString(Convert.ToInt16(tab[0]) + Convert.ToInt16(tab[i + 1]));
                        tab[0] = Convert.ToString(Convert.ToInt16(tab[0]) + Convert.ToInt16(tab[i + 1]));
                        LbHistoria.Items.Add(wynik);
                    }
                    else if (tab[1] == "-" && tab[i + 1] != "-" && tab[i + 1] != "+" && tab[i + 1] != "*" && tab[i + 1] != "/")
                    {
                        string wynik = Convert.ToString(tab[0]) + " - " + Convert.ToString(tab[i + 1]) + " = " + Convert.ToString(Convert.ToInt16(tab[0]) + Convert.ToInt16(tab[i + 1]));
                        tab[0] = Convert.ToString(Convert.ToInt16(tab[0]) - Convert.ToInt16(tab[i + 1]));
                        LbHistoria.Items.Add(wynik);
                    }
                    else if (tab[1] == "*" && tab[i + 1] != "-" && tab[i + 1] != "+" && tab[i + 1] != "*" && tab[i + 1] != "/")
                    {
                        string wynik = Convert.ToString(tab[0]) + " * " + Convert.ToString(tab[i + 1]) + " = " + Convert.ToString(Convert.ToInt16(tab[0]) + Convert.ToInt16(tab[i + 1]));
                        tab[0] = Convert.ToString(Convert.ToInt16(tab[0]) * Convert.ToInt16(tab[i + 1]));
                        LbHistoria.Items.Add(wynik);
                    }
                    else if (tab[i] == "/" && tab[i + 1] != "-" && tab[i + 1] != "+" && tab[i + 1] != "*" && tab[i + 1] != "/")
                    {
                        if (Convert.ToInt64(tab[i + 1]) == 0)
                        {
                            TbMain.Text = "Error: nie dzielimy na 0";
                            break; 
                        }
                        else
                        {
                            string wynik = Convert.ToString(tab[0]) + " / " + Convert.ToString(tab[i + 1]) + " = " + Convert.ToString(Convert.ToInt16(tab[0]) + Convert.ToInt16(tab[i + 1]));
                            tab[0] = Convert.ToString(Convert.ToInt16(tab[0]) / Convert.ToInt16(tab[i + 1]));
                            LbHistoria.Items.Add(wynik);
                        }
                    }
                    TbMain.Text = tab[0];
                }
                catch (Exception ex)
                { 
                    TbMain.Text = ex.ToString();
                }
            }
            
            
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TbMain.Text = "";
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}