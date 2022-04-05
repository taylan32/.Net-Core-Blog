using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfWriterDal : EfEntityRepositoryBase<Writer, BlogContext>, IWriterDal
    {
        public List<WriterDetailDto> GetWriterDetail(Expression<Func<WriterDetailDto, bool>> filter = null)
        {
            using (var context = new BlogContext())
            {
                var result = from writer in context.Writers
                             join user in context.Users
                             on writer.UserId equals user.Id
                             select new WriterDetailDto
                             {
                                 WriterId = writer.WriterId,
                                 UserId = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 About = writer.About
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
