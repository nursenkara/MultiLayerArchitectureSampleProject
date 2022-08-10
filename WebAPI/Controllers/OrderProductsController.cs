using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductsController : ControllerBase
    {
        private IOrderProductService _orderProductService;

        public OrderProductsController(IOrderProductService orderProductService)
        {
            _orderProductService = orderProductService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetList()
        {
            var result = _orderProductService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int orderProductId)
        {
            var result = _orderProductService.GetById(orderProductId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("CreateOrderProduct")]
        public IActionResult CreateOrderProduct(OrderProduct orderProduct)
        {
            var result = _orderProductService.Add(orderProduct);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("UpdateOrderProduct")]
        public IActionResult UpdateOrderProduct(OrderProduct orderProduct)
        {
            var result = _orderProductService.Update(orderProduct);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("RemoveOrderProduct/{orderProductId}")]
        public IActionResult RemoveOrderProduct(int orderProductId)
        {
            var result = _orderProductService.Delete(orderProductId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
