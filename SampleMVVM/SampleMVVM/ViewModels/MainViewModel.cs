using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using SampleMVVM.Models;

namespace SampleMVVM.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        public ObservableCollection<BookViewModel> BooksList { get; set; }

        public MainViewModel(List<Book> books)
        {
            BooksList = new ObservableCollection<BookViewModel>(books.Select(b => new BookViewModel(b)));
        }
    }
}
