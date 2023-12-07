﻿namespace ToothCare.Presentation.Areas.Auth.Models
{
    public class RegisterViewModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
        public int MobileNo { get; set; }
        public string Address { get; set; } = null!;
    }
}
