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

namespace JsonEdit
{

    public partial class EditWindow : Window
    {
        private Book book;

        public EditWindow(Book book)
        {
            InitializeComponent();
            this.book = book;
            TitleTextBox.Text = book.Title;
            AuthorTextBox.Text = book.Author;
            YearTextBox.Text = book.Year.ToString();
            GenreTextBox.Text = book.Genre;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            book.Title = TitleTextBox.Text;
            book.Author = AuthorTextBox.Text;
            book.Year = int.Parse(YearTextBox.Text);
            book.Genre = GenreTextBox.Text;
            this.Close();
        }
    }
}