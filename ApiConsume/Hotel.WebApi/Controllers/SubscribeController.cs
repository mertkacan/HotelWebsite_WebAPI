using Hotel.BusinessLayer.IServices;
using Hotel.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpGet] //Veri listeleme işlemleri yapılacak.
        public IActionResult Subscribelist()
        {
            var values = _subscribeService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddSubscribe(Subscribe  subscribe)
        {
            _subscribeService.TInsert(subscribe);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteSubscribe(int id)
        {
            var model = _subscribeService.TGetByID(id);
            _subscribeService.TDelete(model);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateSubscribe(Subscribe subscribe)
        {
            _subscribeService.TUpdate(subscribe);
            return Ok();
        }

        [HttpGet("{id}")] //Dışarıdan id parametresi göndericem.
        public IActionResult GetSubscribe(int id)
        {
            var models = _subscribeService.TGetByID(id);
            return Ok(models);
        }
    }
}
