using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<Order> GetById(int orderId);
        IDataResult<List<Order>> GetList();
        //IDataResult<List<Order>> GetListByUser(int userId);
        IResult Add(Order order);
        IResult Delete(Order order);
        IResult Update(Order order);
    }
}
