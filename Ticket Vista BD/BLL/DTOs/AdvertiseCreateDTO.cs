using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AdvertiseCreateDTO
    {

        [Required] 
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
        [Required]
        public int TicketPrice { get; set; }

       

    }
}
