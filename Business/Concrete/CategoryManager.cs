using Business.Abstract;
using Business.BusinessAspects.Autofac;
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
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        //[SecuredOperation("category-add")]
        [ValidationAspect(typeof(CategoryValidator))]
        public Result Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.Added);
        }

        public Result Delete(Category category)
        {
            if(!GetById(category.Id).Success) 
            {
                return new ErrorResult(Messages.NotFound);
            }
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Category> GetById(int id)
        {
            var result = _categoryDal.Get(c => c.Id == id);
            if(result == null)
            {
                return new ErrorDataResult<Category>(Messages.NotFound);
            }
            return new SuccessDataResult<Category>(result, Messages.Listed);
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public Result Update(Category category)
        {
            if (!GetById(category.Id).Success)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _categoryDal.Update(category);
            return new SuccessResult(Messages.Updated);
        }
    }
}
