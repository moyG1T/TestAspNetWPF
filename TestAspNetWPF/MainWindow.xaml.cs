using System.Windows;
using TestAspNetWPF.Pages;
using TestAspNetWPF.ViewModels;

namespace TestAspNetWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BookViewModel bookViewModel;
        public MainWindow()
        {
            InitializeComponent();
            bookViewModel = new BookViewModel();
            MainFrame.Navigate(new BookShell(bookViewModel));
        }
    }
}
