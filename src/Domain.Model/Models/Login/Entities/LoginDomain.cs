using Domain.Core;
using Domain.Model.Models.Login.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class LoginDomain : DomainTable, ILoginDomain
    {
        ~LoginDomain() => Dispose();

        public override void Dispose()
        {
            base.Dispose();
            GC.SuppressFinalize(this);  
        }

        public string? Email { get; set; }

        public string? Senha { get; set; } 
    }
}
