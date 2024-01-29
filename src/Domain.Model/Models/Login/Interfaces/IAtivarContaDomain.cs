using Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public interface IAtivarContaDomain : IDomainTable
    {
        Guid IdLogin { get; set; }

        Guid Codigo { get; set; }

        DateTime DataCriacao { get; set; }
    }
}
