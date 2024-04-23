using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int TicketPrice { get; set; }

        [ForeignKey("Advertise")]
        public int AdvertiseId { get; set; }
        public virtual Advertise Advertise { get; set; }

        [ForeignKey("Moderator")]
        public int EmpId { get; set; }

        public virtual Employee Moderator { get; set; }

    }
}
