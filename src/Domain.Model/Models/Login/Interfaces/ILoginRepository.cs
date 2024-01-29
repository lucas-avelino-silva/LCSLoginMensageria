using Domain.Core.Interfaces;

namespace Domain.Model.Models.Login.Interfaces
{
    public interface ILoginRepository : IRepositoryTable<LoginCadastroDomain>
    {
        Task<LoginCadastroDomain?> ObterPorEmail(string email);

        Task<LoginCadastroDomain?> ObterPorCpf(string cpf);
    }
}
