using FinalProject.Models;

namespace FinalProject.Repos
{
    public interface IRestaurantsRepo
    {
        ResSummary GetRestaurant(int id);
        ResList GetRestaurants();
        ResSummary PostRestaurant(ResPost resPost);
    }
}