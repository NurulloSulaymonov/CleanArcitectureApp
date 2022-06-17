using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class LoginDto
{
    [Required]
    public string  Username { get; set; }
    [Required]
    public string Password { get; set; }
    public string ReturnUrl { get; set; }
}