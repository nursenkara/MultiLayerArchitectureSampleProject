using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUsersController : ControllerBase
    {

        private IAdminUserService _adminUserService;

        public AdminUsersController(IAdminUserService adminUserService)
        {
            _adminUserService = adminUserService;
        }

        [HttpGet("GetAll")]
        //[Authorize(Roles = "Admin.List")]
        public IActionResult GetList()
        {

            var result = _adminUserService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetActiveAdminList")]
        public IActionResult GetActiveAdminList()
        {
            var result = _adminUserService.GetActiveList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetInactiveBankList")]
        public IActionResult GetInactiveBankList()
        {
            var result = _adminUserService.GetInActiveList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("RemoveAdmin/{adminId}")]
        public IActionResult RemoveAdmin(int adminId)
        {
            var result = _adminUserService.Delete(adminId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
