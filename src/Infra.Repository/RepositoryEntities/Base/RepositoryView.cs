using Domain.Core.Interfaces;
using Infra.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.RepositoryEntities
{
    public class RepositoryView<ViewObject> : IRepositoryView<ViewObject> where ViewObject : class, IDomainView
    {
        protected Context _context;

        public RepositoryView(Context context)
        {
            _context = context;
        }

        public async Task<List<ViewObject>> ObterTodos()
        {
            return await _context.Set<ViewObject>().ToListAsync();
        }
    }
}
