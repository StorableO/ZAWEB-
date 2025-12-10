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

namespace Zadanie1
{
    public partial class MainWindow : Window
    {
        static List<Ksiazka> ksiazkaList = new List<Ksiazka>();
        static List<Wypozyczenie> wyporzyczeniaList = new List<Wypozyczenie>();
        static int id_w = 1;
        
        public void RenderListKsiazka()
        {
            dgKsiazki.ItemsSource = null;
            dgKsiazki.ItemsSource = ksiazkaList;
        }
        public void RenderListWyporzyczenie()
        {
            dgWypozyczenia.ItemsSource = null;
            dgWypozyczenia.ItemsSource = wyporzyczeniaList;
        }
        public void ClearTbs()
        {
            tbIsbn.Clear();
            tbImie.Clear();
            dpData.ClearValue(UidProperty);
            txFilter.Clear();
            txUsuwanie.Clear(); 
        }
        public void RenderAllW()
        {
            lbLiczba.Content = "Liczba wszystkich wyporzyczen: " + wyporzyczeniaList.Count.ToString();
        }
        public MainWindow()
        {
            ksiazkaList.Add(new Ksiazka(1, 234543, "Harry Potter", "J.C. Roaling", 2008));
            ksiazkaList.Add(new Ksiazka(2, 123432, "Zbrodnia i Kara", "Dostojewski", 2012));
            ksiazkaList.Add(new Ksiazka(3, 345654, "Wesele", "Wyspianski", 2006));



            InitializeComponent();
            ClearTbs();
            RenderListWyporzyczenie();
            RenderListKsiazka();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbImie.Text))
            {
                MessageBox.Show("Proszę wprowadzić imię");
                return;
            }

            if (dpData.SelectedDate == null)
            {
                MessageBox.Show("Proszę wybrać datę");
                return;
            }

            bool ksiazkaIstnieje = false;
            foreach (var item in ksiazkaList)
            {
                if (item.ISBN == Convert.ToDouble(tbIsbn.Text))
                {
                    ksiazkaIstnieje = true;;
                }
            }

            if (!ksiazkaIstnieje)
            {
                MessageBox.Show("Książka o podanym ISBN nie istnieje");
                return;
            }
            else
            {
                Wypozyczenie wypoxyczenie = new Wypozyczenie(id_w, Convert.ToDouble(tbIsbn.Text), tbImie.Text.Trim(), dpData.SelectedDate.Value);
                wyporzyczeniaList.Add(wypoxyczenie);
                id_w++;

                ClearTbs();
                RenderListWyporzyczenie();
                RenderAllW();

                MessageBox.Show("Wypożyczenie zostało dodane pomyślnie");
            }

        
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            List<Wypozyczenie> SortedWyporzyczeniaList = new List<Wypozyczenie>();
            foreach (var item in wyporzyczeniaList)
            {
                if (item.SurName.ToLower() == txFilter.Text.ToString().ToLower())
                {
                    SortedWyporzyczeniaList.Add(item);
                }
            }
            if(SortedWyporzyczeniaList.Count > 0)
            {
                dgWypozyczenia.ItemsSource = null;
                dgWypozyczenia.ItemsSource = SortedWyporzyczeniaList;
            }else MessageBox.Show("Nie ma osoby z nazwiskiem");
            ClearTbs();
        }

        private void btnUsuwanie_Click(object sender, RoutedEventArgs e)
        {
            List<Wypozyczenie> oldWypozyczenieList = new List<Wypozyczenie>(wyporzyczeniaList);
           
            foreach (var item in oldWypozyczenieList)
            {
                if(Convert.ToInt32(txUsuwanie.Text)== item.id)
                {
                    wyporzyczeniaList.Remove(item);
                }
            }
            RenderListWyporzyczenie();
            ClearTbs();
            RenderAllW();
        }

        private void dgKsiazki_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach(Ksiazka ksiazka1 in dgKsiazki.ItemsSource)
            {
                if (ksiazka1 != null&& ksiazka1 == dgKsiazki.SelectedItem)
                {
                    tbIsbn.Text = ksiazka1.ISBN.ToString();
                }
            }
        }

        private void dgWypozyczenia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                foreach (Wypozyczenie w in wyporzyczeniaList)
                {
                    if (w != null && w == dgWypozyczenia.SelectedItem)
                    {
                        txFilter.Text = w.SurName.ToString();
                        txUsuwanie.Text = w.id.ToString();
                    }
                }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            RenderListWyporzyczenie();
        }
    }
}