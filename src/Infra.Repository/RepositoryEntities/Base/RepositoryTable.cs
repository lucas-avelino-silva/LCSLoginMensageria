using Domain.Core;
using Domain.Core.Interfaces;
using Infra.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.RepositoryEntities.Base
{
    public class RepositoryTable<TableObject> : RepositoryView<TableObject>, IRepositoryTable<TableObject> where TableObject : class, IDomainTable
    {
        public RepositoryTable(Context context) : base(context)
        {
        }

        public async Task Atualizar(TableObject tableObject)
        {
            await Task.Run(() => _context.Set<TableObject>().Update(tableObject));

            await Salvar();

            return;
        }

        public async Task Deletar(TableObject tableObject)
        {
            await Task.Run(() => _context.Set<TableObject>().Remove(tableObject));

            await Salvar();

            return;
        }

        public async Task<TableObject> Inserir(TableObject tableObject)
        {
            await _context.Set<TableObject>().AddAsync(tableObject);

            await Salvar();

            return tableObject;
        }

        public async Task<TableObject?> ObterPorId(Guid id)
        {
            return await _context.Set<TableObject>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Salvar()
        {
            return await _context.Save();
        }
    }
}
