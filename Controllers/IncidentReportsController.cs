using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using GiftOfTheGivers.Data;
using GiftOfTheGivers.Models;
using Microsoft.AspNetCore.Identity;

[Authorize]
public class IncidentReportsController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public IncidentReportsController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
    {
        _db = db;
        _userManager = userManager;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var list = await _db.IncidentReports.Include(i => i.User).OrderByDescending(i => i.ReportedAt).ToListAsync();
        return View(list);
    }

    public IActionResult Create() => View(new IncidentReport { ReportedAt = DateTime.UtcNow });

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(IncidentReport model)
    {
        if (!ModelState.IsValid) return View(model);

        var user = await _userManager.GetUserAsync(User);
        if (user != null) model.User = user;

        model.ReportedAt = DateTime.UtcNow;
        _db.IncidentReports.Add(model);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [AllowAnonymous]
    public async Task<IActionResult> Details(int id)
    {
        var inc = await _db.IncidentReports.Include(i => i.User).FirstOrDefaultAsync(i => i.IncidentId == id);
        if (inc == null) return NotFound();
        return View(inc);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Close(int id)
    {
        var inc = await _db.IncidentReports.FindAsync(id);
        if (inc == null) return NotFound();
        inc.Status = "closed";
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Details), new { id });
    }
}
