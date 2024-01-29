using Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public abstract class DomainTable : IDomainTable
    {
        ~DomainTable() => Dispose();

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public DomainTable()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        //public List<string>? Notifications { get; set; } = new List<string>();

        //protected void AddNotifications(string mensagem)
        //{
        //    Notifications!.Add(mensagem);
        //}
    }
}
