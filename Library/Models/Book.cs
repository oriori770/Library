using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    [Table("Books")]
    public class Book
    {

        public int id { get; set; }
        public string BooksName { get; set; }
        public int Height { get; set; }
        
        public int Width { get; set; }
        
        public int? BookcaseId { get; set; }

        public Bookcase Bookcase { get; set; }
        public bool IsSet { get; set; }

        public int? ShelfId {  get; set; }

        public Shelf shelf { get; set; }

        public int? SetBooksId { get; set; }
        public SetBooks setBooks { get; set; }


    }
}
