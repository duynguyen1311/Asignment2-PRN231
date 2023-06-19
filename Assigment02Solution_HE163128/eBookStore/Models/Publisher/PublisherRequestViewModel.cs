using System.ComponentModel.DataAnnotations;

namespace eBookStore.Models.Publisher
{
    public class PublisherRequestViewModel
    {
        public int pub_id { get; set; }
        public string publisher_name { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? country { get; set; }
        public bool IsEdited { get; set; }
    }
}
