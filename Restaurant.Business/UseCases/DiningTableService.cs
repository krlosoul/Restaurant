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

    public class DiningTableService : IDiningTableService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DiningTableService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ResponseService> GetDiningTableAsync()
        {
            try
            {
                ResponseService response = new ResponseService();
                IEnumerable<DiningTable> diningTables = await _unitOfWork.DiningTable.GetAllAsync();
                response.ResponseCode = diningTables.Any() ? (int)Enumerator.ResponseCode.Ok : (int)Enumerator.ResponseCode.NoContent;
                response.Message = diningTables.Any() ? Enumerator.Status.successful.ToString() : Enumerator.Status.failed.ToString();
                response.Status = diningTables.Any();
                response.Quantity = diningTables.Count();
                response.Data = Mapper.Map<IEnumerable<DiningTableDto>>(diningTables);

                return response;
            }
            catch (Exception ex)
            {
                throw new UseCaseException(ex.Message, ex);
            }
        }

        public async Task<ResponseService> CreateDiningTableAsync(CreateDiningTableDto createDiningTableDto)
        {
            try
            {
                ResponseService response = new ResponseService();
                await _unitOfWork.BeginTransactionAsync();
                bool exists = await _unitOfWork.DiningTable.AnyAsync(x => x.Name.ToLower().Trim() == createDiningTableDto.Name.ToLower().Trim());
                if (exists)
                {
                    await _unitOfWork.CloseTransactionAsync();
                    response.ResponseCode = (int)Enumerator.ResponseCode.BadRequest;
                    response.Message = $"the dining table {createDiningTableDto.Name} already exists.";
                    return response;
                }
                DiningTable diningTable = Mapper.Map<DiningTable>(createDiningTableDto);
                bool isCreated = await _unitOfWork.DiningTable.InsertAsync(diningTable);
                await _unitOfWork.CommitTransactionAsync();
                response.ResponseCode = isCreated ? (int)Enumerator.ResponseCode.Ok : (int)Enumerator.ResponseCode.BadRequest;
                response.Message = isCreated ? Enumerator.Status.successful.ToString() : "not is possible create a dining table.";
                response.Status = isCreated;
                response.Quantity = isCreated ? 1 : 0;
                response.Data = diningTable;

                return response;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw new UseCaseException(ex.Message, ex);
            }
        }

        public async Task<ResponseService> UpdateDiningTableAsync(DiningTableDto diningTableDto)
        {
            try
            {
                ResponseService response = new ResponseService();
                await _unitOfWork.BeginTransactionAsync();
                bool exists = await _unitOfWork.DiningTable.AnyAsync(x => x.IdDiningTable == diningTableDto.IdDiningTable);
                if (!exists)
                {
                    await _unitOfWork.CloseTransactionAsync();
                    response.ResponseCode = (int)Enumerator.ResponseCode.BadRequest;
                    response.Message = $"the dining table {diningTableDto.Name} not exist.";
                    return response;
                }
                DiningTable diningTable = Mapper.Map<DiningTable>(diningTableDto);
                bool isUpdated = await _unitOfWork.DiningTable.UpdateAsync(diningTable);
                await _unitOfWork.CommitTransactionAsync();
                response.ResponseCode = isUpdated ? (int)Enumerator.ResponseCode.Ok : (int)Enumerator.ResponseCode.BadRequest;
                response.Message = isUpdated ? Enumerator.Status.successful.ToString() : "is not possible update a dining table.";
                response.Status = isUpdated;
                response.Quantity = isUpdated ? 1 : 0;
                response.Data = diningTable;

                return response;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw new UseCaseException(ex.Message, ex);
            }
        }

        public async Task<ResponseService> DeleteDiningTableAsync(int idDiningTable)
        {
            try
            {
                ResponseService response = new ResponseService();
                await _unitOfWork.BeginTransactionAsync();
                DiningTable diningTable = await _unitOfWork.DiningTable.FirstOrDefaultAsync(x => x.IdDiningTable == idDiningTable);
                if (diningTable == null)
                {
                    await _unitOfWork.CloseTransactionAsync();
                    response.ResponseCode = (int)Enumerator.ResponseCode.BadRequest;
                    response.Message = $"the dining table with identification {idDiningTable} not exist.";
                    return response;
                }
                bool isDeleted = await _unitOfWork.DiningTable.DeleteAsync(diningTable);
                await _unitOfWork.CommitTransactionAsync();
                response.ResponseCode = isDeleted ? (int)Enumerator.ResponseCode.Ok : (int)Enumerator.ResponseCode.BadRequest;
                response.Message = isDeleted ? Enumerator.Status.successful.ToString() : "is not possible delete a dining table.";
                response.Status = isDeleted;
                response.Quantity = isDeleted ? 1 : 0;
                response.Data = diningTable;

                return response;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw new UseCaseException(ex.Message, ex);
            }
        }
    }
}
