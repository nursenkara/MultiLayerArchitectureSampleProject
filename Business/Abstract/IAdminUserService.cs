using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAdminUserService
    {
        List<OperationClaim> GetClaims(Admin admin);
        void Add(Admin admin);
        Admin GetByUserName(string userName);
        IDataResult<Admin> GetById(int userId);
        int GetAdminUserId();
        IDataResult<List<Admin>> GetList();
        IDataResult<List<Admin>> GetActiveList();
        IDataResult<List<Admin>> GetInActiveList();
        IResult Delete(int adminUserId);

    }
}