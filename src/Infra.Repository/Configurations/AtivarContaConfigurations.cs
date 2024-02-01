using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Configurations
{
    public class AtivarContaConfigurations : IEntityTypeConfiguration<AtivarContaDomain>
    {
        public void Configure(EntityTypeBuilder<AtivarContaDomain> builder)
        {
            builder.ToTable("TB_CODIGOCADASTRO");

            builder.HasKey(x => x.Id);

            builder.Property(b => b.Id).HasColumnName("ID");

            builder.Property(b => b.Codigo).HasColumnName("CODIGO");

            builder.Property(b => b.DataCriacao).HasColumnName("DATACRIACAO");

            builder.Property(b => b.DataExpiracao).HasColumnName("DATAEXPIRACAO");

            builder.HasOne(b => b.LoginDomain).WithMany(b => b.Codigos).HasForeignKey(b => b.IdLogin);
        }
    }
}
