using Core.DataAccess.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAdminUserDal : EfEntityRepositoryBase<Admin, AccountingContext>, IAdminUserDal
    {
        public List<OperationClaim> GetClaims(Admin admin)
        {
            using var context = new AccountingContext();
            var result = from operationClaim in context.OperationClaims
                         join adminOperationClaim in context.AdminOperationClaims
                         on operationClaim.Id equals adminOperationClaim.OperationClaimId
                         where adminOperationClaim.AdminId == admin.Id
                         select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            return result.ToList();
        }
    }
}
