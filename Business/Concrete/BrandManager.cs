using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator), Priority = 1)]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(int brandId)
        {
            var brand = _brandDal.Get(b => b.BrandId == brandId);
            if (brand != null)
            {
                _brandDal.Delete(brand);
                return new SuccessResult(Messages.BrandDeleted);
            }
            return new ErrorResult(Messages.BrandNotFound);
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(p => p.BrandId == brandId), Messages.BrandListed);
        }

        public IDataResult<List<Brand>> GetList()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetList().ToList(), Messages.BrandsListed);
        }

        [ValidationAspect(typeof(BrandValidator), Priority = 1)]
        public IResult Update(Brand brand)
        {
             _brandDal.Update(brand);
             return new SuccessResult(Messages.BrandUpdated);


        }


        #region BrandNameControl
        private IResult CheckIfBrandNameExists(string brandName)
        {
            var bank = _brandDal.Get(b => b.BrandName == brandName);
            if (bank == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.BrandAlreadyExists);
        }
        #endregion
    }
}
