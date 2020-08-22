using System.Threading.Tasks;
using AutoMapper;
using HardShop_API.Data;
using HardShop_API.Dtos;
using HardShop_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace HardShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminsRepository _adminsRepo;
        private readonly IMapper _mapper;
        public AdminsController(IAdminsRepository adminsRepo, IMapper mapper)
        {
            _adminsRepo = adminsRepo;
            _mapper = mapper;
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> AdminAddPhone(int id, PhoneCreateDto phoneCreateDto)
        {

            var phoneToCreate = _mapper.Map<Phone>(phoneCreateDto);

            var adminPhoneExist = await _adminsRepo.AdminPhoneExists(id, phoneToCreate);

            if (adminPhoneExist)
                return BadRequest("This phone number already exists in you account.");

            await _adminsRepo.AdminAddPhone(id, phoneToCreate);

            return StatusCode(201);
        }
    }
}