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

    public class BillService : IBillService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBillDetailService _billDetailService;

        public BillService(IUnitOfWork unitOfWork, IBillDetailService billDetailService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _billDetailService = billDetailService ?? throw new ArgumentNullException(nameof(billDetailService));
        }

        public async Task<ResponseService> CreateBillAsync(CreateBillDto createBillDto)
        {
            try
            {
                ResponseService response = new ResponseService();
                await _unitOfWork.BeginTransactionAsync();
                Bill create = Mapper.Map<Bill>(createBillDto);
                bool isCreate = await _unitOfWork.Bill.InsertAsync(create);
                await _unitOfWork.CommitTransactionAsync();
                if (isCreate)
                {
                    isCreate = await CreateDetails(create.IdBill, createBillDto.CreateBillDetailsDto);
                }
                response.ResponseCode = isCreate ? (int)Enumerator.ResponseCode.Ok : (int)Enumerator.ResponseCode.BadRequest;
                response.Message = isCreate ? Enumerator.Status.successful.ToString() : Enumerator.Status.failed.ToString();
                response.Status = isCreate;
                response.Quantity = isCreate ? 1 : 0;
                response.Data = createBillDto;

                return response;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw new UseCaseException(ex.Message, ex);
            }
        }

        public async Task<ResponseService> GetBillsWithDetailsAsync(GetBillsWithDetailsDto getBillDetailDto)
        {
            try
            {
                ResponseService response = new ResponseService();
                IEnumerable<BillsWithDetailsDto> billsWithDetails = await _unitOfWork.Bill.GetBillsWithDetailsAsync(getBillDetailDto);
                response.ResponseCode = billsWithDetails.Any() ? (int)Enumerator.ResponseCode.Ok : (int)Enumerator.ResponseCode.NoContent;
                response.Message = billsWithDetails.Any() ? Enumerator.Status.successful.ToString() : Enumerator.Status.noContent.ToString();
                response.Status = billsWithDetails.Any();
                response.Quantity = billsWithDetails.Count();
                response.Data = billsWithDetails;

                return response;
            }
            catch (Exception ex)
            {
                throw new UseCaseException(ex.Message, ex);
            }
        }

        #region private method
        private async Task<bool> CreateDetails(int idBill, CreateBillDetailsDto CreateBillDetailsDto)
        {
            foreach (CreateBillDetailDto detail in CreateBillDetailsDto.CreateBillDetailDto)
            {
                detail.IdBill = idBill;
            }
            ResponseService response = await _billDetailService.CreateBillDetailsAsync(CreateBillDetailsDto);

            return response.Status;
        }
        #endregion
    }
}
