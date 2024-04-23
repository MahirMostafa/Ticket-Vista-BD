using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Advertise
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Advertiser")]
        public int AdvertiserId { get; set; }  
        public virtual Advertiser Advertiser { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int TicketPrice { get; set; }
        [Required]
        public string Status { get; set; }
    }
}