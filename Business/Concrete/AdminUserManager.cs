using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Business.Concrete
{
    public class AdminUserManager : IAdminUserService
    {
        private readonly IAdminUserDal _adminDal;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminUserManager(IAdminUserDal adminDal, IHttpContextAccessor httpContextAccessor)
        {
            _adminDal = adminDal;
            _httpContextAccessor = httpContextAccessor;
        }

        public void Add(Admin admin)
        {
            _adminDal.Add(admin);
        }

        public Admin GetByUserName(string userName)
        {
            return _adminDal.Get(u => u.UserName == userName);
        }

        public List<OperationClaim> GetClaims(Admin admin)
        {
            return _adminDal.GetClaims(admin);
        }

        public int GetAdminUserId()
        {
            return int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }

        public IDataResult<List<Admin>> GetList()
        {
            return new SuccessDataResult<List<Admin>>(_adminDal.GetList().ToList(),Messages.AdminsListed);
        }

        public IDataResult<Admin> GetById(int userId)
        {
            return new SuccessDataResult<Admin>(_adminDal.Get(p => p.Id == userId),Messages.AdminListed);
        }
    }
}