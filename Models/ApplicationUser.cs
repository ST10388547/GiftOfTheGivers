namespace GiftOfTheGivers.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }

        // navigation
        public ICollection<Donation>? Donations { get; set; }
        public ICollection<IncidentReport>? IncidentReports { get; set; }
    }

}
