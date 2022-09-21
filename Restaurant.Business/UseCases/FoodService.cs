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

    public class FoodService : IFoodService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FoodService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ResponseService> GetFoodAsync()
        {
            try
            {
                ResponseService response = new ResponseService();
                IEnumerable<Food> food = await _unitOfWork.Food.GetAllAsync();
                response.ResponseCode = food.Any() ? (int)Enumerator.ResponseCode.Ok : (int)Enumerator.ResponseCode.NoContent;
                response.Message = food.Any() ? Enumerator.Status.successful.ToString() : Enumerator.Status.failed.ToString();
                response.Status = food.Any();
                response.Quantity = food.Count();
                response.Data = Mapper.Map<IEnumerable<FoodDto>>(food);

                return response;
            }
            catch (Exception ex)
            {
                throw new UseCaseException(ex.Message, ex);
            }
        }

        public async Task<ResponseService> CreateFoodAsync(CreateFoodDto createFoodDto)
        {
            try
            {
                ResponseService response = new ResponseService();
                await _unitOfWork.BeginTransactionAsync();
                bool exists = await _unitOfWork.Food.AnyAsync(x => x.Name.ToLower().Trim() == createFoodDto.Name.ToLower().Trim());
                if (exists)
                {
                    await _unitOfWork.CloseTransactionAsync();
                    response.ResponseCode = (int)Enumerator.ResponseCode.BadRequest;
                    response.Message = $"the food {createFoodDto.Name} already exists.";
                    return response;
                }
                Food food = Mapper.Map<Food>(createFoodDto);
                bool isCreated = await _unitOfWork.Food.InsertAsync(food);
                await _unitOfWork.CommitTransactionAsync();
                response.ResponseCode = isCreated ? (int)Enumerator.ResponseCode.Ok : (int)Enumerator.ResponseCode.BadRequest;
                response.Message = isCreated ? Enumerator.Status.successful.ToString() : "not is possible create a foot.";
                response.Status = isCreated;
                response.Quantity = isCreated ? 1 : 0;
                response.Data = food;

                return response;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw new UseCaseException(ex.Message, ex);
            }
        }

        public async Task<ResponseService> UpdateFoodAsync(FoodDto foodDto)
        {
            try
            {
                ResponseService response = new ResponseService();
                await _unitOfWork.BeginTransactionAsync();
                bool exists = await _unitOfWork.Food.AnyAsync(x => x.IdFood == foodDto.IdFood);
                if (!exists)
                {
                    await _unitOfWork.CloseTransactionAsync();
                    response.ResponseCode = (int)Enumerator.ResponseCode.BadRequest;
                    response.Message = $"the food {foodDto.Name} not exist.";
                    return response;
                }
                Food food = Mapper.Map<Food>(foodDto);
                bool isUpdated = await _unitOfWork.Food.UpdateAsync(food);
                await _unitOfWork.CommitTransactionAsync();
                response.ResponseCode = isUpdated ? (int)Enumerator.ResponseCode.Ok : (int)Enumerator.ResponseCode.BadRequest;
                response.Message = isUpdated ? Enumerator.Status.successful.ToString() : "is not possible update a food.";
                response.Status = isUpdated;
                response.Quantity = isUpdated ? 1 : 0;
                response.Data = food;

                return response;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw new UseCaseException(ex.Message, ex);
            }
        }

        public async Task<ResponseService> DeleteFoodAsync(int idFood)
        {
            try
            {
                ResponseService response = new ResponseService();
                await _unitOfWork.BeginTransactionAsync();
                Food food = await _unitOfWork.Food.FirstOrDefaultAsync(x => x.IdFood == idFood);
                if (food == null)
                {
                    await _unitOfWork.CloseTransactionAsync();
                    response.ResponseCode = (int)Enumerator.ResponseCode.BadRequest;
                    response.Message = $"the food with identification {idFood} not exist.";
                    return response;
                }
                bool isDeleted = await _unitOfWork.Food.DeleteAsync(food);
                await _unitOfWork.CommitTransactionAsync();
                response.ResponseCode = isDeleted ? (int)Enumerator.ResponseCode.Ok : (int)Enumerator.ResponseCode.BadRequest;
                response.Message = isDeleted ? Enumerator.Status.successful.ToString() : "is not possible delete a food.";
                response.Status = isDeleted;
                response.Quantity = isDeleted ? 1 : 0;
                response.Data = food;

                return response;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw new UseCaseException(ex.Message, ex);
            }
        }

        public async Task<ResponseService> GetSalesFoodAsync(DateRangeDto requestService)
        {
            try
            {
                ResponseService response = new ResponseService();
                SalesFoodDto salesFood = await _unitOfWork.Food.GetSalesFoodAsync(requestService);
                response.ResponseCode = salesFood != null ? (int)Enumerator.ResponseCode.Ok : (int)Enumerator.ResponseCode.NoContent;
                response.Message = salesFood != null ? Enumerator.Status.successful.ToString() : Enumerator.Status.failed.ToString();
                response.Status = salesFood != null;
                response.Quantity = salesFood != null ? 1 : 0;
                response.Data = salesFood;

                return response;
            }
            catch (Exception ex)
            {
                throw new UseCaseException(ex.Message, ex);
            }
        }
    }
}
