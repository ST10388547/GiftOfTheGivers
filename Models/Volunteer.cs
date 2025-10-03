using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGivers.Models
{
    public class Volunteer
    {
        [Key]
        public int VolunteerId { get; set; }

        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string? Phone { get; set; }
        public string? Skills { get; set; }
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

        public ICollection<VolunteerProject>? VolunteerProjects { get; set; }
    }

}
