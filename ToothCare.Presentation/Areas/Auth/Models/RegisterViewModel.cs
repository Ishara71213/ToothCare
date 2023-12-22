namespace ToothCare.Presentation.Areas.Auth.Models
{
    public class RegisterViewModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
        public string MobileNo { get; set; } = null!;
        public string Address { get; set; } = null!;

    }
}
