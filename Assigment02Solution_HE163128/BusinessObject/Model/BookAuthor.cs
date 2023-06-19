using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class BookAuthor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Author")]
        public int? author_id { get; set; }
        public virtual Author? Author { get; set; }

        [ForeignKey("Book")]
        public int? book_id { get; set; }
        public virtual Book? Book { get; set; }

        public DateTime? author_order { get; set; }
        public double? royalty_percentage { get; set; }


    }
}
