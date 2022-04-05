using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserOperationClaimService
    {
        Result Add(UserOperationClaim userOperationClaim);
        Result Delete(UserOperationClaim userOperationClaim);
        IDataResult<List<UserOperationClaimDTO>> GetByUserId(int userId);
        IDataResult<List<UserOperationClaimDTO>> GetUsersByOperationClaimId(int operationClaimId);

    }
}
