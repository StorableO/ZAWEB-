using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace StatystykaSorzedarzy
{
    public partial class MainWindow : Window
    {
        public class Produkty
        {
            public string Produkt { get; set; } = "";
            public int Ilosc { get; set; }
            public double Cena { get; set; }
        }

        public List<Produkty> _listProduktow = new List<Produkty>();
        private string _currentFileName = "";

        public void OdswiezList()
        {
            int calCena = 0;

            listViewMain.ItemsSource = null;
            listViewMain.ItemsSource = _listProduktow;

            ilcPoz.Content = $"Ilość pozycji: {_listProduktow.Count}";
            foreach (Produkty item in _listProduktow)
            {
                calCena += item.Ilosc;
            }
            ilcPro.Content = $"Ilość produktów: {calCena}";
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnWybierz_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = "produkty";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                _currentFileName = dlg.FileName;
                _listProduktow.Clear();

                try
                {
                    using (StreamReader reader = new StreamReader(_currentFileName))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (string.IsNullOrWhiteSpace(line)) continue;

                            string[] parametrs = line.Split(';');
                            if (parametrs.Length < 3) continue;

                            string cenaString = parametrs[2].Trim().Replace(',', '.');
                            if (double.TryParse(cenaString, NumberStyles.Any, CultureInfo.InvariantCulture, out double cena))
                            {
                                if (int.TryParse(parametrs[1].Trim(), out int ilosc))
                                {
                                    Produkty produkt = new Produkty
                                    {
                                        Produkt = parametrs[0].Trim(),
                                        Ilosc = ilosc,
                                        Cena = cena
                                    };

                                    _listProduktow.Add(produkt);
                                }
                            }
                        }
                    }
                    OdswiezList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"BŁĄD: {ex.Message}");
                }
            }
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            string.IsNullOrWhiteSpace(txtNowyProdukt.Text);
            int.TryParse(txtNowaIlosc.Text, out int ilosc);

            string cenaString = txtNowaCena.Text.Trim().Replace(',', '.');
            if (!double.TryParse(cenaString, NumberStyles.Any, CultureInfo.InvariantCulture, out double cena) || cena <= 0)
            {
                MessageBox.Show("Wprowadź poprawną cenę!");
                txtNowaCena.Focus();
                return;
            }

            Produkty nowyProdukt = new Produkty
            {
                Produkt = txtNowyProdukt.Text.Trim(),
                Ilosc = ilosc,
                Cena = cena
            };

            _listProduktow.Add(nowyProdukt);
            OdswiezList();

            txtNowyProdukt.Text = "";
            txtNowaIlosc.Text = "";
            txtNowaCena.Text = "";
        }

        private void btnZapiszDoPliku_Click(object sender, RoutedEventArgs e)
        {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.FileName = "produkty";
                saveDialog.DefaultExt = ".txt";
                saveDialog.Filter = "Text documents (.txt)|*.txt";

                if (saveDialog.ShowDialog() == true)
                {
                    _currentFileName = saveDialog.FileName;
                }
                else
                {
                    return;
                }
            

            try
            {
                using (StreamWriter writer = new StreamWriter(_currentFileName))
                {
                    foreach (var produkt in _listProduktow)
                    {
                        writer.WriteLine($"{produkt.Produkt};{produkt.Ilosc};{produkt.Cena}");
                    }
                }

                MessageBox.Show($"Pomyślnie zapisano");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd zapisu: {ex.Message}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowInput newWindow = new WindowInput(_listProduktow);
            newWindow.Show();
        }
    }
}