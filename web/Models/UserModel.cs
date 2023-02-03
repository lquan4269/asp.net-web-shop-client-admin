using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace web.Models
{

        public class RegisterModel
        {
            [Required]
            [MinLength(4, ErrorMessage = "Chiều dài tối thiểu là 4 ký tự")]
            [MaxLength(60, ErrorMessage = "Chiều dài tối đa là 60 ký tự")]
            public String Name { get; set; }

            [Required]
            [EmailAddress(ErrorMessage = "Không đúng định dạng email")]
            public String Email { get; set; }

            public String Phone { get; set; }
            public String Adress { get; set; }

            [Required]
            [MinLength(4, ErrorMessage = "Chiều dài tối thiểu là 4 ký tự")]
            [MaxLength(60, ErrorMessage = "Chiều dài tối đa là 60 ký tự")]
            public String Password { get; set; }
            [Compare("Password", ErrorMessage = "Mật khẩu không trùng khớp")]
            public String CofirmPassword { get; set; }

        }

        public class LoginModel
        {
            [Required]
            [EmailAddress(ErrorMessage = "Không đúng định dạng email")]
            public string Email { get; set; }

            [Required]
            [MinLength(4, ErrorMessage = "Chiều dài tối thiểu là 4 ký tự")]
            [MaxLength(60, ErrorMessage = "Chiều dài tối đa là 60 ký tự")]
            public string Password { get; set; }
        }
    
}