using FutureProjects.Application.Abstractions;
using FutureProjects.Application.Abstractions.IServices;
using FutureProjects.Domain.Entities.DTOs;
using FutureProjects.Domain.Entities.Models;
using FutureProjects.Domain.Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FutureProjects.Application.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Create(UserDTO userDTO)
        {
            if (GetByAny(x => x.Email == userDTO.Email).Result == null && GetByAny(x => x.Login == userDTO.Login).Result == null)
            {
                var user = new User()
                {
                    Name = userDTO.Name,
                    Email = userDTO.Email,
                    Login = userDTO.Login,
                    Password = userDTO.Password,
                    Role = userDTO.Role
                };

                var result = await _userRepository.Create(user);
                
                return result;
            }
            return new User();

        }

        public async Task<bool> Delete(Expression<Func<User, bool>> expression)
        {
            var result = await _userRepository.Delete(expression);

            return result;
        }

        public async Task<bool> DeleteById(int id)
        {
            var result = await _userRepository.Delete(x => x.Id == id);

            return result;
        }

        /// ############### read ##############
        #region
        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            var users = await _userRepository.GetAll();

            var result = users.Select(model => new UserViewModel
            {
                Name = model.Name,
                Email = model.Email,
                Role = model.Role,
            });

            return result;
        }

        public async Task<IEnumerable<User>> GetByAll(Expression<Func<User, bool>> expression)
        {
            var result = await _userRepository.GetByAll(expression);

            return result;
        }

        public async Task<User> GetByAny(Expression<Func<User, bool>> expression)
        {
            var result = await _userRepository.GetByAny(expression);

            return result;
        }

        public async Task<UserViewModel> GetByEmail(string email)
        {
            var result = await _userRepository.GetByAny(x => x.Email == email);
            if (result == null)
            {
                return null;
            }

            var user = new UserViewModel
            {
                Name = result.Name,
                Email = result.Email,
                Role = result.Role,
            };
            return user;
        }

        public async Task<UserViewModel> GetById(int Id)
        {
            var result = await _userRepository.GetByAny(x => x.Id == Id);
            if (result == null)
            {
                return null;
            }

            var user = new UserViewModel
            {
                Name = result.Name,
                Email = result.Email,
                Role = result.Role,
            };
            return user;
        }

        public async Task<UserViewModel> GetByLogin(string login)
        {
            var result = await _userRepository.GetByAny(y => y.Login == login);
            if (result == null)
            {
                return null;
            }

            var user = new UserViewModel
            {
                Name = result.Name,
                Email = result.Email,
                Role = result.Role,
            };
            return user;
        }

        public async Task<IEnumerable<UserViewModel>> GetByName(string name)
        {
            var result = await _userRepository.GetByAll(d => d.Name == name);
            if (result == null)
            {
                return null;
            }
            var users = result.Select(model => new UserViewModel
            {
                Name = model.Name,
                Email = model.Email,
                Role = model.Role,
            });
            return users;
        }

        public async Task<IEnumerable<UserViewModel>> GetByRole(string role)
        {
            var result = await _userRepository.GetByAll(d => d.Role == role);
            if (result == null)
            {
                return null;
            }
            var users = result.Select(model => new UserViewModel
            {
                Name = model.Name,
                Email = model.Email,
                Role = model.Role,
            });
            return users;
        }
        #endregion


        ////////// ########     updates      ############
        ///
        public async Task<string> Update(int Id, UserDTO userDTO)
        {
            var result = await _userRepository.GetByAny(x => x.Id == Id);
            if (result != null)
            {
                if ((await _userRepository.GetByAny(x => x.Email == userDTO.Email)) == null)
                {
                    if ((await _userRepository.GetByAny(x => x.Login == userDTO.Login)) == null)
                    {
                        var user = new User()
                        {
                            Id = Id,
                            Name = userDTO.Name,
                            Email = userDTO.Email,
                            Login = userDTO.Login,
                            Password = userDTO.Password,
                            Role = userDTO.Role,
                        };

                        await _userRepository.Update(user);

                        return "Update User";
                    }
                    return "Dublicate Login";
                }
                return "Dublicate Email";
            }
            return "No such id exists";
        }

        public async Task<string> UpdateName(int id, string name)
        {
            var result = await _userRepository.UpdateName(id, name);

            return result;
        }

        public async Task<string> UpdateEmail(int id,string email)
        {
            var result = await _userRepository.UpdateEmail(id, email);
            
            return result;
        }

        public async Task<string> UpdatePassword(int id, string password)
        {
            var result = await _userRepository.UpdatePassword(id, password);
            
            return result;
        }

        public async Task<string> UpdateLogin(int id,string login)
        {
            var result = await _userRepository.UpdateLogin(id, login);
            
            return result;
        }

        public async Task<string> UpdateRole(int id, string role)
        {
            var result = await _userRepository.UpdateRole(id, role);
            
            return result;
        }
    }
}
