using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HardShop_API.Data;
using HardShop_API.Dtos;
using HardShop_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HardShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        private readonly ICustomersRepository _customersRepo;
        private readonly IAdminsRepository _adminsRepo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public AuthController(IAuthRepository authRepo, ICustomersRepository customersRepo, IAdminsRepository adminsRepo, IMapper mapper, IConfiguration config)
        {
            _authRepo = authRepo;
            _customersRepo = customersRepo;
            _adminsRepo = adminsRepo;
            _mapper = mapper;
            _config = config;
        }

        [HttpPost("customers/register")]
        public async Task<IActionResult> CustomerRegister(CustomerRegisterDto customerRegisterDto)
        {

            customerRegisterDto.FirstName = customerRegisterDto.FirstName.ToLower();
            customerRegisterDto.LastName = customerRegisterDto.LastName.ToLower();
            customerRegisterDto.Email = customerRegisterDto.Email.ToLower();

            if (await _authRepo.CustomerExists(customerRegisterDto.Email))
                return BadRequest("Email already exists");

            var customerToCreate = _mapper.Map<Customer>(customerRegisterDto);
            var createdCustomer = await _authRepo.CustomerRegister(customerToCreate, customerRegisterDto.Password);

            var customerPhone = _mapper.Map<Phone>(customerRegisterDto.Phone);
            var createdPhone = await _customersRepo.CustomerAddPhone(createdCustomer.Id, customerPhone);

            return StatusCode(201);
        }

        [HttpPost("customers/login")]
        public async Task<IActionResult> CustomerLogin(CustomerLoginDto customerLoginDto)
        {
            var customerFromRepo = await _authRepo.CustomerLogin(customerLoginDto.Email.ToLower(), customerLoginDto.Password);

            if (customerFromRepo == null)
                return Unauthorized();

            var claims = new[] {
                new Claim (ClaimTypes.NameIdentifier, customerFromRepo.Id.ToString ()),
                new Claim (ClaimTypes.Name, customerFromRepo.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                username = customerFromRepo.FirstName
            });
        }

        [HttpPost("admins/register")]
        public async Task<IActionResult> AdminRegister(AdminRegisterDto adminRegisterDto)
        {

            adminRegisterDto.FirstName = adminRegisterDto.FirstName.ToLower();
            adminRegisterDto.LastName = adminRegisterDto.LastName.ToLower();
            adminRegisterDto.Email = adminRegisterDto.Email.ToLower();

            if (await _authRepo.AdminExists(adminRegisterDto.Email))
                return BadRequest("Email already exists");

            var adminToCreate = _mapper.Map<Admin>(adminRegisterDto);
            var createdAdmin = await _authRepo.AdminRegister(adminToCreate, adminRegisterDto.Password);

            var adminPhone = _mapper.Map<Phone>(adminRegisterDto.Phone);
            var createPhone = await _adminsRepo.AdminAddPhone(createdAdmin.Id, adminPhone);

            return StatusCode(201);
        }

        [HttpPost("admins/login")]
        public async Task<IActionResult> AdminLogin(AdminLoginDto adminLoginDto)
        {
            var adminFromRepo = await _authRepo.AdminLogin(adminLoginDto.Email.ToLower(), adminLoginDto.Password);

            if (adminFromRepo == null)
                return Unauthorized();

            var claims = new[] {
                new Claim (ClaimTypes.NameIdentifier, adminFromRepo.Id.ToString ()),
                new Claim (ClaimTypes.Name, adminFromRepo.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}