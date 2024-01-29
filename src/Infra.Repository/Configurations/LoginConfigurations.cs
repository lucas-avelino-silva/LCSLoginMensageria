using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Configurations
{
    public class LoginConfigurations : IEntityTypeConfiguration<LoginCadastroDomain>
    {
        public void Configure(EntityTypeBuilder<LoginCadastroDomain> builder)
        {
            builder.ToTable("TB_Login");

            builder.HasKey(x => x.Id);

            builder.Property(b => b.Id).HasColumnName("ID");

            builder.Property(b => b.CPF).HasColumnName("CPF");

            builder.Property(b => b.Nome).HasColumnName("NOME");

            builder.Property(b => b.Email).HasColumnName("EMAIL");

            builder.Property(b => b.DataCriacao).HasColumnName("DATACRIACAO");

            builder.Property(b => b.DataAtualizacao).HasColumnName("DATAATUALIZACAO");

            builder.Property(b => b.Ativado).HasColumnName("ATIVADO");

        }
    }
}
