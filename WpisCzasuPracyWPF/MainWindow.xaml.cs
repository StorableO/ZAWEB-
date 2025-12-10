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
using System.Xml.Serialization;

namespace Zadanie1WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<WpisCzasuPracy> list = new List<WpisCzasuPracy> ();
        public MainWindow()
        {
            InitializeComponent();
            RenderDataGrid ();
        }
        private void RenderDataGrid()
        {
            dgDane.ItemsSource = null;
            dgDane.ItemsSource = list;

            tbImie.Text = string.Empty;
            tbGodziny.Text = string.Empty;
            dpData.SelectedDate = DateTime.Now;
        }

        private void btndodaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = tbImie.Text.Trim().ToString();
                DateTime dateTime = Convert.ToDateTime(dpData.SelectedDate); 
                int hours = Convert.ToInt32(tbGodziny.Text.Trim().ToString());

                WpisCzasuPracy Pracownik = new WpisCzasuPracy(name,dateTime,hours);
                list.Add(Pracownik);

                RenderDataGrid();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void btnUsun_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var wpis = button.DataContext as WpisCzasuPracy;

            if(wpis != null)
            {
                list.Remove(wpis);
            }

            RenderDataGrid();
        }
    }
}