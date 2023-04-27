using Hotel.EntityLayer.Concrete;
using Hotel.WebUI.Dtos.AppUserDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager) // Register işlemi hangi sınıf için yapılacak onu belirtmek için AppUser class'ını belirttik.
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateNewUserDto createNewUserDto)
        {

            if (!ModelState.IsValid)// Şartlara sağlamazsa burası çalışır.
            {
                return View();
            }
            var appUser = new AppUser() // AppUser'dan yeni nesne üretip, DTO'daki değerleri burada belirttik.
            {
                Name = createNewUserDto.Name,
                Email = createNewUserDto.Mail,
                Surname = createNewUserDto.Surname,
                UserName = createNewUserDto.UserName
            };
            var result = await _userManager.CreateAsync(appUser, createNewUserDto.Password);// CreateAsync metodu Identity ile aktifleşti ve bu şekilde ekleme işlemi yapabiliriz.
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");// Login Controller içindeki Index'e yönlendir.
            }
            return View();
        }
    }
}
