using UI_MVC.Models;

namespace UI_MVC.Factories
{
    public interface IHomeDetailViewModelFactory
    {
        Task<HomeDetailViewModel> Create(int productId);
    }
}
