using Övning_16___Industriell_maskinpark__.Shared.Entities;

namespace Övning_16___Industriell_maskinpark__.Client.Services
{
    public interface IIndustrialMachineClient
{
        Task<IEnumerable<IndustrialMachine>?> GetAsync();
        Task<IndustrialMachine?> PostAsync(CreateNewIndustrialMachine createItem);
        Task<bool> PutAsync(IndustrialMachine industrialMachine);
        Task<bool> RemoveAsync(string id);
    }
}
