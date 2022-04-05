using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserOperationClaimDal : IEntityRepository<UserOperationClaim>
    {
        List<UserOperationClaimDTO> GetByUserId(Expression<Func<UserOperationClaimDTO, bool>> filter = null);
        List<UserOperationClaimDTO> GetUsersByOperationClaimId(Expression<Func<UserOperationClaimDTO, bool>> filter = null);
    }
}
