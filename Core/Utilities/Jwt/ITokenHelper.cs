using Entities.Concrete;

namespace Core.Utilities.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(Admin admin, List<OperationClaim> operationClaims);
    }
}