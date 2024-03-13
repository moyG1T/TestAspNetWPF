using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using TestAspNetWPF.Components;
using TestAspNetWPF.ViewModels;

namespace TestAspNetWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для BookShell.xaml
    /// </summary>
    public partial class BookShell : Page
    {
        private BookViewModel bookViewModel;
        public BookShell(BookViewModel _bookViewModel)
        {
            InitializeComponent();
            bookViewModel = _bookViewModel;
            DataContext = bookViewModel;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddBook(bookViewModel));
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            bookViewModel.SelectedBook = (sender as Button).DataContext as Book;
            NavigationService.Navigate(new AddBook(bookViewModel));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            bookViewModel.Books.Remove((sender as Button).DataContext as Book);
        }
    }
}
