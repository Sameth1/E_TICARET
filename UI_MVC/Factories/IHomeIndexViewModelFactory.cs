using UI_MVC.Models;

namespace UI_MVC.Factories
{
    public interface IHomeIndexViewModelFactory
    {
        Task<HomeIndexViewModel> Create(int page = 1, string? filterType = null, int? filterId = null);
    }
}

