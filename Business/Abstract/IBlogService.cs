using Core.Utilities.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlogService : IEntityServiceBase<Blog>
    {
        IResult SetBlogStatus(int blogId, bool status);
        IDataResult<List<Blog>> GetBlogsByWriterId(int writerId);
    }
}
