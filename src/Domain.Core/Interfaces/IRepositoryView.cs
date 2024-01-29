using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Interfaces
{
    public interface IRepositoryView<ViewObject> where ViewObject : class, IDomainView, IDisposable
    {
        Task<List<ViewObject>> ObterTodos();
    }
}
