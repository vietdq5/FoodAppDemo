using AutoMapper;
using WavesOfFoodDemo.Server.Dtos;
using WavesOfFoodDemo.Server.Entities;
using WavesOfFoodDemo.Server.Infrastructures;

namespace WavesOfFoodDemo.Server.Services
{
    public class CartInfoService : ICartInfoService
    {
        private readonly ILogger<CartInfoService> _logger;
        private readonly ICartInfoRepository _cartInfoRepository;
        private readonly IMapper _mapper;

        public CartInfoService(ICartInfoRepository cartInfoRepository, ILogger<CartInfoService> logger, IMapper mapper)
        {
            _cartInfoRepository = cartInfoRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<bool> AddCartInfoAsync(CartInfoCreateDto cartInfoCreateDto)
        {
            try
            {
                var info = _mapper.Map<CartInfo>(cartInfoCreateDto);
                return await _cartInfoRepository.AddAsync(info);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<bool?> EditCartInfoAsync(CartInfoDto cartInfoDto)
        {
            try
            {
                var foodInfo = await _cartInfoRepository.GetByIdAsync(cartInfoDto.Id);
                if (foodInfo == null)
                {
                    return null;
                }
                var infoUpdate = _mapper.Map<CartInfo>(cartInfoDto);
                var result = await _cartInfoRepository.UpdateAsync(infoUpdate);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<List<CartInfoDto>> GetCartInfoDtosAsync()
        {
            try
            {
                var data = await _cartInfoRepository.GetAllAsync();
                return _mapper.Map<List<CartInfoDto>>(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<bool?> RemoveCartInfoDtosAsync(Guid id)
        {
            try
            {
                return await _cartInfoRepository.DeleteByKey(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<CartHistoryDto>> GetTransactions(Guid userId)
        {
            try
            {
                return await _cartInfoRepository.GetTransactions(userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

    }
}
