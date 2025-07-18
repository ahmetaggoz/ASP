using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.ViewComponents
{
    public class _SkillComponentPartial : ViewComponent
    {
        MyPortfolioContext MyPortfolioContext = new MyPortfolioContext();
        public IViewComponentResult Invoke()
        {
            var values = MyPortfolioContext.Skills.ToList();
            return View(values);
        }
    }
    
}
