using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services.Contracts;

namespace StoreApp.Components
{
    public class ProductSummaryViewComponent : ViewComponent
    {
        private readonly IServicesManager _manager;

        public ProductSummaryViewComponent(IServicesManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            return _manager.ProductServices.GetAllProducts(false).Count().ToString();
        }
    }
}