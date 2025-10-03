namespace GiftOfTheGivers.Models
{
    public class Donation
    {
        public int DonationId { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public int? ProjectId { get; set; }
        public Project? Project { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string PaymentMethod { get; set; } = default!;
        public string? Notes { get; set; }
    }

}
