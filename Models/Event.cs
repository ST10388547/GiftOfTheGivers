using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGivers.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public int? ProjectId { get; set; }
        public Project? Project { get; set; }
        public string Title { get; set; } = default!;
        public DateTime Date { get; set; }
        public string Location { get; set; } = default!;
    }

}
