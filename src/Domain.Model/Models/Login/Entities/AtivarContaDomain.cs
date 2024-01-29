using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class AtivarContaDomain : DomainTable, IAtivarContaDomain
    {
        ~AtivarContaDomain() => Dispose();

        public override void Dispose()
        {
            base.Dispose();
            GC.SuppressFinalize(this);
        }

        public Guid IdLogin { get; set; }

        public Guid Codigo { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
