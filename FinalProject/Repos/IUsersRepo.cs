using FinalProject.Models;

namespace FinalProject.Repos
{
    public interface IUsersRepo
    {
        User GetUser(int id);
        UsersList GetUsers();
        User PostUser(UserPost userPost);
    }
}