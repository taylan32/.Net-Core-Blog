using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        [ValidationAspect(typeof(UserOperationClaimValidator))]
        public Result Add(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult(Messages.Added);
        }

        public Result Delete(UserOperationClaim userOperationClaim)
        {
            if (_userOperationClaimDal.Get(x => x.Id == userOperationClaim.Id) == null) 
            {
                return new ErrorResult(Messages.NotFound);
            }
            _userOperationClaimDal.Delete(userOperationClaim);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<UserOperationClaimDTO>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<UserOperationClaimDTO>>
                (_userOperationClaimDal.GetByUserId(u=>u.UserId == userId), Messages.ClaimListed);
        }

        public IDataResult<List<UserOperationClaimDTO>> GetUsersByOperationClaimId(int operationClaimId)
        {
            return new SuccessDataResult<List<UserOperationClaimDTO>>
                (_userOperationClaimDal.GetUsersByOperationClaimId(c=>c.OperationClaimId == operationClaimId), 
                Messages.ClaimListed);
        }
    }
}
