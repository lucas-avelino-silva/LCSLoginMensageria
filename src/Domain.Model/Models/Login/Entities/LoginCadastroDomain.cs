using Domain.Core;
using Domain.Model.Models.Login.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class LoginCadastroDomain : DomainTable, ILoginCadastroDomain
    {
        ~LoginCadastroDomain() => Dispose();

        public override void Dispose()
        {
            base.Dispose();
            GC.SuppressFinalize(this);  
        }

        //public override bool IsValid()
        //{
        //    bool valid = true;

        //    if (string.IsNullOrWhiteSpace(CPF))
        //    {
        //        AddNotifications($"Campo \"CPF\" inválido.");

        //        valid = false;
        //    }

        //    if (string.IsNullOrWhiteSpace(Nome))
        //    {
        //        AddNotifications($"Campo \"Nome\" inválido.");

        //        valid = false;
        //    }

        //    if (string.IsNullOrWhiteSpace(Email))
        //    {
        //        AddNotifications($"Campo \"Email\" inválido.");

        //        valid = false;
        //    }

        //    if (string.IsNullOrWhiteSpace(Senha))
        //    {
        //        AddNotifications($"Campo \"Senha\" inválido.");

        //        valid = false;
        //    }

        //    if (this.Notifications != null)
        //    {
        //        valid = false;
        //    }

        //    return valid;
        //}

        public string? CPF { get; set; }

        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? Senha { get; set; }

        public DateTime? DataCriacao { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public bool? Ativado { get; set; } = false;

        public List<AtivarContaDomain>? Codigos { get; set; }
    }
}
