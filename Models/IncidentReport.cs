using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGivers.Models
{
    public class IncidentReport
    {
        [Key]
        public int IncidentId { get; set; }
        [Required]
        public String? UserId { get; set; }
        [Required]
        public ApplicationUser? User { get; set; }

        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string? Location { get; set; }
        public string Severity { get; set; } = "medium";
        public DateTime ReportedAt { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "open";
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }

}
