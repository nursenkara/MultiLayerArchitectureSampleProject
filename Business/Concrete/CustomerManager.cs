using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        [ValidationAspect(typeof(AddCustomerDtoValidator))]
        public IResult Add(AddCustomerDto addCustomerDto)
        {
            var result = BusinessRules.Run
                (
                CheckIfCustomerEmailExists(addCustomerDto.Email),
                CheckIfCustomerTCKNExists(addCustomerDto.TCKN)
                );
            if (result == null)
            {
                Customer customer = new()
                {
                    TCKN = addCustomerDto.TCKN,
                    Name = addCustomerDto.Name,
                    Surname = addCustomerDto.Surname,
                    Address = addCustomerDto.Address,
                    City = addCustomerDto.City,
                    District = addCustomerDto.District,
                    Email = addCustomerDto.Email,
                    Telephone = addCustomerDto.Telephone,
                };
                _customerDal.Add(customer);
                return new SuccessResult(Messages.CustomerAdded);
            }
            return new ErrorResult(result.Message);
        }

        public IResult Delete(int customerId)
        {
            var result = GetById(customerId);
            if (result.Data != null)
            {
                result.Data.Status = false;
                _customerDal.Update(result.Data);
                return new SuccessResult(Messages.CustomerDeleted);
            }
            return new ErrorResult(result.Message);
        }
        #region GetActiveList
        public IDataResult<List<ListCustomerDto>> GetActiveList()
        {
            var activeCustomers = _customerDal.GetList(x => x.Status == true).ToList();
            if (activeCustomers.Count > 0)
            {
                var activeDtos = CustomerToListDto(activeCustomers);
                return new SuccessDataResult<List<ListCustomerDto>>(activeDtos);
            }
            return new ErrorDataResult<List<ListCustomerDto>>(Messages.ActiveCustomerNotFound);
        }
        #endregion
        #region GetInActiveList
        public IDataResult<List<ListCustomerDto>> GetInActiveList()
        {
            var inactiveCustomers = _customerDal.GetList(x => x.Status == false).ToList();
            if (inactiveCustomers.Count > 0)
            {
                var inactiveDtos = CustomerToListDto(inactiveCustomers);
                return new SuccessDataResult<List<ListCustomerDto>>(inactiveDtos);
            }
            return new ErrorDataResult<List<ListCustomerDto>>(Messages.InActiveCustomerNotFound);
        }
        #endregion
        public IDataResult<Customer> GetById(int customerId)
        {
            var customer = _customerDal.Get(c => c.CustomerId == customerId);
            if (customer != null)
            {
                return new SuccessDataResult<Customer>(customer);
            }
            return new ErrorDataResult<Customer>(Messages.CustomerNotFound);   
        }

        public IDataResult<ListCustomerDto> GetByName(string name)
        {
            var customer = _customerDal.Get(c => c.Name == name);
            if (customer != null)
            {
                var dto = new ListCustomerDto
                {
                    TCKN = customer.TCKN,
                    Address = customer.Address,
                    City = customer.City,
                    Status = customer.Status,
                    CustomerId = customer.CustomerId,
                    District = customer.District,
                    Email = customer.Email,
                    Name = customer.Name,
                    Surname = customer.Surname,
                    Telephone = customer.Telephone
                };
                return new SuccessDataResult<ListCustomerDto>(dto);
            }
            return new ErrorDataResult<ListCustomerDto>(Messages.CustomerNotFound);
        }


        public IDataResult<List<ListCustomerDto>> GetList()
        {
            var customers = _customerDal.GetList().ToList();
            if (customers != null) 
            {
                var listDtos = CustomerToListDto(customers);
                return new SuccessDataResult<List<ListCustomerDto>>(listDtos);
            }
            return new ErrorDataResult<List<ListCustomerDto>>(Messages.CustomerNotFound);
        }

        public IResult Update(UpdateCustomerDto updateCustomerDto)
        {
            var result = BusinessRules.Run(
                CheckIfCustomerEmailExists(updateCustomerDto.Email),
                CheckIfCustomerTCKNExists(updateCustomerDto.TCKN)
                );
            if (result == null)
            {
                var customerFromDb = GetById(updateCustomerDto.CustomerId).Data;
                if (customerFromDb != null)
                {
                    customerFromDb.TCKN = updateCustomerDto.TCKN;
                    customerFromDb.Name = updateCustomerDto.Name;
                    customerFromDb.Surname = updateCustomerDto.Surname;
                    customerFromDb.Address = updateCustomerDto.Address;
                    customerFromDb.City = updateCustomerDto.City;
                    customerFromDb.District = updateCustomerDto.District;
                    customerFromDb.Email = updateCustomerDto.Email;
                    customerFromDb.Telephone = updateCustomerDto.Telephone;
                    
                    _customerDal.Update(customerFromDb);
                    return new SuccessResult(Messages.CustomerUpdated);
                }
                return new ErrorResult(Messages.CustomerNotFound);
            }
            return new ErrorResult(result.Message);
        }
        private IResult CheckIfCustomerEmailExists(string customerEmail)
        {
            var result = _customerDal.Get(c => c.Email == customerEmail);
            if (result != null)
            {
                return new ErrorResult(Messages.CustomerEmailExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCustomerTCKNExists(string TCKN)
        {
            var result = _customerDal.Get(c => c.TCKN == TCKN);
            if (result != null)
            {
                return new ErrorResult(Messages.CustomerTCKNExists);
            }
            return new SuccessResult();
        }
        private List<ListCustomerDto> CustomerToListDto(List<Customer> customers)
        {
            var customerDtos = new List<ListCustomerDto>();
            foreach(var customer in customers)
            {
                customerDtos.Add(new ListCustomerDto
                {
                    TCKN = customer.TCKN,
                    Address = customer.Address,
                    City = customer.City,
                    Status = customer.Status,
                    District = customer.District,
                    Email = customer.Email,
                    Name = customer.Name,
                    Surname = customer.Surname,
                    Telephone = customer.Telephone,
                });
            }
            return customerDtos;
        }
    }
}
