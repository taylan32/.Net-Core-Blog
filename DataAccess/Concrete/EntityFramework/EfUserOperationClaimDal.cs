using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, BlogContext>, IUserOperationClaimDal
    {
        public List<UserOperationClaimDTO> GetByUserId(Expression<Func<UserOperationClaimDTO, bool>> filter = null)
        {
            using (var context = new BlogContext())
            {
                var result = from user in context.Users
                             join userClaim in context.UserOperationClaims
                             on user.Id equals userClaim.UserId
                             join operationClaim in context.OperationClaims
                             on userClaim.OperationClaimId equals operationClaim.Id
                             select new UserOperationClaimDTO
                             {
                                 UserId = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 OperationClaimId = operationClaim.Id,
                                 OperationClaimName = operationClaim.Name
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public List<UserOperationClaimDTO> GetUsersByOperationClaimId(Expression<Func<UserOperationClaimDTO, bool>> filter = null)
        {
            using (var context = new BlogContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userClaim in context.UserOperationClaims
                             on operationClaim.Id equals userClaim.OperationClaimId
                             join user in context.Users
                             on userClaim.UserId equals user.Id
                             select new UserOperationClaimDTO
                             {
                                 UserId = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 OperationClaimId = operationClaim.Id,
                                 OperationClaimName = operationClaim.Name
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
            
        }
    }
}
