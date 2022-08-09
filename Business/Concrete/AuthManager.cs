using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Hashing;
using Core.Utilities.Jwt;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Admin;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IAdminUserService _adminService;

        public AuthManager(ITokenHelper tokenHelper, IAdminUserService userService)
        {
            _tokenHelper = tokenHelper;
            _adminService = userService;
        }

        public IDataResult<AccessToken> CreateAccessToken(Admin admin)
        {
            var claims = _adminService.GetClaims(admin);
            var accessToken = _tokenHelper.CreateToken(admin, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<Admin> Login(AdminForLoginDto userForLoginDto)
        {
            var userToCheck = _adminService.GetByUserName(userForLoginDto.UserName);
            if (userToCheck == null)
            {
                return new ErrorDataResult<Admin>(Messages.AdminNotFound);
            }

            if (userToCheck.Password != userForLoginDto.Password)
            {
                return new ErrorDataResult<Admin>(Messages.PasswordError);
            }

            //if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            //{
            //    return new ErrorDataResult<Admin>(Messages.PasswordError);
            //}

            return new SuccessDataResult<Admin>(userToCheck, Messages.SuccessfulLogin);
        }

        [ValidationAspect(typeof(AdminForRegisterDtoValidator))]            //When we give null reference to status it throws unwanted message...
        public IDataResult<Admin> Register(AdminForRegisterDto adminForRegisterDto)
        {
            //HashingHelper.CreatePasswordHash(adminForRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var admin = new Admin
            {
                UserName = adminForRegisterDto.UserName,
                Password = adminForRegisterDto.Password,
                Status = adminForRegisterDto.Status
            };
            _adminService.Add(admin);
            return new SuccessDataResult<Admin>(admin, Messages.AdminRegistered);
        }

        public IResult UserExists(string userName)
        {
            if (_adminService.GetByUserName(userName) != null)
            {
                return new ErrorResult(Messages.AdminAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}