using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Progetto1.Models;

namespace Progetto1.Configurations
{
    public class EsameConfiguration : IEntityTypeConfiguration<Esame>
    {
        public void Configure(EntityTypeBuilder<Esame> builder)
        {
            builder.ToTable("Esame").HasKey("Id");
            builder.Property("Nome").HasMaxLength(32);
            builder.HasOne<Studente>(x => x.Studente)
                .WithMany(x => x.EsamiFatti)
                .HasForeignKey(x => x.IdStudente);
        }
    }
}
