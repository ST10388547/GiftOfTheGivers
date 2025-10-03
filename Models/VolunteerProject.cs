namespace GiftOfTheGivers.Models
{
    public class VolunteerProject
    {
        public int VolunteerId { get; set; }
        public Volunteer Volunteer { get; set; } = default!;
        public int ProjectId { get; set; }
        public Project Project { get; set; } = default!;
        public DateTime JoinDate { get; set; } = DateTime.UtcNow;
        public string? Role { get; set; }
    }

}
