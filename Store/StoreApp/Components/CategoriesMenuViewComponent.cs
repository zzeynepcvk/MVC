using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components
{
    public class CategoriesMenuViewComponent : ViewComponent
    {
        private readonly IServicesManager _manager;

        public CategoriesMenuViewComponent(IServicesManager manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _manager.CategoryServices.GetAllCategories(false);
            return View(categories);
        }
    }
}