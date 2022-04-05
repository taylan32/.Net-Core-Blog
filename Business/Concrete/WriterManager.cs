using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WriterManager : IWriterService
    {
        private IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        [ValidationAspect(typeof(WriterValidator))]
        public Result Add(Writer writer)
        {
            _writerDal.Add(writer);
            return new SuccessResult(Messages.Added);
        }

        public Result Delete(Writer writer)
        {
            if(!GetById(writer.UserId).Success)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _writerDal.Delete(writer);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Writer>> GetAll()
        {
            return new SuccessDataResult<List<Writer>>(_writerDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Writer> GetById(int id)
        {
            var result = _writerDal.Get(w => w.WriterId == id);
            if(result == null)
            {
                return new ErrorDataResult<Writer>(Messages.NotFound);
            }
            return new SuccessDataResult<Writer>(result, Messages.Listed);
        }

        public IDataResult<WriterDetailDto> GetWriterDetailById(int writerId)
        {
            var result = _writerDal.GetWriterDetail(w => w.WriterId == writerId);
            if(result.Count == 0)
            {
                return new ErrorDataResult<WriterDetailDto>(Messages.NotFound);
            }
            return new SuccessDataResult<WriterDetailDto>(result.ElementAt(0), Messages.Listed);
        }

        public IDataResult<List<WriterDetailDto>> GetWritersDetails()
        {
            return new SuccessDataResult<List<WriterDetailDto>>(_writerDal.GetWriterDetail(),Messages.Listed);
        }

        [ValidationAspect(typeof(WriterValidator))]
        public Result Update(Writer writer)
        {
            if(!GetById(writer.WriterId).Success)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _writerDal.Update(writer);
            return new SuccessResult(Messages.Updated);
        }
    }
}
