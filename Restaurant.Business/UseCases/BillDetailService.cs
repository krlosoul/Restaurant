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
    using System.Threading.Tasks;

    public class BillDetailService : IBillDetailService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BillDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ResponseService> CreateBillDetailsAsync(CreateBillDetailsDto createBillDetailsDto)
        {
            try
            {
                ResponseService response = new ResponseService();
                await _unitOfWork.BeginTransactionAsync();
                List<BillDetail> create = Mapper.Map<List<BillDetail>>(createBillDetailsDto.CreateBillDetailDto);
                bool isCreate = await _unitOfWork.BillDetail.InsertAsync(create);
                await _unitOfWork.CommitTransactionAsync();
                response.ResponseCode = isCreate ? (int)Enumerator.ResponseCode.Ok : (int)Enumerator.ResponseCode.BadRequest;
                response.Message = isCreate ? Enumerator.Status.successful.ToString() : Enumerator.Status.failed.ToString();
                response.Status = isCreate;
                response.Quantity = isCreate ? 1 : 0;
                response.Data = createBillDetailsDto;

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
