using Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Models.Login.Interfaces
{
    public interface ILoginDomain : IDomainTable
    {
        string? Email { get; set; }

        string? Senha { get; set; }
    }
}
