using FinalProject.Models;

namespace FinalProject.Repos
{
    public interface IUserRepo
    {
        User GetUser(int id);
    }
}