using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int user_id { get; set; }
        [Required]
        [StringLength(50)]
        public string email_address { get; set; }
        [Required]
        [StringLength(50)]
        public string password { get; set; }
        public string? source { get; set; }
        [Required,StringLength(50)]
        public string first_name { get; set; }
        [Required,StringLength(50)]
        public string middle_name { get; set; }
        [Required,StringLength(50)]
        public string last_name { get; set;}

        [ForeignKey("Role")]
        public int? role_id { get; set; }
        public Role? Role { get; set; }

        [ForeignKey("Publisher")]
        public int? pub_id { get; set; }
        public Publisher? Publisher { get; set; }

        public DateTime? hire_date { get; set; }

    }
}
