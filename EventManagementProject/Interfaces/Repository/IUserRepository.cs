using EventManagementProject.Models;

namespace EventManagementProject.Interfaces.Repository
{
    public interface IUserRepository : IRepository<int,User>
    {
        public Task<User> GetUserByEmail(string email);
        public Task<User> GetUserByEmailWithUserCredential(string email);
    }
}
