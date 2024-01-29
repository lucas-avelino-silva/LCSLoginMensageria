using Application.Service.Interfaces;
using Application.ViewModel.Entity;
using AutoMapper;
using Domain.Model;
using Domain.Model.Models.Login.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Login
{
    public class AtivarContaApplicationService : IAtivarContaApplicationService
    {
        private readonly IAtivarContaRepository _AtivarContaRepository;
        private readonly IMapper _mapper;

        public AtivarContaApplicationService(IAtivarContaRepository ativarContaRepository, IMapper mapper)
        {
            _AtivarContaRepository = ativarContaRepository;
            _mapper = mapper;
        }

        public async Task<AtivarContaViewModel> Inserir(AtivarContaViewModel ativarConta)
        {
            if (!ativarConta.IsValid()) return ativarConta;

            return _mapper.Map<AtivarContaViewModel>(await _AtivarContaRepository.Inserir(_mapper.Map<AtivarContaDomain>(ativarConta)));
        }

        public async Task<AtivarContaViewModel> Atualizar(AtivarContaViewModel ativarConta)
        {
            if (!ativarConta.IsValid()) return ativarConta;

            await _AtivarContaRepository.Atualizar(_mapper.Map<AtivarContaDomain>(ativarConta));

            return ativarConta;
        }

        public async Task<AtivarContaViewModel?> ObterPorCodigo(Guid codigo)
        {
            return _mapper.Map<AtivarContaViewModel>(await _AtivarContaRepository.ObterPorCodigo(codigo));
        }

        public async Task<bool> Deletar(AtivarContaViewModel ativarConta)
        {
            if (!ativarConta.IsValid()) return false;

            await _AtivarContaRepository.Deletar(_mapper.Map<AtivarContaDomain>(ativarConta));

            return await _AtivarContaRepository.Salvar();
        }
    }
}
