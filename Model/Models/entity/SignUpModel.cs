using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.entity
{
    public class SignUpModel
    {
        [Required]
        public string hoTen {  get; set; }

        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string ConfirmPassword { get; set; } = null!;
    }
}
