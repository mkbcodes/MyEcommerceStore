using System.Threading.Tasks;

namespace WasmStore.Server.Services.SeedService
{
    public interface ISeedService
    {
        Task SeedRolesAsync();
        Task SeedDefaultUsersAsync();
        Task SeedPlaceholderProductDataAsync();

    }

}
