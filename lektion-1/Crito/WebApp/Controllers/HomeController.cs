using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
                News = new List<NewsModel>()
                {
                    new NewsModel
                    {
                        Id = 1,
                        Name = "News 1",
                        Description = "Description for news 1",
                        Tags = new List<string> { "business", ".net" },
                        Category = "IT",
                        Image = "~/images/news-1.jpg",
                        Author = "Hans Mattin-Lassei",
                        Created = DateTime.Now
                    }
                },
                Projects = new List<ProjectModel>()
            };

            return View(viewModel);
        }
    }
}
