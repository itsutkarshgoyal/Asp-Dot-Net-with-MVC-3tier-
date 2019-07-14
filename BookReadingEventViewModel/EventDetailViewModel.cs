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
    public class EventDetailViewModel
    {
        public EventDetailViewModel()
        {
            this.comments = new HashSet<comment>();
            this.Invitations = new HashSet<Invitation>();
        }
        [DisplayName("Created By")]
        [Required]
        public int created_by { get; set; }
        [DisplayName("Event Id")]
        [Required]
        public int Event_id { get; set; }
        [DisplayName("Title")]
        [Required]
        public string title { get; set; }
        [DisplayName("Location")]
        [Required]
       
        public string location { get; set; }
        [DisplayName("Start Time")]
        [Required]
        public System.DateTime start_time { get; set; }
        [DisplayName("Type")]
        [Required]
        public string type { get; set; }
        [DisplayName("Duration")]
        [Range(1,4)]
        public string duration { get; set; }
        [DisplayName("Description")]
        [StringLength(50, ErrorMessage = "Can contain only 50 characters")]
        public string description { get; set; }
        [StringLength(500, ErrorMessage = "Can contain only 500 characters")]
        [DisplayName("Other Details")]
        public string other_details { get; set; }
        [DisplayName("Invitations")]
        public string invitation { get; set; }
        public virtual ICollection<comment> comments { get; set; }
        public virtual ICollection<Invitation> Invitations { get; set; }
    }
}
