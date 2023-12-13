using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestVP.Data.Repositories.Interfaces;
using TechTestVP.Engine.Services.Interfaces;
using TechTestVP.Engine.Validation.Order;
using TechTestVP.Lib.DTOs;
using TechTestVP.Lib.Models;
using TechTestVP.Lib.Response;

namespace TechTestVP.Engine.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        public OrderService(IOrderRepository orderRepo) 
        {
            _orderRepo = orderRepo;
        }

        public async Task<ReponseDTO> InsertOrder(OrderDTO order)
        {
            try
            {
                //Check If exists by Customer and Reference
                if (!await CheckIfOrderImportedExists(order.CustomerRef, order.Customer.Id))
                {
                    return new ReponseDTO()
                    {
                        IsSuccess = false,
                        Message = "Order already exists, cannot be recreated",
                        Data = null,
                        Errors = null
                    };
                }

                List<ValidationFailure> errors = ValidateOrder(order);

                if (errors.Count > 0)
                {
                    return new ReponseDTO()
                    {
                        IsSuccess = false,
                        Message = "Incorrect Data send to order schema, please review errors",
                        Data = null,
                        Errors = errors
                    };
                }

                Order newOrder = new Order().ToModel(order);

                int orderNumber = await _orderRepo.InsertOrder(newOrder);

                if (orderNumber == 0)
                {
                    return new ReponseDTO()
                    {
                        IsSuccess = false,
                        Data = null,
                        Errors = null,
                        Message = "Order cannot be created, please contact us"
                    };
                }

                return new ReponseDTO()
                {
                    IsSuccess = true,
                    Data = orderNumber,
                    Errors = null,
                    Message = $"Order has been successful created with Order Number {orderNumber}"
                };
                //Insert Order To DB
            }
            catch(Exception ex)
            {
                return new ReponseDTO()
                {
                    IsSuccess = false,
                    Message = $"Order failed to create with exception :{ex}, cannot be recreated",
                    Data = null,
                    Errors = null
                };
            }
        }

        public async Task<bool> CheckIfOrderImportedExists(string customerRef, string customerId)
        {
            return await _orderRepo.CheckIfOrderImportedExists(customerRef, customerId);
        }

        private List<ValidationFailure> ValidateOrder(OrderDTO order)
        {
            OrderValidator validator = new OrderValidator();
            var validationResult = validator.Validate(order);

            return validationResult.Errors;
        }
    }
}
