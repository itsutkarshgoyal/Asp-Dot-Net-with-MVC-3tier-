using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingEventViewModel
{
    public class InvitationViewModel
    {
        [DisplayName("Id")]
        [Required]
        public int id { get; set; }
        public Nullable<int> Event_id { get; set; }
        [DisplayName("Email")]
        [Required]
        public string email { get; set; }

        public virtual EventDetail EventDetail { get; set; }
    }
}
