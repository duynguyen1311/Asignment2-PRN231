using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class BookAuthor
    {
        [ForeignKey("author_id")]
        public int? author_id { get; set; }
        public Author? Author { get; set; }

        [ForeignKey("book_id")]
        public int? book_id { get; set; }
        public Book? Book { get; set; }

        public DateTime? author_order { get; set; }
        public double? royalty_percentage { get; set; }


    }
}
