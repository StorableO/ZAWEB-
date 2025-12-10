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

namespace StatystykaSorzedarzy
{
    /// <summary>
    /// Logika interakcji dla klasy WindowInput.xaml
    /// </summary>
    public partial class WindowInput : Window
    {
        private List<MainWindow.Produkty> _listaProduktow;

        public WindowInput(List<MainWindow.Produkty> listaProduktow)
        {
            InitializeComponent();
            _listaProduktow = listaProduktow;
            RenderInfo();
        }

        public void RenderInfo()
        {
            double calkowitePrzychody = 0;
            int lacznaIlosc = 0;

            if (_listaProduktow != null && _listaProduktow.Count > 0)
            {
                var najczesciejSprzedawany = _listaProduktow
                    .OrderByDescending(p => p.Ilosc)
                    .First();

                foreach (var produkt in _listaProduktow)
                {
                    calkowitePrzychody += (produkt.Ilosc * produkt.Cena);
                    lacznaIlosc += produkt.Ilosc;
                }

                double sredniaCenaProduktu = calkowitePrzychody / lacznaIlosc;

                calPrzychod.Content = $"Całkowite przychody: {calkowitePrzychody:F2} zł";
                sredniaCena.Content = $"Średnia cena produktu: {sredniaCenaProduktu:F2} zł";
                najProd.Content = $"Najczęściej sprzedawany: {najczesciejSprzedawany.Produkt} ({najczesciejSprzedawany.Ilosc} sztuk)";
            }
            else
            {
                MessageBox.Show("Nie udało się pobrać listy produktów");
                calPrzychod.Content = "Brak danych";
                sredniaCena.Content = "Brak danych";
                najProd.Content = "Brak danych";
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
