using Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Models
{
    public class DomainView : IDomainView
    {
        ~DomainView() => Dispose();

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
