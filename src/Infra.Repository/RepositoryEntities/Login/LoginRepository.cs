using Domain.Model;
using Domain.Model.Models.Login.Interfaces;
using Infra.Repository.Contexts;
using Infra.Repository.RepositoryEntities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.RepositoryEntities
{
    public class LoginRepository : RepositoryTable<LoginCadastroDomain>, ILoginRepository
    {
        public LoginRepository(Context context) : base(context)
        {
        }

        public async Task<LoginCadastroDomain?> ObterPorEmail(string email)
        {
            return await _context.Set<LoginCadastroDomain>().FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<LoginCadastroDomain?> ObterPorCpf(string cpf)
        {
            return await _context.Set<LoginCadastroDomain>().FirstOrDefaultAsync(x => x.CPF == cpf);
        }
    }
}
