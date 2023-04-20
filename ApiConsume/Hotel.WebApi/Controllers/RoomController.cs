using Hotel.BusinessLayer.IServices;
using Hotel.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService )
        {
            _roomService = roomService;
        }

        [HttpGet] //Veri listeleme işlemleri yapılacak.
        public IActionResult Roomlist()
        {
            var values = _roomService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddRoom(Room room)
        {
            _roomService.TInsert(room);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteRoom(int id)
        {
            var model = _roomService.TGetByID(id);
            _roomService.TDelete(model);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateRoom(Room room)
        {
            _roomService.TUpdate(room);
            return Ok();
        }

        [HttpGet("{id}")] //Dışarıdan id parametresi göndericem.
        public IActionResult GetRoom(int id)
        {
            var models = _roomService.TGetByID(id);
            return Ok(models);
        }
    }
}
