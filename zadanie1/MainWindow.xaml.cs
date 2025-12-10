using System.Collections.ObjectModel;
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
using System.Xml;
using Newtonsoft.Json;
using System.IO;

namespace JsonEdit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private string filePath = "data.json";
        private ObservableCollection<Book> books;

        public MainWindow()
        {
            InitializeComponent();
            books = new ObservableCollection<Book>();
            JsonListBox.ItemsSource = books;
        }

        private void LoadJson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                books = JsonConvert.DeserializeObject<ObservableCollection<Book>>(json);
                
                JsonListBox.ItemsSource = books;

                int rok = 2024;
                foreach(Book book in books)
                {
                    if(book.Year < rok) rok = book.Year;
                }
                TbStarsza.Text = $"Najstarsza ksiazka z roku: {rok.ToString()}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading JSON: {ex.Message}");
            }
        }

        private void SaveJson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string json = JsonConvert.SerializeObject(books, Newtonsoft.Json.Formatting.Indented);

                File.WriteAllText(filePath, json);
                MessageBox.Show("JSON saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving JSON: {ex.Message}");
            }

        }

        private void EditJson_Click(object sender, RoutedEventArgs e)
        {
            if (JsonListBox.SelectedItem is Book selectedBook)
            {
                var editWindow = new EditWindow(selectedBook);
                editWindow.ShowDialog();
            }
        }

        private void DeleteJson_Click(object sender, RoutedEventArgs e)
        {
            if (JsonListBox.SelectedItem is Book selectedBook)
            {
                books.Remove(selectedBook);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                string json = File.ReadAllText(filePath);
                books = JsonConvert.DeserializeObject<ObservableCollection<Book>>(json);

                foreach(Book book in books)
                {
                    if (book.Title.ToString().ToLower() == TbSearch.Text.ToString().ToLower())
                    {
                        LbShow.Items.Clear();
                        LbShow.Items.Add(" tytul: " +book.Title +" autor: "+ book.Author+" rok: "+book.Year);
                    }
                    
                }
               // books.CopyTo(lista,0);
               // foreach(var el in lista)
               // {
               //    JsonListBox.Items.Add(el);
               // }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading JSON: {ex.Message}");
            }
        
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Book bok = new Book();
                string json = File.ReadAllText(filePath);
                books = JsonConvert.DeserializeObject<ObservableCollection<Book>>(json);
                var editWindow = new AddOption(bok);
                editWindow.ShowDialog();
                books.Add(bok);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading JSON: {ex.Message}");
            }
        }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
    }
}
