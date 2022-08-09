using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class AdminOperationClaim : IEntity
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
