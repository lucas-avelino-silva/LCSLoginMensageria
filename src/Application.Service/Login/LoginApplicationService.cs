using Application.Service.Interfaces;
using Application.ViewModel.Entity;
using AutoMapper;
using Domain.Model;
using Domain.Model.Models.Login.Interfaces;
using Infra.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Login
{
    public class LoginApplicationService : ILoginApplicationService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;

        public LoginApplicationService(ILoginRepository loginRepository, IMapper mapper)
        {
            _loginRepository = loginRepository;
            _mapper = mapper;
        }

        public async Task<LoginCadastroViewModel> CadastrarNovoUsuario(LoginCadastroViewModel login)
        {
            var loginEmail = await _loginRepository.ObterPorEmail(login.Email!);

            var loginCpf = await _loginRepository.ObterPorCpf(login.CPF!);

            if (loginEmail != null)
            {
                login.AddNotifications("E-mail já cadastrado em nosso sistema.");
            }

            if (loginCpf != null)
            {
                login.AddNotifications("CPF já cadastrado em nosso sistema.");
            }

            if (!login.IsValid()) return login;

            login.Senha = LibraryCrypt.HashMD5(login.Senha!);

            login.Id = Guid.NewGuid();

            return _mapper.Map<LoginCadastroViewModel>(await _loginRepository.Inserir(_mapper.Map<LoginCadastroDomain>(login)));
        }

        public async Task<LoginCadastroViewModel?> ObterPorEmail(string email)
        {
            return _mapper.Map<LoginCadastroViewModel>(await _loginRepository.ObterPorEmail(email));
        }

        public async Task<LoginCadastroViewModel?> ObterPorId(Guid id)
        {
            return _mapper.Map<LoginCadastroViewModel>(await _loginRepository.ObterPorId(id));
        }

        public async Task<bool> AtualizarConta(LoginCadastroViewModel conta)
        {
            if (!conta.IsValid()) return false;

            conta.Ativado = true;

            conta.DataAtualizacao = DateTime.Now;

            await _loginRepository.Atualizar(_mapper.Map<LoginCadastroDomain>(conta));

            return await _loginRepository.Salvar();
        }
    }
}
