namespace Munamii.Models;

public interface ICakeRepository
{
    IEnumerable<Cake> AllCakes { get; }
    IEnumerable<Cake> CakesOfTheWeek { get; }
    Cake? GetCakeById(int cakeId);
}