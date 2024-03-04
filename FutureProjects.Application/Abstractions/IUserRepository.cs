using FutureProjects.Domain.Entities.Models;
using FutureProjects.Domain.Entities.ViewModels;

namespace FutureProjects.Application.Abstractions
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public Task Update(User user);
        public Task<string> UpdateEmail(int id, string email);
        public Task<string> UpdateLogin(int id, string login);
        public Task<string> UpdatePassword(int id, string password);
        public Task<string> UpdateName(int id, string name);
        public Task<string> UpdateRole(int id, string role);
    }
}
