using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WavesOfFoodDemo.Server.Dtos;
using WavesOfFoodDemo.Server.Entities;
using WavesOfFoodDemo.Server.Infrastructures;

namespace WavesOfFoodDemo.Server.Services;

public class FoodInfoService : IFoodInfoService
{
    private readonly ILogger<FoodInfoService> _logger;
    private readonly IFoodInfoRepository _foodInfoRepository;
    private readonly IMapper _mapper;

    public FoodInfoService(IFoodInfoRepository foodInfoRepository, ILogger<FoodInfoService> logger, IMapper mapper)
    {
        _foodInfoRepository = foodInfoRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<List<FoodInfoDto>> GetFoodInfoDtosAsync()
    {
        try
        {
            var data = await _foodInfoRepository.GetAllAsync();
            return _mapper.Map<List<FoodInfoDto>>(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }

    public async Task<bool> AddFoodInfoAsync(FoodInfoCreateDto foodInfoCreateDto)
    {
        try
        {
            var info = _mapper.Map<FoodInfo>(foodInfoCreateDto);
            return await _foodInfoRepository.AddAsync(info);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }

    public async Task<bool?> EditFoodInfoAsync(FoodInfoDto foodInfoDto)
    {
        try
        {
            var foodInfo = await _foodInfoRepository.GetByIdAsync(foodInfoDto.Id);
            if (foodInfo == null)
            {
                return null;
            }
            var infoUpdate = _mapper.Map<FoodInfo>(foodInfoDto);
            var result = await _foodInfoRepository.UpdateAsync(infoUpdate);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }

    public async Task<bool?> RemoveFoodInfoDtosAsync(Guid id)
    {
        try
        {
            return await _foodInfoRepository.DeleteByKey(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }

    public async Task<List<FoodInfoDto>> SearchFoodInfoDtosAsync(string foodName)
    {
        try
        {
            var data = await _foodInfoRepository.SearchFoodInfoDtosAsync(foodName);
            return _mapper.Map<List<FoodInfoDto>>(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }
}