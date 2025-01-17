﻿using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService : IEntityServiceBase<User>
    {
        IDataResult<List<OperationClaim>>GetClaims(User user);
        User GetByEmail(string email);
    }
}
