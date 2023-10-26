using Microsoft.AspNetCore.Mvc;
using Munamii.Models;
using Munamii.ViewModels;

namespace Munamii.Controller;

public class HomeController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly ICakeRepository _cakeRepository;

    public HomeController(ICakeRepository cakeRepository)
    {
        _cakeRepository = cakeRepository;
    }

    // GET
    public IActionResult Index()
    {
        var cakesOfTheWeek = _cakeRepository.CakesOfTheWeek;
        var homeViewModel = new HomeViewModel(cakesOfTheWeek);
        return View(homeViewModel);
    }
}