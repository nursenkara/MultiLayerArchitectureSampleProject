using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Caching;
using Core.Aspects.AutoFac.Logging;
using Core.Aspects.AutoFac.Performance;
using Core.Aspects.AutoFac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId),"Product is successfully listed!");
        }

        [PerformanceAspect(5)]
        public IDataResult<List<ProductListModel>> GetList()
        {
            //Thread.Sleep(5000);
            var list = _productDal.GetList().ToList();
            var models = ProductToProductModel(list);

            return new SuccessDataResult<List<ProductListModel>>(models,Messages.ProductListed);

        } 

        //[SecuredOperation("Product.List,Admin")]
        [LogAspect(typeof(FileLogger))]
        [CacheAspect(duration: 10)]
        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(p => p.CategoryId == categoryId).ToList(), "Products are successfully listed group by category!");
        }


        [ValidationAspect(typeof(ProductValidator), Priority = 1)]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName));

            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        private IResult CheckIfProductNameExists(string productName)
        {

            var result = _productDal.GetList(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }

            return new SuccessResult();
        }


        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IResult Update(Product product)
        {

            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        private List<ProductListModel> ProductToProductModel(List<Product> products)
        {

            var models = new List<ProductListModel>();
            foreach (var product in products)
            {
                var categoryName = _categoryService.GetById(product.CategoryId).Data;
                models.Add(new ProductListModel
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    CategoryName = categoryName.CategoryName,
                    UnitPrice = product.UnitPrice,
                    UnitsInStock = product.UnitsInStock
                });
            }

            return models;
        }
       
    }
}
