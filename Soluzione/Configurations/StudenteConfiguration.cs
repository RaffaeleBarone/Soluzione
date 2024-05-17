using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Progetto1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto1.Configurations
{
    public class StudenteConfiguration : IEntityTypeConfiguration<Studente>
    {
        public void Configure(EntityTypeBuilder<Studente> builder)
        {
            builder.ToTable("Studente").HasKey("Id");
            builder.Property("Nome").HasMaxLength(32);
            builder.Property("Cognome").HasMaxLength(32);
        }
    }
}
