using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderProductManager:IOrderProductService
    {
        private IOrderProductDal _orderProductDal;

        public OrderProductManager(IOrderProductDal orderProductDal)
        {
            _orderProductDal = orderProductDal;
        }

        public IResult Add(OrderProduct orderProduct)
        {
            _orderProductDal.Add(orderProduct);
            return new SuccessResult(Messages.OrderProductAdded);
        }

        public IResult Delete(int orderProductId)
        {
            var orderProduct = _orderProductDal.Get(b => b.OrderProductId == orderProductId);
            if (orderProduct != null)
            {
                _orderProductDal.Delete(orderProduct);
                return new SuccessResult(Messages.OrderProductDeleted);
            }
            return new ErrorResult(Messages.OrderProductNotFound);

        }

        public IDataResult<OrderProduct> GetById(int orderProductId)
        {
            return new SuccessDataResult<OrderProduct>(_orderProductDal.Get(p => p.OrderProductId == orderProductId), Messages.OrderProductListed);
        }

        public IDataResult<List<OrderProduct>> GetList()
        {
            return new SuccessDataResult<List<OrderProduct>>(_orderProductDal.GetList().ToList(),Messages.OrderProductsListed);
        }

        public IResult Update(OrderProduct orderProduct)
        {
            _orderProductDal.Update(orderProduct);
            return new SuccessResult(Messages.OrderProductUpdated);
        }
    }
}
