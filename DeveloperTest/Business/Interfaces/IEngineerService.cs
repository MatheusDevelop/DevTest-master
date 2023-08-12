using DeveloperTest.Models;
using System.Threading.Tasks;

namespace DeveloperTest.Business.Interfaces
{
    public interface IEngineerService
    {
        Task<EngineerModel[]> GetEngineers();

        Task<EngineerModel> GetEngineer(int engineerId);

        Task<EngineerModel> CreateEngineer(BaseEngineerModel model);
    }
}
