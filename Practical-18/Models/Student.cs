using System.ComponentModel.DataAnnotations;

namespace Practical_18.Models;

public class Student
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public required string FirstName { get; set; }

    [Required]
    [StringLength(100)]
    public required string LastName { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Range(1, 80)]
    public int Age { get; set; }

    public string? Course { get; set; }

}
