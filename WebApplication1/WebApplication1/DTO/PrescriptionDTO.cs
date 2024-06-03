namespace WebApplication1.DTO;

public class PrescriptionDTO
{
    public PatientDTO PatientDto{ get; init; }
    public IList<MedicamentDTO> MedicamentDtos{ get; init; }
    public DateTime Date{ get; init; }
    public DateTime DueDate { get; init; }

};