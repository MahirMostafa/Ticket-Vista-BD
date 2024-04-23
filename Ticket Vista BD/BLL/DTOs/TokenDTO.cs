using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TokenDTO
    {
        [Required]
        public string TokenKey { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
