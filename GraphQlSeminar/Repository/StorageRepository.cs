using AutoMapper;
using GraphQlSeminar.Abstractions;
using GraphQlSeminar.DbModels;
using GraphQlSeminar.Dto;
using Microsoft.Extensions.Caching.Memory;

namespace GraphQlSeminar.Repository
{
    public class StorageRepository : IStorageRepository
    {
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public int AddStorage(StorageDto storageDto)
        {
            using (var storageDbContext = new StorageDbContext()) 
            {
              if (storageDbContext.Storages.Any(x => x.ProductId == storageDto.ProductId)) 
                    throw new Exception("Storage already exists.");

               var storage = _mapper.Map<Storage>(storageDto);

               storageDbContext.Storages.Add(storage);
               storageDbContext.SaveChanges();
                var storageId = storage.Id;
                _cache.Remove("storages");
                return storageId;
            }
        }

        public IEnumerable<StorageDto> GetAllStorages()
        {
            using (var storageDbContext = new StorageDbContext()) 
            {
              if (_cache.TryGetValue("storages", out List<StorageDto>? storagesDto)) return storagesDto ?? new List<StorageDto>();

              var storages = storageDbContext.Storages.ToList();
              storagesDto = _mapper.Map<List<StorageDto>>(storages);
              _cache.Set("storages", storagesDto, TimeSpan.FromMinutes(30));

               return storagesDto;
            }
        }
    }
}
