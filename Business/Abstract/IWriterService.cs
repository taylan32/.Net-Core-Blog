using Core.Utilities.Results;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWriterService : IEntityServiceBase<Writer>
    {
        IDataResult<List<WriterDetailDto>> GetWritersDetails();
        IDataResult<WriterDetailDto> GetWriterDetailById(int writerId);
    }
}
