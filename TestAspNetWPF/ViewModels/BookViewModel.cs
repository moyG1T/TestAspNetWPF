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
                new Book() {Id = 123, Author="asd", Title ="qwe", Cost=123,PageCount=32},
            };
        }

        private Book selectedBook;
        public Book SelectedBook
        {
            get => selectedBook ?? new Book();
            set
            {
                selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
            }
        }

        public ObservableCollection<Book> Books { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
