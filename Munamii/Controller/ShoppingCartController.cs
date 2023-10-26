using Microsoft.AspNetCore.Mvc;
using Munamii.Models;
using Munamii.ViewModels;

namespace Munamii.Controller;

public class ShoppingCartController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly ICakeRepository _cakeRepository;
    private readonly IShoppingCart _shoppingCart;

    public ShoppingCartController(ICakeRepository cakeRepository, IShoppingCart shoppingCart)
    {
        _cakeRepository = cakeRepository;
        _shoppingCart = shoppingCart;

    }
    public ViewResult Index()
    {
        var items = _shoppingCart.GetShoppingCartItems();
        _shoppingCart.ShoppingCartItems = items;

        var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());

        return View(shoppingCartViewModel);
    }

    public RedirectToActionResult AddToShoppingCart(int cakeId)
    {
        var selectedCake = _cakeRepository.AllCakes.FirstOrDefault(p => p.CakeId == cakeId);

        if (selectedCake != null)
        {
            _shoppingCart.AddToCart(selectedCake);
        }
        return RedirectToAction("Index");
    }

    public RedirectToActionResult RemoveFromShoppingCart(int cakeId)
    {
        var selectedCake = _cakeRepository.AllCakes.FirstOrDefault(p => p.CakeId == cakeId);

        if (selectedCake != null)
        {
            _shoppingCart.RemoveFromCart(selectedCake);
        }
        return RedirectToAction("Index");
    }
}