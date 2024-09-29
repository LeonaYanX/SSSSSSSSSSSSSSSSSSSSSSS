using GraphQlSeminar.Dto;

namespace GraphQlSeminar.Abstractions
{
    public interface IStorageRepository
    {
        int AddStorage(StorageDto storageDto);

        IEnumerable<StorageDto> GetAllStorages();
    }
}
