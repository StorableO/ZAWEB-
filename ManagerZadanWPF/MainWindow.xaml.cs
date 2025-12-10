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


namespace ManagerZadan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<TaskEntry> _listaZadan = new List<TaskEntry>();
        int editionalID;

        public MainWindow()
        {
            InitializeComponent();
            OdswiezWidok();

        }

        private void OdswiezWidok()
        {
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = _listaZadan;
        }
        
        private void OdswiezKontrolki()
        {
            txtBoxName.Clear();
            txtBoxOpis.Clear();
            txtBoxStatus.Clear();
            dataRealizacji.SelectedDate = DateTime.Now;
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            TaskEntry entry = new TaskEntry()
            {
                Nazwa = txtBoxName.Text,
                Opis = txtBoxOpis.Text.ToString(),
                DataRealizacji = dataRealizacji.SelectedDate.Value,
                Status = txtBoxStatus.Text.ToString(),
            };

            _listaZadan.Add(entry);
            OdswiezWidok();
            OdswiezKontrolki();
            


        }

        private void usun_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem is TaskEntry zadaniedousuniecia)
            {
                _listaZadan.Remove(zadaniedousuniecia);
                OdswiezWidok();
            }
        }

        private void edytuj_Click(object sender, RoutedEventArgs e)
        {
            if(DataGrid.SelectedItem is TaskEntry idx )
            {
                editionalID = DataGrid.SelectedIndex;
                txtBoxName.Text = _listaZadan[editionalID].Nazwa;
                txtBoxOpis.Text = _listaZadan[editionalID].Opis;
                txtBoxStatus.Text = _listaZadan[editionalID].Status;
                dataRealizacji.SelectedDate = _listaZadan[editionalID].DataRealizacji;
            }
        }

        private void odswiez_Click(object sender, RoutedEventArgs e)
        {
            if (editionalID >= 0)
            {
                TaskEntry newItem = new TaskEntry
                {
                    Nazwa = txtBoxName.Text.ToString(),
                    Opis = txtBoxOpis.Text.ToString(),
                    DataRealizacji = dataRealizacji.SelectedDate.Value,
                    Status = txtBoxStatus.Text.ToString(),
                };
                _listaZadan[editionalID] = newItem;
                OdswiezWidok();
                OdswiezKontrolki();
            }
        }
    }
}