using FutureProjects.Domain.Entities.DTOs;
using FutureProjects.Domain.Entities.Models;
using FutureProjects.Domain.Entities.ViewModels;
using System.Linq.Expressions;

namespace FutureProjects.Application.Abstractions.IServices
{
    public interface IUserService
    {
        public Task<User> Create(UserDTO userDTO);

        public Task<IEnumerable<UserViewModel>> GetByName(string name);
        public Task<UserViewModel> GetById(int Id);
        public Task<UserViewModel> GetByEmail(string email);
        public Task<UserViewModel> GetByLogin(string login);
        public Task<IEnumerable<UserViewModel>> GetByRole(string role);
        public Task<IEnumerable<UserViewModel>> GetAll();
        public Task<IEnumerable<User>> GetByAll(Expression<Func<User, bool>> expression);
        public Task<User> GetByAny(Expression<Func<User, bool>> expression);

        public Task<bool> Delete(Expression<Func<User, bool>> expression);
        public Task<bool> DeleteById(int id);

        public Task<string> Update(int Id, UserDTO userDTO);
        public Task<string> UpdateEmail(int id, string email);
        public Task<string> UpdateLogin(int id, string login);
        public Task<string> UpdatePassword(int id, string password);
        public Task<string> UpdateName(int id, string name);
        public Task<string> UpdateRole(int id, string role);
    }
}
