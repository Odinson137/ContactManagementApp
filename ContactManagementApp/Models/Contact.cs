using System.ComponentModel.DataAnnotations;

namespace ContactManagementApp.Models;

public class Contact
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Mobile phone is required")]
    [RegularExpression(@"^\+?\d{10,15}$", ErrorMessage = "Invalid phone number format")]
    public string MobilePhone { get; set; } = null!;

    [StringLength(100, ErrorMessage = "Job title cannot be longer than 100 characters")]
    public string JobTitle { get; set; } = null!;

    [DataType(DataType.Date)]
    public DateTime? BirthDate { get; set; }
}