using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.ViewComponents
{
    public class _AboutComponentPartial : ViewComponent
    {
        MyPortfolioContext MyPortfolioContext = new MyPortfolioContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.aboutTitle = MyPortfolioContext.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.aboutDescription = MyPortfolioContext.Abouts.Select(x => x.SubDescription).FirstOrDefault();
            ViewBag.aboutDetail = MyPortfolioContext.Abouts.Select(x => x.Details).FirstOrDefault();
            return View();
        }
    }
}
