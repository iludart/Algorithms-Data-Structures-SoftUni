namespace UsersSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using UsersSystem.Models.Attributes;

    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Username { get; set; }

        [Required]
        [Password(minLength: 4, maxLength:50, ShouldContainLowercase = true, ShouldContainUppercase = true, ShouldContainDigit = true, ShouldContainSpecialSymbol = true, ErrorMessage = "Invalid password.")]
        public string Password { get; set; }

        [Required]
        [Email(ErrorMessage = "Invalid email.")]
        public string Email { get; set; }

        [MaxLength(1024 * 1024)]
        public byte[] ProfilePicture { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime LastTimeLoggedIn { get; set; }

        [Range(1, 120, ErrorMessage = "Invalid age.")]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }
    }
}
