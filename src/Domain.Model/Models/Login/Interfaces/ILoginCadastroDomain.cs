using Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Models.Login.Interfaces
{
    public interface ILoginCadastroDomain : IDomainTable
    {
        string? CPF { get; set; }

        string? Nome { get; set; }

        string? Email { get; set; }

        string? Senha { get; set; }

        DateTime? DataCriacao { get; set; }

        DateTime? DataAtualizacao { get; set; }

        bool? Ativado { get; set; }
    }
}
