using Domain.Model.Models.Login.Interfaces;
using Domain.Model;
using Infra.Repository.RepositoryEntities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Repository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.RepositoryEntities
{
    public class AtivarContaRepository : RepositoryTable<AtivarContaDomain>, IAtivarContaRepository
    {
        public AtivarContaRepository(Context context) : base(context)
        {
        }

        public async Task<AtivarContaDomain?> ObterPorCodigo(Guid codigo)
        {
            return await _context.Set<AtivarContaDomain>().FirstOrDefaultAsync(x => x.Codigo == codigo);
        }
    }
}
