using Microsoft.EntityFrameworkCore;

namespace Munamii.Models;

public class CakeRepository : ICakeRepository
{
    private readonly CakeShopDbContext _cakeShopDbContext;

    public CakeRepository(CakeShopDbContext cakeShopDbContext)
    {
        _cakeShopDbContext = cakeShopDbContext;
    }

    public IEnumerable<Cake> AllCakes
    {
        get { return _cakeShopDbContext.Cakes.Include(c => c.Category); }
    }

    public IEnumerable<Cake> CakesOfTheWeek
    {
        get { return _cakeShopDbContext.Cakes.Include(c => c.Category).Where(c => c.IsCakeOfTheWeek); }
    }

    public Cake? GetCakeById(int cakeId)
    {
        return _cakeShopDbContext.Cakes.FirstOrDefault(c => c.CakeId == cakeId);
    }
}