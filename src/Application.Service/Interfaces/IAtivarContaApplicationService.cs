using Application.ViewModel.Entity;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Interfaces
{
    public interface IAtivarContaApplicationService
    {

        Task<AtivarContaViewModel> Inserir(AtivarContaViewModel ativarConta);


        Task<AtivarContaViewModel> Atualizar(AtivarContaViewModel ativarConta);

        Task<AtivarContaViewModel?> ObterPorCodigo(Guid codigo);

        Task<bool> Deletar(AtivarContaViewModel ativarConta);

    }
}
