using Application.ViewModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Interfaces
{
    public interface ILoginApplicationService
    {
        Task<LoginCadastroViewModel> CadastrarNovoUsuario(LoginCadastroViewModel login);

        Task<LoginCadastroViewModel?> ObterPorEmail(string email);

        Task<LoginCadastroViewModel?> ObterPorId(Guid id);

        Task<bool> AtualizarConta(LoginCadastroViewModel conta);
    }
}
