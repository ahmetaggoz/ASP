using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.ViewComponents
{
    public class _FeatureComponentPartial : ViewComponent
    {
        MyPortfolioContext myPortfolioContext = new MyPortfolioContext();
        public IViewComponentResult Invoke()
        {
            var values = myPortfolioContext.Features.ToList();
            return View(values);
        }
    }
    
}
