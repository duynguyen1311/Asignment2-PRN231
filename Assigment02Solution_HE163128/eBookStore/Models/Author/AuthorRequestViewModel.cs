using System.ComponentModel.DataAnnotations;

namespace eBookStore.Models.Author
{
    public class AuthorRequestViewModel
    {
        public int author_id { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string email_address { get; set; }
        public string? phone { get; set; }
        public string? address { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? zip { get; set; }
        public bool IsEdited { get; set; }

    }
}
