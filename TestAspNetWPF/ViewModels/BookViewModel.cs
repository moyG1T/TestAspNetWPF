using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TestAspNetWPF.Components;

namespace TestAspNetWPF.ViewModels
{
    public class BookViewModel : INotifyPropertyChanged
    {
        public BookViewModel()
        {
            Books = new ObservableCollection<Book>()
            {
                new Book() {Id = 0, Author="asd", Cost = 123, PageCount = 123, Title = "qwe"},
                new Book() {Id = 0, Author="asd", Cost = 123, PageCount = 123, Title = "qwe"},
                new Book() {Id = 0, Author="asd", Cost = 123, PageCount = 123, Title = "qwe"},
            };
        }

        private Book selectedBook;
        public Book SelectedBook
        {
            get => selectedBook;
            set
            {
                selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
            }
        }

        private IEnumerable<Book> books;
        public IEnumerable<Book> Books
        {
            get => books;
            set
            {
                books = value;
                OnPropertyChanged(nameof(Books));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
