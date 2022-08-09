using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderProductService
    {
        IDataResult<OrderProduct> GetById(int orderProductId);
        IDataResult<List<OrderProduct>> GetList();
        IResult Add(OrderProduct orderProduct);
        IResult Delete(OrderProduct orderProduct);
        IResult Update(OrderProduct orderProduct);
    }
}
