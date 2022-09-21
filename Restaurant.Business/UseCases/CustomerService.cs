namespace Restaurant.Business.UseCases
{
    using AutoMapper;
    using Restaurant.Business.Interfaces;
    using Restaurant.Core.Constants;
    using Restaurant.Core.Dtos;
    using Restaurant.Core.Entities;
    using Restaurant.Core.Exceptions;
    using Restaurant.Core.Services;
    using Restaurant.Infrastructure.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ResponseService> GetCustomerAsync()
        {
            try
            {
                ResponseService response = new ResponseService();
                IEnumerable<Customer> customers = await _unitOfWork.Customer.GetAllAsync();
                response.ResponseCode = customers.Any() ? (int)Enumerator.ResponseCode.Ok : (int)Enumerator.ResponseCode.NoContent;
                response.Message = customers.Any() ? Enumerator.Status.successful.ToString() : Enumerator.Status.failed.ToString();
                response.Status = customers.Any();
                response.Quantity = customers.Count();
                response.Data = Mapper.Map<IEnumerable<CustomerDto>>(customers);

                return response;
            }
            catch (Exception ex)
            {
                throw new UseCaseException(ex.Message, ex);
            }
        }

        public async Task<ResponseService> CreateCustomerAsync(CustomerDto customerDto)
        {
            try
            {
                ResponseService response = new ResponseService();
                await _unitOfWork.BeginTransactionAsync();
                bool exists = await _unitOfWork.Customer.AnyAsync(x => x.IdCustomer == customerDto.IdCustomer);
                if (exists)
                {
                    await _unitOfWork.CloseTransactionAsync();
                    response.ResponseCode = (int)Enumerator.ResponseCode.BadRequest;
                    response.Message = $"the customer with identification {customerDto.IdCustomer} already exists.";
                    response.Status = false;
                    return response;
                }
                Customer customer = Mapper.Map<Customer>(customerDto);
                bool isCreated = await _unitOfWork.Customer.InsertAsync(customer);
                await _unitOfWork.CommitTransactionAsync();
                response.ResponseCode = isCreated ? (int)Enumerator.ResponseCode.Ok : (int)Enumerator.ResponseCode.BadRequest;
                response.Message = isCreated ? Enumerator.Status.successful.ToString() : "not is possible create a customer.";
                response.Status = isCreated;
                response.Quantity = isCreated ? 1 : 0;
                response.Data = customer;

                return response;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw new UseCaseException(ex.Message, ex);
            }
        }

        public async Task<ResponseService> UpdateCustomerAsync(CustomerDto customerDto)
        {
            try
            {
                ResponseService response = new ResponseService();
                await _unitOfWork.BeginTransactionAsync();
                bool exists = await _unitOfWork.Customer.AnyAsync(x => x.IdCustomer == customerDto.IdCustomer);
                if (!exists)
                {
                    await _unitOfWork.CloseTransactionAsync();
                    response.ResponseCode = (int)Enumerator.ResponseCode.BadRequest;
                    response.Message = $"the customer with identification {customerDto.IdCustomer} not exists.";
                    response.Status = false;
                    return response;
                }
                Customer customer = Mapper.Map<Customer>(customerDto);
                bool isUpdated = await _unitOfWork.Customer.UpdateAsync(customer);
                await _unitOfWork.CommitTransactionAsync();
                response.ResponseCode = isUpdated ? (int)Enumerator.ResponseCode.Ok : (int)Enumerator.ResponseCode.BadRequest;
                response.Message = isUpdated ? Enumerator.Status.successful.ToString() : "is not possible update a customer.";
                response.Status = isUpdated;
                response.Quantity = isUpdated ? 1 : 0;
                response.Data = customer;

                return response;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw new UseCaseException(ex.Message, ex);
            }
        }

        public async Task<ResponseService> DeleteCustomerAsync(string idCustomer)
        {
            try
            {
                ResponseService response = new ResponseService();
                await _unitOfWork.BeginTransactionAsync();
                Customer customer = await _unitOfWork.Customer.FirstOrDefaultAsync(x => x.IdCustomer == idCustomer);
                if (customer == null)
                {
                    await _unitOfWork.CloseTransactionAsync();
                    response.ResponseCode = (int)Enumerator.ResponseCode.BadRequest;
                    response.Message = $"the customer with identification {idCustomer} not exists.";
                    response.Status = false;
                    return response;
                }
                bool isDeleted = await _unitOfWork.Customer.DeleteAsync(customer);
                await _unitOfWork.CommitTransactionAsync();
                response.ResponseCode = isDeleted ? (int)Enumerator.ResponseCode.Ok : (int)Enumerator.ResponseCode.BadRequest;
                response.Message = isDeleted ? Enumerator.Status.successful.ToString() : "is not possible delete a customer.";
                response.Status = isDeleted;
                response.Quantity = isDeleted ? 1 : 0;
                response.Data = customer;

                return response;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw new UseCaseException(ex.Message, ex);
            }
        }

        public async Task<ResponseService> GetCustomerSpendAsync(GetCustomerDto getCustomerDto)
        {
            try
            {
                ResponseService response = new ResponseService();
                IEnumerable<CustomerSpendDto> customerSpend = await _unitOfWork.Customer.GetCustomerSpendAsync(getCustomerDto);
                response.ResponseCode = customerSpend.Any() ? (int)Enumerator.ResponseCode.Ok : (int)Enumerator.ResponseCode.NoContent;
                response.Message = customerSpend.Any() ? Enumerator.Status.successful.ToString() : Enumerator.Status.failed.ToString();
                response.Status = customerSpend.Any();
                response.Quantity = customerSpend.Count();
                response.Data = customerSpend;

                return response;
            }
            catch (Exception ex)
            {
                throw new UseCaseException(ex.Message, ex);
            }
        }
    }
}
