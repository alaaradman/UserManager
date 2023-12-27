using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UserDTO : GenericDTO
    {

        public override string? Id { get; set; } 
        [Required(ErrorMessage ="Name is Required")]
        public override string Name { get; set; } = null!;
        [Required(ErrorMessage = "UserName is Required")]
        public string Username { get; set; } = null!;
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Phone is Required")]
        public string Phone { get; set; } = null!;
        public string Salt { get; set; } = null!;
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "ConfirmPassword is Required")]
        public string ConfirmPassword { get; set; } = null!;
        public string profile { get; set; } = null!;
        public bool AccountStatus { get; set; }


    }
}
