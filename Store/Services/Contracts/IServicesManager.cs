namespace Services.Contracts
{
    public interface IServicesManager
    {
        IProductServices ProductServices {get ;}
        ICategoryServices CategoryServices {get ;}
    }
} 