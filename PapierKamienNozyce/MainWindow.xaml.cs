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

namespace PapierKamienNoznicy
{             
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string[] kpn = { "Kamien", "Papier", "Nozyce" };
        int licznikUser = 0;
        int licznikComp = 0;
        int iloscRund = 10;
        private void mainOb(string obiekt)
        {
            string comp = Losuj();
            string wynik = Result(obiekt, comp);
            LbWynik.Items.Add("User:  " +obiekt + " VS " + comp + "  : Computer");
            LbWynik.Items.Add(wynik);
            LbWynik.Items.Add("-------------------------------------");
            Score(wynik);
            TbIloscRund.Text = "Ilosc Rund zostalo: " + iloscRund;
        }
        private void LbKamien_Click(object sender, RoutedEventArgs e)
        {
            if (Rundy()){mainOb(LbKamien.Content.ToString());}
            else{LbWynik.Items.Clear();
                 LbWynik.Items.Add("Ilosc dostepnuch rund sie skonczyla :(");} 
        }
        private void LbPapier_Click(object sender, RoutedEventArgs e)
        {
            if (Rundy()){ mainOb(LbPapier.Content.ToString());}
            else{ LbWynik.Items.Clear();
                    LbWynik.Items.Add("Ilosc dostepnuch rund sie skonczyla :(");}   
        }
        private void LbNozyce_Click(object sender, RoutedEventArgs e)
        {
            if(Rundy()){mainOb(LbNozyce.Content.ToString());}
            else{LbWynik.Items.Clear();
                LbWynik.Items.Add("Ilosc dostepnuch rund sie skonczyla :(");}       
        }
        private string Losuj()
        {
            Random random = new Random();
           // LbWynik.Items.Add("Komputer:  "+kpn[random.Next(kpn.Length)].ToString());
            return kpn[random.Next(kpn.Length)].ToString();
        }

        private string Result(string userWynik, string compWynik)
        {
            if(userWynik == "Kamien")
            {
                if(compWynik == "Papier")
                {
                    return "RESULT: Przegrane";
                }
                else if(compWynik == "Nozyce")
                {
                    return "RESULT: Wygrane";
                }
                else
                {
                    return "RESULT: Remis";
                }
            }
            else if(userWynik == "Papier")
            {
                if (compWynik == "Papier")
                {
                    return "RESULT: Remis";
                }
                else if (compWynik == "Nozyce")
                {
                    return "RESULT: Przegrane";
                }
                else
                {
                    return "RESULT: Wygrane";
                }
            }
            else
            {
                if (compWynik == "Papier")
                {
                    return "RESULT: Wygrane";
                }
                else if (compWynik == "Nozyce")
                {
                    return "RESULT: Remis";
                }
                else
                {
                    return "RESULT: Przegrane";
                }
            }
        }
        private void Score(string result)
        {
            if (result == "RESULT: Wygrane")
            {
                licznikUser++;
                TbWynikUser.Text = licznikUser.ToString();
            }
            else if (result == "RESULT: Przegrane")
            {
                licznikComp++;
                TbWynikComp.Text = licznikComp.ToString();
            }
        }
        private bool Rundy()
        {
            if (iloscRund > 0)
            {
                iloscRund--;
                return true;
            }
            else
            {
                return false;
            }
        }   
    }
}