using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    [Table("Shelfs")]
    public class Shelf
    {
        public int Id {  get; set; }   
        
        public int Weidth { get; set; }
        public int Height { get; set; }

        public int  BookcaseId {  get; set; }

        public Bookcase Bookcase { get; set; } = null!;
        public  List<Book> Books { get; set; } = new List<Book>();


    }
}
