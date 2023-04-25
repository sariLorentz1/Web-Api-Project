using entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Repository
{
    //Data Source=SRV2\PUPILS;Initial Catalog=213259948;Integrated Security=True
    public class UserRepository : IUserRepository
    {
        string filePath = "./usersDetails.txt";

        IceShopContext dbContext = new IceShopContext();

        public UserRepository(IceShopContext DBContext) {
            this.dbContext = DBContext;
        }
        public async Task<User> foundUserAsync(User userToSearch)
        {
            var user = await dbContext.Users.Where(u => u.Email == userToSearch.Email && u.Password == userToSearch.Password).ToListAsync();
            return user[0];
        }

        public async Task<Boolean> existUserNameAsync(String userName)
        {
            var user = await dbContext.Users.Where(u => u.Email == userName).ToListAsync();
            if (user != null)
            {
                return false;
            }
            return true;
        }

        public async Task<User> addUserAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }


        public async Task updateUserAsync(User userToUpdate, int id)
        {
            dbContext.Users.Update(userToUpdate);
            await dbContext.SaveChangesAsync();
        }

        public async Task<User> getUserAsync(int id)
        {
            var user = await dbContext.Users.Where(u => u.Id == id).ToListAsync();
            return user[0];
        }
    }
}