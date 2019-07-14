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
   public class CommentsViewModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Event Id")]
        public int Event_id { get; set; }
        [DisplayName("Description")]
        [Required]
        public string description { get; set; }
        public Nullable<System.DateTime> created_on { get; set; }
        public Nullable<System.DateTime> modified_on { get; set; }
        [DisplayName("Created By")]
        public int created_by { get; set; }

        public virtual EventDetail EventDetail { get; set; }
        public virtual UserDetail UserDetail { get; set; }
    }
}
