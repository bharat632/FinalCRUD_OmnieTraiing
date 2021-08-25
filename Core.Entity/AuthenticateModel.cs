using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class AuthenticateModel
    {
        [Required(ErrorMessage = "User Name is required")]
        [MaxLength(100, ErrorMessage = "User Name is too large")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passowrd does not match")]
        public string ConfirmPassword { get; set; }
    }
}
