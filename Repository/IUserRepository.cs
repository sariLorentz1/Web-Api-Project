using entities;

namespace Repository
{
    public interface IUserRepository
    {
        Task<User> addUserAsync(User user);
        Task<bool> existUserNameAsync(string userName);
        Task<User> foundUserAsync(User userToSearch);
        Task<User> getUserAsync(int id);
        Task updateUserAsync(User userToUpdate, int id);

    }
}