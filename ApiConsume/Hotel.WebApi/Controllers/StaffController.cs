using Hotel.BusinessLayer.IServices;
using Hotel.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet] //Veri listeleme işlemleri yapılacak.
        public IActionResult Stafflist()
        {
            var values = _staffService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddStaff(Staff staff)
        {
            _staffService.TInsert(staff);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStaff(int id)
        {
            var model = _staffService.TGetByID(id);
            _staffService.TDelete(model);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateStaff(Staff staff)
        {
            _staffService.TUpdate(staff);
            return Ok();
        }

        [HttpGet("{id}")] //Dışarıdan id parametresi göndericem.
        public IActionResult GetStaff(int id)
        {
            var models = _staffService.TGetByID(id);
            return Ok(models);
        }
    }
}
