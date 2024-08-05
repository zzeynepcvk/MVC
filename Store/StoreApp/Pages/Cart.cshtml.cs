using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using StoreApp.Infrastructure.Extensions;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServicesManager _manager;

        public Cart Cart { get; set; } //IoC
        public string ReturnUrl { get; set; } = "/";
        public CartModel(IServicesManager manager , Cart cartServices)
        {
            _manager = manager;
            Cart = cartServices;
        }


        

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        //    Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int productId , string returnUrl)
        {
            Product? product = _manager.ProductServices.GetOneProduct(productId,false);

            if (product is not null)
            {
            //    Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product,1);
            //    HttpContext.Session.SetJson<Cart>("cart",Cart);
            }
            return Page();
        }

        public IActionResult OnPostRemove(int id, string returnUrl)
        {
        //    Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.ProductId.Equals(id)).Product);
        //    HttpContext.Session.SetJson<Cart>("cart",Cart);
            return Page();
        }
    }
}