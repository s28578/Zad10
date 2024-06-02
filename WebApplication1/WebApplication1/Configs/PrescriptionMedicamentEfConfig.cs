using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Entities.Configs;

public class PrescriptionMedicamentEfConfig: IEntityTypeConfiguration<PrescriptionMedicament>
{
    public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
    {
        builder
            .HasKey(x => new { x.IdMedicament, x.IdPrescription })
            .HasName("Prescription_Medicament_pk");
        builder.Property(x => x.Details)
            .HasMaxLength(100);
    }
}