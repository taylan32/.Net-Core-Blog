using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {
        private IBlogDal _blogDal;
        private IWriterService _writerService;

        public BlogManager(IBlogDal blogDal, IWriterService writerService)
        {
            _blogDal = blogDal;
            _writerService = writerService;
        }

        [ValidationAspect(typeof(BlogValidator))]
        public Result Add(Blog blog)
        {
            blog.CreatedAt = DateTime.Now;
            _blogDal.Add(blog);
            return new SuccessResult(Messages.Added);
        }

        public Result Delete(Blog blog)
        {
            if(!GetById(blog.Id).Success)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _blogDal.Delete(blog);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Blog>> GetAll()
        {
            return new SuccessDataResult<List<Blog>>(_blogDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<Blog>> GetBlogsByWriterId(int writerId)
        {
            if(!_writerService.GetById(writerId).Success)
            {
                return new ErrorDataResult<List<Blog>>("Writer " + Messages.NotFound);
            }
            return new SuccessDataResult<List<Blog>>(_blogDal.GetAll(b => b.WriterId == writerId), Messages.Listed);
        }

        public IDataResult<Blog> GetById(int id)
        {
            var result = _blogDal.Get(b => b.Id == id);
            if(result == null)
            {
                return new ErrorDataResult<Blog>(Messages.NotFound);
            }
            return new SuccessDataResult<Blog>(result, Messages.Listed);
        }

        public IResult SetBlogStatus(int blogId, bool status)
        {
            var blog = GetById(blogId);
            if(!blog.Success)
            {
                return new ErrorResult(Messages.NotFound);
            }
            blog.Data.Status = status;
            return new SuccessResult(Messages.Updated);
        }

        [ValidationAspect(typeof(BlogValidator))]
        public Result Update(Blog blog)
        {
            if (!GetById(blog.Id).Success)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _blogDal.Update(blog);
            return new SuccessResult(Messages.Deleted);
        }

        
    }
}
