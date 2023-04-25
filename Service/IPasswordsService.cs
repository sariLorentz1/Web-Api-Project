using entities;

namespace Service
{
    public interface IPasswordsService
    {
        int getPasswordRate(Password password);
    }
}