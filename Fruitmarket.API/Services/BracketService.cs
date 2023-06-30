using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using FruitMarket.API.Domain.Models;
using FruitMarket.API.Domain.Repositories;
using FruitMarket.API.Domain.Services;
using FruitMarket.API.Domain.Services.Communication;
using FruitMarket.API.Infrastructure;

namespace FruitMarket.API.Services
{
    public class BracketService : IBracketService
    {
        private readonly IBracketRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;

        public BracketService(IBracketRepository categoryRepository, IUnitOfWork unitOfWork, IMemoryCache cache)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<IEnumerable<Bracket>> ListAsync()
        {
            // Here I try to get the Brackets list from the memory cache. If there is no data in cache, the anonymous method will be
            // called, setting the cache to expire one minute ahead and returning the Task that lists the Brackets from the repository.
            var Brackets = await _cache.GetOrCreateAsync(CacheKeys.BracketList, (entry) => {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                return _categoryRepository.ListAsync();
            });
            
            return Brackets;
        }

        public async Task<BracketResponse> SaveAsync(Bracket bracket)
        {
            try
            {
                await _categoryRepository.AddAsync(bracket);
                await _unitOfWork.CompleteAsync();

                return new BracketResponse(bracket);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new BracketResponse($"An error occurred when saving the Bracket: {ex.Message}");
            }
        }

        public async Task<BracketResponse> UpdateAsync(int id, Bracket bracket)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new BracketResponse("Bracket not found.");

            existingCategory.Name = bracket.Name;

            try
            {
                await _unitOfWork.CompleteAsync();

                return new BracketResponse(existingCategory);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new BracketResponse($"An error occurred when updating the Bracket: {ex.Message}");
            }
        }

        public async Task<BracketResponse> DeleteAsync(int id)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new BracketResponse("Bracket not found.");

            try
            {
                _categoryRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new BracketResponse(existingCategory);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new BracketResponse($"An error occurred when deleting the Bracket: {ex.Message}");
            }
        }
    }
}
