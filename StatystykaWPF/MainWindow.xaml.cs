using System.Globalization;
using System.IO;
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

namespace Zadanie2Statystyka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class Produkt
    {
        public string Nazwa { get; set; }
        public double Wartosc { get; set; }
        public Produkt(string Nazwa, double Wartosc)
        {
            this.Nazwa = Nazwa;
            this.Wartosc = Wartosc;
        }
    }

    public partial class MainWindow : Window
    {
        string fileName = @"produkty.txt";
        string outputFileName = @"StatystykaProduktow.txt";

        static Dictionary<string, List<double>> dict = new Dictionary<string, List<double>>(); 
        static List<Produkt> list = new List<Produkt>();
        
        
        public void RenderAllItems()
        {
            dgProdukty.ItemsSource = null;
            dgStatystyka.Items.Clear();
            dgProdukty.ItemsSource = list;
        }
        public void CreateFileFromDict(string outputFileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    foreach (var (key, value) in dict)
                    {
                        writer.WriteLine($"{key};{value.Average()}");
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadItemsFromFile(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string linia;
                    while ((linia = reader.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(linia))
                            continue;

                        string[] dane = linia.Trim().Split(';');

                        if (double.TryParse(dane[1], NumberStyles.Any, CultureInfo.InvariantCulture, out double wartosc))
                        {
                            Produkt produkt = new Produkt(dane[0], wartosc);
                            list.Add(produkt);

                            if (dict.ContainsKey(produkt.Nazwa))
                            {
                                dict[produkt.Nazwa].Add(wartosc);
                            }
                            else
                            {
                                List<double> list = new List<double>();
                                list.Add(wartosc);
                                dict.Add(produkt.Nazwa, list);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"✗ Błędny format wartosci: '{wartosc}'");
                        }
                    }
                }
  
            }
            catch (Exception ex)
            {
                MessageBox.Show($"BŁĄD: {ex.Message}");
            };
        }
        private void btnZapisz_Click(object sender, RoutedEventArgs e)
        {
            if (dict.Count > 0)
            {
                CreateFileFromDict(outputFileName);
                MessageBox.Show("Zapisano");
            }
            else
            {
                MessageBox.Show("nie udalo sie zapisac");
            }
        }
        private void btnWyswietl_Click(object sender, RoutedEventArgs e)
        {
            RenderAllItems(); 
            //dgStatystyka.ItemsSource = dict;
            foreach (var (key, value) in dict)
            {
                var item = new MenuItem()
                {
                    Header = key,
                    DataContext = value.Average(),
                };
                dgStatystyka.Items.Add(item);
            }

        }


        public MainWindow()
        {
            InitializeComponent();
            LoadItemsFromFile(fileName);
            RenderAllItems();
        }

    }
}