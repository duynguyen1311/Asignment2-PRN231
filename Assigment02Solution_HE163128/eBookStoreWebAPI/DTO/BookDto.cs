using BusinessObject.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBookStoreWebAPI.DTO
{
    public class BookAuthorDTO
    {
        public BookDTO Book { get; set; }
        public AuthorDTO Author { get; set; }
        public DateTime? author_order { get; set; }
        public double? royalty_percentage { get; set; }
    }

    public class AuthorDTO
    {
        public int author_id { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }        
    }

    public class BookDTO
    {
        public int book_id { get; set; }
        public string title { get; set; }
        public int type { get; set; }
        public int? pub_id { get; set; }
        public PublisherBookDTO? Publisher { get; set; }
        public double price { get; set; }
        public double? advance { get; set; }
        public int? royalty { get; set; }
        public double? ytd_sales { get; set; }
        public string? notes { get; set; }
        public DateTime? published_date { get; set; }
    }

}
