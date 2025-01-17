﻿using Core.Utilities.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommentService : IEntityServiceBase<Comment>
    {
        IDataResult<List<Comment>> GetCommnetsByWriterId(int writerId);
    }
}
