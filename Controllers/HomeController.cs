using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiftOfTheGivers.Data;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _db;

    public HomeController(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var eventsList = await _db.Events
            .Include(e => e.Project)
            .OrderBy(e => e.Date)
            .ToListAsync();

        return View(eventsList);
    }
}


