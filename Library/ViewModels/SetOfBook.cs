using Library.Models;
using Library.ModelView;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.ViewModels
{
    public class SetOfBook
    {

        public string setName { get; set; }
        public int Height { get; set; }

        public int? BookcaseId { get; set; }

        public List<Book> bookList { get; set; } = new List<Book>();
        public List<BookInSet> bookListModel { get; set; } = new List<BookInSet>();
    }
}
