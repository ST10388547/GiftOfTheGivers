using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index() => View();
    public IActionResult About() => View();
}
