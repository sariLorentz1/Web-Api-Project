using entities;

namespace Service
{
    public interface IUserService
    {
        Task<User> getbyIdAsync(int id);
        Task<User> loginAsync(User user);
        Task<User> registerAsync(User user);
        Task updateAsync(User user, int id);
    }
}