using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<OrderModel> GetById(int orderId);
        IDataResult<List<OrderModel>> GetList();
        //IDataResult<List<Order>> GetListByUser(int userId);
        IResult Add(Order order);
        IResult Delete(int orderId);
        IResult Update(Order order);
    }
}
