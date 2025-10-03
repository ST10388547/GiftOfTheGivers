namespace GiftOfTheGivers.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [Required][EmailAddress] public string Email { get; set; } = default!;
        [Required][DataType(DataType.Password)] public string Password { get; set; } = default!;
        public bool RememberMe { get; set; }
        public string? ReturnUrl { get; set; }
    }

}
