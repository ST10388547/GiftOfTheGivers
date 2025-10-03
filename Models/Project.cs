using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGivers.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public string Location { get; set; } = default!;
        public string Status { get; set; } = "planned";

        public ICollection<Donation>? Donations { get; set; }
        public ICollection<Event>? Events { get; set; }
        public ICollection<VolunteerProject>? VolunteerProjects { get; set; }
    }

}
