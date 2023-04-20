using Hotel.WebUI.Models.StaffViewModels;
using Hotel.WebUI.Models.TestimonialViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hotel.WebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            //  IHttpClientFactory, .NET Core tarafından sunulan bir arabirimdir ve HTTP istekleri göndermek için kullanılan HttpClient sınıfını yönetmek için bir fabrika modeli sağlar.
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient(); // Bir tane istemci oluşturdum.
            var responseMesaj = await client.GetAsync("http://localhost:5212/api/Testimonial"); // Hangi url'e istekte bulunacağımı belirttim ve listeleme için GetAsync kullandım. 
            if (responseMesaj.IsSuccessStatusCode)// Eğer başarılı durum kodu dönerse
            {
                var jsonData = await responseMesaj.Content.ReadAsStringAsync();//response mesajın içeriğini Async olarak oku.
                var values = JsonConvert.DeserializeObject<List<TestimonialViewModel>>(jsonData);// Gelen veriyi Deserialize et dedim.
                // Verileri listeleme yapmak istediğim için ModelView'ı List yöntemiyle kullandım.
                return View(values);

            }
            return View();
        }

        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTestimonial(TestimonialViewModel addStaffViewModel)
        {
            var client = _httpClientFactory.CreateClient();// Bir tane istemci oluşturdum.
            var jsonData = JsonConvert.SerializeObject(addStaffViewModel);// Gönderdiğimiz datayı Json türüne çevireceğimiz için burada Serialize işlemi yapılır.
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5212/api/Testimonial", stringContent); // Ekleme yapıcağım için PostAsync kullandım.
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();// Bir tane istemci oluşturdum.
            var responseMessage = await client.DeleteAsync($"http://localhost:5212/api/Testimonial/{id}"); // Silme yapıcağım için DeleteAsync kullandım. $ sembolü ile ilgili id parametresini URL.2nin yanında belirttim.
            if (responseMessage.IsSuccessStatusCode) //Başarılı dönerse
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient(); //İstemciyi oluşturdum. 
            var responseMessage = await client.GetAsync($"http://localhost:5212/api/Testimonial/{id}"); // Güncellemek istediğim verileri GetAsync ile getirdim.
            if (responseMessage.IsSuccessStatusCode)//Başarılı dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();// Index Action daki gibi verinin içeriğini ReadasString metoduyla karşılamış olduk.
                var values = JsonConvert.DeserializeObject<TestimonialViewModel>(jsonData);// jsonData ile karşılanan veriyi Deserialize yaptık.
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(TestimonialViewModel updateStaffViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateStaffViewModel); // ModelView'dan gelen veriyi Serialize ettim.
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5212/api/Testimonial/", stringContent);
            if (responseMessage.IsSuccessStatusCode)//Başarılı dönerse
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
