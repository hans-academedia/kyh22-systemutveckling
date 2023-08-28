using WebApp.Models;

namespace WebApp.ViewModels;

public class HomeViewModel
{
    public string Title { get; set; } = "Home";
    public List<ProjectModel> Projects { get; set; } = null!;
    public List<NewsModel> News { get; set; } = null!;
}
