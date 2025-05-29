namespace ContactManagementApp.DTO;

public class ContactDto
{
    public int Id { get; init; }
    
    public string Name { get; init; } = null!;
    
    public string MobilePhone { get; init; } = null!;
    
    public string JobTitle { get; init; } = null!;
    
    public DateTime? BirthDate { get; init; }
}