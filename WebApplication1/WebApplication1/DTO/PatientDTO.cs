using WebApplication1.Entities;

namespace WebApplication1.DTO;

public class PatientDTO
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    // public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
};