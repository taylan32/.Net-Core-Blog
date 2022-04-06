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
    public class CommentManager : ICommentService
    {
        private ICommentDal _commentDal;
        private IWriterService _writerService;
        public CommentManager(ICommentDal commentDal, IWriterService writerService)
        {
            _commentDal = commentDal;
            _writerService = writerService;
        }
        [ValidationAspect(typeof(CommentValidator))]
        public Result Add(Comment comment)
        {
            _commentDal.Add(comment);
            return new SuccessResult(Messages.Added);
        }

        public Result Delete(Comment comment)
        {
            if(!GetById(comment.Id).Success)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _commentDal.Delete(comment);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Comment>> GetAll()
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Comment> GetById(int id)
        {
            var result = _commentDal.Get(c => c.Id == id);
            if(result == null)
            {
                return new ErrorDataResult<Comment>(Messages.NotFound);
            }
            return new SuccessDataResult<Comment>(result, Messages.Listed);
        }

        public IDataResult<List<Comment>> GetCommnetsByWriterId(int writerId)
        {
            if(!_writerService.GetById(writerId).Success)
            {
                return new ErrorDataResult<List<Comment>>("Writer " + Messages.NotFound);
            }
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(c => c.WriterId == writerId), Messages.Listed);
        }

        [ValidationAspect(typeof(CommentValidator))]
        public Result Update(Comment comment)
        {
            if (!GetById(comment.Id).Success)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _commentDal.Update(comment);
            return new SuccessResult(Messages.Updated);
        }
    }
}
