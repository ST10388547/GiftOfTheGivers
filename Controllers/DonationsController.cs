using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using GiftOfTheGivers.Data;
using GiftOfTheGivers.Models;
using Microsoft.AspNetCore.Identity;

[Authorize]
public class DonationsController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public DonationsController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
    {
        _db = db;
        _userManager = userManager;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var donations = await _db.Donations.Include(d => d.User).Include(d => d.Project).OrderByDescending(d => d.Date).ToListAsync();
        return View(donations);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Projects = await _db.Projects.ToListAsync();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Donation donation)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Projects = await _db.Projects.ToListAsync();
            return View(donation);
        }

        var user = await _userManager.GetUserAsync(User);
        if (user != null)
        {
            donation.UserId = user.Id; 
        }
        
        donation.Date = DateTime.UtcNow;
        _db.Donations.Add(donation);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}

