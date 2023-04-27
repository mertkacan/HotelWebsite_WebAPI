using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Hotel.WebUI.Dtos.AppUserDto
{
    public class CreateNewUserDto
    {
       
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public string Password { get; set; } = null!;

        [Compare("Password",ErrorMessage ="Şifre, Password ile eşleşmiyor")]
        public string ConfirmPassword { get; set; } = null!;
        
    }
}
