using LABAPI.Models;

namespace LABAPI.Services
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User? Get(Guid id);
        User Create(User user);
        bool Update(Guid id, User user);
        bool Delete(Guid id);
    }
}
