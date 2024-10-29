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

    public partial class AddOption : Window
    {
        private Book bok;

        public AddOption(Book bok)
        {
            InitializeComponent();
            this.bok = bok;
            AddTitleTextBox.Text = "Tytul ksiazki";
            AddAuthorTextBox.Text = "Autor ksiazki";
            AddYearTextBox.Text = "Rok publikacji";
            AddGenreTextBox.Text = "Gatunek ksiazki";
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            bok.Title = AddTitleTextBox.Text;
            bok.Author = AddAuthorTextBox.Text;
            bok.Year = int.Parse(AddYearTextBox.Text);
            bok.Genre = AddGenreTextBox.Text;
            this.Close();
        }
    }
}