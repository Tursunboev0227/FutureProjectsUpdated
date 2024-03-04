using FutureProjects.Application.Abstractions;
using FutureProjects.Domain.Entities.DTOs;
using FutureProjects.Domain.Entities.Models;
using FutureProjects.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FutureProjects.Infrastructure.BaseRepositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly FutureProjectsDbContext _context;
        public UserRepository(FutureProjectsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task Update(User user)
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

            result.Role = user.Role;
            result.Password = user.Password;
            result.Login = user.Login;
            result.Name = user.Name;
            result.Email = user.Email;

            await _context.SaveChangesAsync();
        }

        public async Task<string> UpdateEmail(int id, string email)
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                if ((await _context.Users.FirstOrDefaultAsync(x => x.Email == email)) == null)
                {
                    result.Email = email;
                    await _context.SaveChangesAsync();
                    return "Update Email";
                }
                return "Dublicate Email";
            }
            return "No such id exists";
        }

        public async Task<string> UpdateLogin(int id, string login)
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                if ((await _context.Users.FirstOrDefaultAsync(x => x.Login == login)) == null)
                {
                    result.Login = login;
                    await _context.SaveChangesAsync();
                    return "Update Login";
                }
                return "Dublicate Login";
            }
            return "No such id exists";
        }

        public async Task<string> UpdatePassword(int id, string password)
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                result.Password = password;
                await _context.SaveChangesAsync();
                return "Update Password";
            }
            return "No such id exists";
        }

        public async Task<string> UpdateName(int id, string name)
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                result.Name = name;
                await _context.SaveChangesAsync();
                return "Update Name";
            }
            return "No such id exists";
        }

        public async Task<string> UpdateRole(int id, string role)
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                result.Role = role;
                await _context.SaveChangesAsync();
                return "Update Role";
            }
            return "No such id exists";
        }
    }
}
