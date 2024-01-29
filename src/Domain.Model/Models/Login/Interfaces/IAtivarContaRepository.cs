using Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Models.Login.Interfaces
{
    public interface IAtivarContaRepository : IRepositoryTable<AtivarContaDomain>
    {
        Task<AtivarContaDomain?> ObterPorCodigo(Guid codigo);
    }
}
