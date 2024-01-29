using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Interfaces
{
    public interface IRepositoryTable<DomainObject> : IRepositoryView<DomainObject> where DomainObject : class, IDomainTable, IDisposable
    {
        Task<DomainObject?> ObterPorId(Guid id);

        Task<DomainObject> Inserir(DomainObject tableObject);

        Task Atualizar(DomainObject tableObject);

        Task Deletar(DomainObject tableObject);

        Task<bool> Salvar();
    }
}
