using Library.ModelView;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    [Table("SetOfBooks")]
    public class SetBooks
    {
        public int id { get; set; }
        public string setName { get; set; }
        public int Height { get; set; }

        public int? BookcaseId { get; set; }

        public Bookcase Bookcase { get; set; }
        public List<Book> bookList { get; set; } = new List<Book>();
        [NotMapped]
        public List<BookInSet> bookListModel { get; set; } = new List<BookInSet>();




    }
}
