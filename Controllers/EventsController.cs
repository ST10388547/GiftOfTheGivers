using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using GiftOfTheGivers.Data;
using GiftOfTheGivers.Models;

[Authorize]
public class EventsController : Controller
{
    private readonly ApplicationDbContext _db;
    public EventsController(ApplicationDbContext db) => _db = db;

    [AllowAnonymous]
    public async Task<IActionResult> Index() => View(await _db.Events.Include(e => e.Project).OrderBy(e => e.Date).ToListAsync());

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create()
    {
        ViewBag.Projects = await _db.Projects.ToListAsync();
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Event model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Projects = await _db.Projects.ToListAsync();
            return View(model);
        }
        _db.Events.Add(model);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
