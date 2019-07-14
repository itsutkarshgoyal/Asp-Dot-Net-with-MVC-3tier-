using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingEventViewModel
{
    public class UserDetailViewModel
    {
        public UserDetailViewModel()
        {
            this.comments = new HashSet<comment>();
        }
        [DisplayName("Id")]
        [Required]
        public int id { get; set; }
        [DataType("text")]
        [DisplayName("First Name")]
        [Required]
        public string first_name { get; set; }
        [DataType("text")]
        [DisplayName("Last Name")]
        [Required]
        public string last_name { get; set; }
        [DisplayName("Password")]
        [Required]
        [RegularExpression("(?=.*[@#$%]).{5,20}",
            ErrorMessage = "Must be between 5 and 20 character and contain special character ")]
        [DataType("password")]
        public string password { get; set; }

        [DisplayName("Role")]
         [Required]
        public string role { get; set; }
        [DisplayName("Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$",
            ErrorMessage = "E-mail is not valid")]
        [Required]
        public string email { get; set; }
        public virtual ICollection<comment> comments { get; set; }
    }
}
