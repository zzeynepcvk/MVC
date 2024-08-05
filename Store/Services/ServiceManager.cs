using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServicesManager
    {
        private readonly IProductServices _productService ;
        private readonly ICategoryServices _categoryService ;

        public ServiceManager(IProductServices productService, ICategoryServices categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IProductServices ProductServices => _productService;

        public ICategoryServices CategoryServices => _categoryService;
}
}