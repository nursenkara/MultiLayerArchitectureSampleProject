using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Entities.Dtos.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;
        private IAdminUserService _adminUserService;
        public OrderManager(IOrderDal orderDal, IAdminUserService adminUserService)
        {
            _orderDal = orderDal;
            _adminUserService = adminUserService;
            
        }
        public IResult Add(Order order)
        {
            _orderDal.Add(order);
            return new SuccessResult(Messages.OrderAdded);
        }

        public IResult Delete(Order order)
        {
            _orderDal.Delete(order);
            return new SuccessResult(Messages.OrderDeleted);
        }

        public IDataResult<OrderModel> GetById(int orderId)
        {
            var order = _orderDal.Get(p => p.OrderId == orderId);
            var model = OrderToGetOrderModel(order);
            return new SuccessDataResult<OrderModel>(model);
        }

        public IDataResult<List<OrderModel>> GetList()
        {
            //Thread.Sleep(5000);
            var list = _orderDal.GetList().ToList();
            var models = OrderToOrderModel(list);

            return new SuccessDataResult<List<OrderModel>>(models);

        }

        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult(Messages.OrderUpdated);
        }

        private List<OrderModel> OrderToOrderModel(List<Order> orders)
        {

            var models = new List<OrderModel>();
            foreach (var order in orders)
            {
                var userName = _adminUserService.GetById(order.AdminId).Data;
                models.Add(new OrderModel
                {
                    OrderId = order.OrderId,
                    TotalPrice = order.TotalPrice,
                    UserName = userName.UserName,
                });
            }

            return models;
        }

        private OrderModel OrderToGetOrderModel(Order order)
        {

            var model = new OrderModel();
            var userName = _adminUserService.GetById(order.AdminId).Data;
            model.OrderId = order.OrderId;
            model.TotalPrice = order.TotalPrice;
            model.UserName = userName.UserName;
            return model;

           
               
            }

       
    }
    }

