using AutoMapper;
using Hotel.BusinessLayer.IServices;
using Hotel.DtoLayer.Dtos.RoomDto;
using Hotel.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Room2Controller : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public Room2Controller(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _roomService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddRoom(RoomAddDto roomAddDto)
        {
            if (!ModelState.IsValid)//Şartlarımıza uygun değilse hata gönderdim.
            {
                return BadRequest();
            }
            var values = _mapper.Map<Room>(roomAddDto); // İlgili Entity Map'ten sonra belirtilir. Kaynak değer olarak da roomAddDto belirtildi.
            _roomService.TInsert(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateRoom(UpdateRoomDto updateRoomDto)
        {
            if (!ModelState.IsValid)//Şartlarımıza uygun değilse hata gönderdim.
            {
                return BadRequest();
            }
            var value = _mapper.Map<Room>(updateRoomDto);
            _roomService.TUpdate(value);
            return Ok("Başarıyla güncellendi");
        }
    }
}
