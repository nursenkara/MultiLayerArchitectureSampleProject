using Core.Utilities.Jwt;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Admin;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<Admin> Register(AdminForRegisterDto adminForRegisterDto);
        IDataResult<Admin> Login(AdminForLoginDto adminForLoginDto);
        IResult UserExists(string userName);
        IDataResult<AccessToken> CreateAccessToken(Admin admin);
    }
}