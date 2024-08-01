using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    [Table("Bookcases")]

    public class Bookcase
    {
        public int Id { get; set; } 

        public string genre { get; set; }
        public List<Shelf> shelflist { get; set; } = new List<Shelf>();
        
    }
}
