using Application.Service.Interfaces;
using Application.Service.Login;
using Application.ViewModel.Entity;
using Infra.Library;
using Infra.Mensageria;
using Microsoft.AspNetCore.Mvc;
using Service.Core.Events;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Service.API.Login.Controllers
{
    [Route("Login")]
    public class LoginController : BaseController
    {
        private readonly ILogger<LoginController> _logger;

        private ILoginApplicationService _loginAppService;

        private IAtivarContaApplicationService _ativarContaAppService;

        private IMessageBusService _messageBusService;

        public LoginController(ILoginApplicationService loginAppservice, IAtivarContaApplicationService ativarContaApp, IMessageBusService messageBusService, ILogger<LoginController> logger) : base(logger)
        {
            _loginAppService = loginAppservice;
            _ativarContaAppService = ativarContaApp;
            _messageBusService = messageBusService;
            _logger = logger;
        }

        [HttpPost("Cadastrar")]
        public async Task<APIResponse> Cadastrar(LoginCadastroViewModel login)
        {
            var response = new APIResponse();

            try
            {
                if (ModelState.IsValid && login.IsValid())
                {
                    var retorno = await _loginAppService.CadastrarNovoUsuario(login);

                    if (!retorno.IsValid())
                    {
                        foreach (var erro in retorno.Notifications!)
                        {
                            response.AddInformation(400, erro);
                        }

                        return response.Response();
                    }

                    var atvarContaModel = await _ativarContaAppService.Inserir(new AtivarContaViewModel((Guid)retorno.Id!, Guid.NewGuid()));

                    var AtivacaoEvent = new AtivarContaEvent(login.Email!, atvarContaModel.Codigo.ToString());

                    _messageBusService.Publicar(AtivacaoEvent, "NotificarEmail");

                    response.SetContent(retorno);
                }
                else
                {
                    if (ModelState.ErrorCount > 0)
                    {
                        var erros = ModelState.Values.SelectMany(x => x.Errors);

                        foreach (var erro in erros)
                        {
                            response.AddInformation(400, erro.ErrorMessage);
                        }
                    }

                    if (!login.IsValid())
                    {
                        var erros = login.Notifications!;

                        foreach (var erro in erros)
                        {
                            response.AddInformation(400, erro);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.AddInformation(500, ex.Message);
            }

            return response.Response();
        }

        [HttpPost("Logar")]
        public async Task<APIResponse> Logar(LoginViewModel login)
        {
            var response = new APIResponse();

            try
            {
                if (ModelState.IsValid && login.IsValid())
                {
                    var loginTemp = await _loginAppService.ObterPorEmail(login.Email!);

                    if (!(bool)loginTemp!.Ativado!)
                    {
                        response.AddInformation(400, "Conta não ativada, verifique o seu e-mail.");
                    }

                    if (loginTemp == null || loginTemp.Senha!.Equals(LibraryCrypt.HashMD5(login.Senha!)))
                    {
                        response.AddInformation(400, "Login ou senha incorreto.");
                    }

                    response.SetContent(loginTemp);
                }
                else
                {
                    if (ModelState.ErrorCount > 0)
                    {
                        var erros = ModelState.Values.SelectMany(x => x.Errors);

                        foreach (var erro in erros)
                        {
                            response.AddInformation(400, erro.ErrorMessage);
                        }
                    }

                    if (!login.IsValid())
                    {
                        var erros = login.Notifications!;

                        foreach (var erro in erros)
                        {
                            response.AddInformation(400, erro);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.AddInformation(500, ex.Message);
            }

            return response.Response();
        }

        [HttpGet("AtivarConta/{codigo:guid}")]
        public async Task<APIResponse> AtivarConta([FromRoute] Guid codigo)
        {
            var response = new APIResponse();

            try
            {
                if (ModelState.IsValid && !(codigo == new Guid()))
                {
                    var contaTemp = await _ativarContaAppService.ObterPorCodigo(codigo);

                    if (contaTemp == null)
                    {
                        response.AddInformation(400, "Código inválido.");

                        return response.Response();
                    }

                    var loginTemp = await _loginAppService.ObterPorId(contaTemp.IdLogin);

                    if (loginTemp == null)
                    {
                        response.AddInformation(400, "Não foi possível ativar a conta.");

                        return response.Response();
                    }

                    var ativacao = await _loginAppService.AtualizarConta(loginTemp);

                    if (!ativacao)
                    {
                        response.AddInformation(400, "Não foi possível ativar a conta.");

                        return response.Response();
                    }

                    await _ativarContaAppService.Deletar(contaTemp);

                    response.SetContent(loginTemp);
                }
                else
                {
                    if (ModelState.ErrorCount > 0)
                    {
                        var erros = ModelState.Values.SelectMany(x => x.Errors);

                        foreach (var erro in erros)
                        {
                            response.AddInformation(400, erro.ErrorMessage);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.AddInformation(500, ex.Message);
            }

            return response.Response();
        }
    }
}