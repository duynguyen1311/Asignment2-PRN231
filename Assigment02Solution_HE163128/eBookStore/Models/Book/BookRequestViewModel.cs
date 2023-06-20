using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eBookStore.Models.Book
{
    public class BookRequestViewModel
    {
        public int book_id { get; set; }
        public string title { get; set; }
        public int type { get; set; }
        public int? pub_id { get; set; }
        public double? price { get; set; }
        public double? advance { get; set; }
        public int? royalty { get; set; }
        public double? ytd_sales { get; set; }
        public string? notes { get; set; }
        public DateTime? published_date { get; set; }
        public bool IsEdited { get; set; }
    }
}
