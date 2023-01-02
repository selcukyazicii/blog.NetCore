using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace coreProject2.Models
{
    public class UserLoginVM
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adınızı giriniz")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenizi giriniz")]
        public string Password { get; set; }
    }
}
