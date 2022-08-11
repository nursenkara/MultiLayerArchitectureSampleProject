using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(AddCustomerDto addCustomerDto);
        IResult Delete(int customerId);
        IResult Update(UpdateCustomerDto updateCustomerDto);
        IDataResult<Customer> GetById(int customerId);
        IDataResult<ListCustomerDto> GetByName(string name);
        IDataResult<List<ListCustomerDto>> GetList();
        IDataResult<List<ListCustomerDto>> GetActiveList();
        IDataResult<List<ListCustomerDto>> GetInActiveList();
    }
}
