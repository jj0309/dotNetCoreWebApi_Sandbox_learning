using System.Threading.Tasks;
using _dotnetSandBox.Models;

namespace _dotnetSandBox.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(Models.User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}