namespace GiftOfTheGivers.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required][EmailAddress] public string Email { get; set; } = default!;
        [Required] public string Name { get; set; } = default!;
        [Required] public string Surname { get; set; } = default!;
        public string? Phone { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; } = default!;
    }

}
