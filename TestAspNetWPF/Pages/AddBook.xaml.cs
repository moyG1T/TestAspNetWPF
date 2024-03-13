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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestAspNetWPF.Components;
using TestAspNetWPF.ViewModels;

namespace TestAspNetWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddBook.xaml
    /// </summary>
    public partial class AddBook : Page
    {
        private BookViewModel bookViewModel;
        public AddBook(BookViewModel _bookViewModel)
        {
            InitializeComponent();

            bookViewModel = _bookViewModel;
            DataContext = bookViewModel.SelectedBook;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
            bookViewModel.SelectedBook = null;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            TitleBox.CaretIndex = TitleBox.Text.Length;
            TitleBox.ScrollToEnd();

            AuthorBox.CaretIndex = AuthorBox.Text.Length;
            AuthorBox.ScrollToEnd();

            CostBox.CaretIndex = CostBox.Text.Length;
            CostBox.ScrollToEnd();

            PageCountBox.CaretIndex = PageCountBox.Text.Length;
            PageCountBox.ScrollToEnd();

            TitleBox.Focus();
        }
    }
}
