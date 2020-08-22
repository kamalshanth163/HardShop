using System.Threading.Tasks;
using AutoMapper;
using HardShop_API.Data;
using HardShop_API.Dtos;
using HardShop_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace HardShop_API.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersRepository _customersRepo;
        private readonly IMapper _mapper;
        public CustomersController(ICustomersRepository repo, IMapper mapper)
        {
            _customersRepo = repo;
            _mapper = mapper;
        }

        [HttpPost("{id}")]
        
        public async Task<IActionResult> CustomerAddPhone(int id, PhoneCreateDto phoneCreateDto){

            var phoneToCreate = _mapper.Map<Phone>(phoneCreateDto);

            var customerPhoneExist = await _customersRepo.CustomerPhoneExists(id, phoneToCreate);

            if(customerPhoneExist)
                return BadRequest("This phone number already exists in you account.");

            await _customersRepo.CustomerAddPhone(id, phoneToCreate);

            return StatusCode (201);
        } 

    }
}