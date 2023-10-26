using Microsoft.AspNetCore.Mvc;
using Munamii.Models;
using Munamii.ViewModels;

namespace Munamii.Controller;

public class CakeController: Microsoft.AspNetCore.Mvc.Controller
{
    private readonly ICakeRepository _cakeRepository;

    private readonly ICategoryRepository _categoryRepository;

    public CakeController(ICakeRepository cakeRepository, ICategoryRepository categoryRepository)
    {
        _cakeRepository = cakeRepository;
        _categoryRepository = categoryRepository;
    }

    // GET
    // public IActionResult List()
    // {
    //     CakeListViewModel cakeListViewModel = new CakeListViewModel(_cakeRepository.AllCakes, "All cakes");
    //     return View(cakeListViewModel);
    // }
    
    public ViewResult List(string category)
    {
        IEnumerable<Cake> cakes;
        string? currentCategory;

        if (string.IsNullOrEmpty(category))
        {
            cakes = _cakeRepository.AllCakes.OrderBy(p => p.CakeId);
            currentCategory = "All Cakes";
        }
        else
        {
            cakes = _cakeRepository.AllCakes.Where(p => p.Category.CategoryName == category)
                .OrderBy(p => p.CakeId);
            currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
        }

        return View(new CakeListViewModel(cakes, currentCategory));
    }
    
    public IActionResult Details(int id)
    {
        var cake = _cakeRepository.GetCakeById(id);
        if (cake == null)
        {
            return NotFound();
        }

        return View(cake);

    }
}