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

    public class WaiterService : IWaiterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WaiterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ResponseService> GetWaiterAsync()
        {
            try
            {
                ResponseService response = new ResponseService();
                IEnumerable<Waiter> waiters = await _unitOfWork.Waiter.GetAllAsync();
                response.ResponseCode = waiters.Any() ? (int)Enumerator.ResponseCode.Ok : (int)Enumerator.ResponseCode.NoContent;
                response.Message = waiters.Any() ? Enumerator.Status.successful.ToString() : Enumerator.Status.failed.ToString();
                response.Status = waiters.Any();
                response.Quantity = waiters.Count();
                response.Data = Mapper.Map<IEnumerable<WaiterDto>>(waiters);

                return response;
            }
            catch (Exception ex)
            {
                throw new UseCaseException(ex.Message, ex);
            }
        }

        public async Task<ResponseService> CreateWaiterAsync(CreateWaiterDto createWaiterDto)
        {
            try
            {
                ResponseService response = new ResponseService();
                await _unitOfWork.BeginTransactionAsync();
                bool exists = await _unitOfWork.Waiter.AnyAsync(
                    x => x.FirstName.ToLower().Trim() == createWaiterDto.FirstName.ToLower().Trim()
                    && x.LastName.ToLower().Trim() == createWaiterDto.LastName.ToLower().Trim());
                if (exists)
                {
                    await _unitOfWork.CloseTransactionAsync();
                    response.ResponseCode = (int)Enumerator.ResponseCode.BadRequest;
                    response.Message = $"the waiter {createWaiterDto.FirstName} {createWaiterDto.LastName} already exists.";
                    return response;
                }
                Waiter waiter = Mapper.Map<Waiter>(createWaiterDto);
                bool isCreated = await _unitOfWork.Waiter.InsertAsync(waiter);
                await _unitOfWork.CommitTransactionAsync();
                response.ResponseCode = isCreated ? (int)Enumerator.ResponseCode.Ok : (int)Enumerator.ResponseCode.BadRequest;
                response.Message = isCreated ? Enumerator.Status.successful.ToString() : "not is possible create a waiter.";
                response.Status = isCreated;
                response.Quantity = isCreated ? 1 : 0;
                response.Data = waiter;

                return response;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw new UseCaseException(ex.Message, ex);
            }
        }

        public async Task<ResponseService> UpdateWaiterAsync(WaiterDto waiterDto)
        {
            try
            {
                ResponseService response = new ResponseService();
                await _unitOfWork.BeginTransactionAsync();
                bool exists = await _unitOfWork.Waiter.AnyAsync(x => x.IdWaiter == waiterDto.IdWaiter);
                if (!exists)
                {
                    await _unitOfWork.CloseTransactionAsync();
                    response.ResponseCode = (int)Enumerator.ResponseCode.BadRequest;
                    response.Message = $"the waiter {waiterDto.FirstName} {waiterDto.LastName} not exist.";
                    return response;
                }
                Waiter waiter = Mapper.Map<Waiter>(waiterDto);
                bool isUpdated = await _unitOfWork.Waiter.UpdateAsync(waiter);
                await _unitOfWork.CommitTransactionAsync();
                response.ResponseCode = isUpdated ? (int)Enumerator.ResponseCode.Ok : (int)Enumerator.ResponseCode.BadRequest;
                response.Message = isUpdated ? Enumerator.Status.successful.ToString() : "is not possible update a waiter.";
                response.Status = isUpdated;
                response.Quantity = isUpdated ? 1 : 0;
                response.Data = waiter;

                return response;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw new UseCaseException(ex.Message, ex);
            }
        }

        public async Task<ResponseService> DeleteWaiterAsync(int idWaiter)
        {
            try
            {
                ResponseService response = new ResponseService();
                await _unitOfWork.BeginTransactionAsync();
                Waiter waiter = await _unitOfWork.Waiter.FirstOrDefaultAsync(x => x.IdWaiter == idWaiter);
                if (waiter == null)
                {
                    await _unitOfWork.CloseTransactionAsync();
                    response.ResponseCode = (int)Enumerator.ResponseCode.BadRequest;
                    response.Message = $"the Waiter with identification {idWaiter} not exist.";
                    return response;
                }
                bool isDeleted = await _unitOfWork.Waiter.DeleteAsync(waiter);
                await _unitOfWork.CommitTransactionAsync();
                response.ResponseCode = isDeleted ? (int)Enumerator.ResponseCode.Ok : (int)Enumerator.ResponseCode.BadRequest;
                response.Message = isDeleted ? Enumerator.Status.successful.ToString() : "is not possible delete a waiter.";
                response.Status = isDeleted;
                response.Quantity = isDeleted ? 1 : 0;
                response.Data = waiter;

                return response;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw new UseCaseException(ex.Message, ex);
            }
        }

        public async Task<ResponseService> GetWaiterSalesAsync(DateRangeDto requestService)
        {
            try
            {
                ResponseService response = new ResponseService();
                IEnumerable<WaiterSalesDto> waiterSales = await _unitOfWork.Waiter.GetWaiterSalesAsync(requestService);
                response.ResponseCode = waiterSales.Any() ? (int)Enumerator.ResponseCode.Ok : (int)Enumerator.ResponseCode.NoContent;
                response.Message = waiterSales.Any() ? Enumerator.Status.successful.ToString() : Enumerator.Status.failed.ToString();
                response.Status = waiterSales.Any();
                response.Quantity = waiterSales.Count();
                response.Data = waiterSales;

                return response;
            }
            catch (Exception ex)
            {
                throw new UseCaseException(ex.Message, ex);
            }
        }
    }
}
