using Business.Abstract;
using Entities.Dtos.Customers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet("GetAllCustomerList")]
        public IActionResult GetCustomerList()
        {
            var result = _customerService.GetList();
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet("GetActiveCustomerList")]
        public IActionResult GetActiveCustomerList()
        {
            var result = _customerService.GetActiveList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetInActiveCustomerList")]
        public IActionResult GetInActiveCustomerList()
        {
            var result = _customerService.GetInActiveList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByCustomerId/{customerId}")]
        public IActionResult GetCustomerById(int id)
        {
            var result = _customerService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result); 
        }

        [HttpGet("GetCustomerByName")]
        public IActionResult GetCustomerByName(string name)
        {
            var result = _customerService.GetByName(name);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("CreteCustomer")]
        public IActionResult CreateCustomer(AddCustomerDto addCustomerDto)
        {
            var result = _customerService.Add(addCustomerDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
