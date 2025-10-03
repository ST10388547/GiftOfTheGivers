using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGivers.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Email { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public string? Phone { get; set; }
        public string? PasswordHash { get; set; } // only for local Identity fallback
        public string Role { get; set; } = "donor";

        public ICollection<Donation>? Donations { get; set; }
        public ICollection<IncidentReport>? IncidentReports { get; set; }
    }

}
