using Core.DataAccess;
using Entities.Concrete;

namespace Entities.Abstract
{
    public interface IAdminUserDal : IEntityRepository<Admin>
    {
        List<OperationClaim> GetClaims(Admin admin);
    }
}