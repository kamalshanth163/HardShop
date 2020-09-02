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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersRepository _customersRepo;
        private readonly IProductsRepository _productsRepo;
        private readonly IMapper _mapper;
        public CustomersController(ICustomersRepository customerRepo, IProductsRepository productsRepo, IMapper mapper)
        {
            _customersRepo = customerRepo;
            _productsRepo = productsRepo;
            _mapper = mapper;
        }

        [HttpPost("{id}")]

        public async Task<IActionResult> CustomerAddPhone(int id, PhoneCreateDto phoneCreateDto)
        {

            var phoneToCreate = _mapper.Map<Phone>(phoneCreateDto);

            var customerPhoneExist = await _customersRepo.CustomerPhoneExists(id, phoneToCreate);

            if (customerPhoneExist)
                return BadRequest("This phone number already exists in you account.");

            await _customersRepo.CustomerAddPhone(id, phoneToCreate);

            return StatusCode(201);
        }


        [HttpPost("{customerId}/products/{productOptionId}")]
        public async Task<IActionResult> CreateProductReview(int customerId, int productOptionId, ProductReviewCreateDto productReviewCreateDto)
        {
            var customerFromRepo = await _customersRepo.GetCustomer(customerId);
            var productOptionFromRepo = await _productsRepo.GetProductOption(productOptionId);

            var productReviewToCreate = _mapper.Map<ProductReview>(productReviewCreateDto);

            productReviewToCreate.Customer = customerFromRepo;
            productReviewToCreate.ProductOption = productOptionFromRepo;

            await _productsRepo.CreateProductReview(productReviewToCreate);

            return StatusCode(201);
        }

    }
}