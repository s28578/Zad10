using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Entities.Configs;

public class MedicamentEfConfig: IEntityTypeConfiguration<Medicament>
{
    public void Configure(EntityTypeBuilder<Medicament> builder)
    {
        builder
            .HasKey(x => x.IdMedicament)
            .HasName("Medicament_pk");

        //builder.Property(x => x.Id).UseIdentityColumn();
        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder
            .Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(100);
        builder
            .Property(x => x.Type)
            .IsRequired()
            .HasMaxLength(100);
    }
}