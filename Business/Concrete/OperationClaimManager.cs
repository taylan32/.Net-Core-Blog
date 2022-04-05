using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        private IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }


        [ValidationAspect(typeof(OperationClaimValidator))]
        public Result Add(OperationClaim operationClaim)
        {
            _operationClaimDal.Add(operationClaim);
            return new SuccessResult(Messages.Added);
        }

        public Result Delete(OperationClaim operationClaim)
        {
            if(GetById(operationClaim.Id).Data == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _operationClaimDal.Delete(operationClaim);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<OperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll(), Messages.ClaimListed);
        }
        public IDataResult<OperationClaim> GetById(int id)
        {
            var result = _operationClaimDal.Get(c => c.Id == id);
            if(result == null )
            {
                return new ErrorDataResult<OperationClaim>(Messages.NotFound);
            }
            return new SuccessDataResult<OperationClaim>(result, Messages.ClaimListed);
        }
    }
}
