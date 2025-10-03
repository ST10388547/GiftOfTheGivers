using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using GiftOfTheGivers.Data;
using GiftOfTheGivers.Models;

[Authorize]
public class ProjectsController : Controller
{
    private readonly ApplicationDbContext _db;
    public ProjectsController(ApplicationDbContext db) => _db = db;

    [AllowAnonymous]
    public async Task<IActionResult> Index() => View(await _db.Projects.ToListAsync());

    [AllowAnonymous]
    public async Task<IActionResult> Details(int id)
    {
        var project = await _db.Projects.Include(p => p.Events).Include(p => p.VolunteerProjects).FirstOrDefaultAsync(p => p.ProjectId == id);
        if (project == null) return NotFound();
        return View(project);
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Create() => View();

    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Project project)
    {
        if (!ModelState.IsValid) return View(project);
        _db.Projects.Add(project);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(int id)
    {
        var project = await _db.Projects.FindAsync(id);
        if (project == null) return NotFound();
        return View(project);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Project project)
    {
        if (!ModelState.IsValid) return View(project);
        _db.Projects.Update(project);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}

