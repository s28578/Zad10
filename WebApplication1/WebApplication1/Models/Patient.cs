using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entities;

public class Patient
{
    [Key]
    public int IdPatient { get; set; }
    [MaxLength(200)]
    [Required]
    public string FirstName { get; set; }
    [MaxLength(200)]
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    
    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}