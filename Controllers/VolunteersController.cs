using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using GiftOfTheGivers.Data;
using GiftOfTheGivers.Models;

[Authorize]
public class VolunteersController : Controller
{
    private readonly ApplicationDbContext _db;

    public VolunteersController(ApplicationDbContext db) => _db = db;

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var volunteers = await _db.Volunteers.Include(v => v.VolunteerProjects).ThenInclude(vp => vp.Project).ToListAsync();
        return View(volunteers);
    }

    [AllowAnonymous]
    public IActionResult Register() => View();

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(Volunteer model)
    {
        if (!ModelState.IsValid) return View(model);
        model.RegisteredAt = DateTime.UtcNow;
        _db.Volunteers.Add(model);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // Admin / assign
    public async Task<IActionResult> Assign(int volunteerId)
    {
        var vol = await _db.Volunteers.FindAsync(volunteerId);
        if (vol == null) return NotFound();
        ViewBag.Projects = await _db.Projects.ToListAsync();
        return View(vol);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Assign(int volunteerId, int projectId, string? role)
    {
        var exists = await _db.VolunteerProjects.FindAsync(volunteerId, projectId);
        if (exists == null)
        {
            _db.VolunteerProjects.Add(new VolunteerProject { VolunteerId = volunteerId, ProjectId = projectId, Role = role, JoinDate = DateTime.UtcNow });
            await _db.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
