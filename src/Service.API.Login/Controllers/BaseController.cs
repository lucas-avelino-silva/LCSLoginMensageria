using Application.Core.ViewModel;
using Application.ViewModel.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Service.API.Login.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        public BaseController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        public List<ResponsemMensagem> Notificacao { get; set; } = new();

        public void VerificarErros(ViewModelTableCore viewModel)
        {
            if (!viewModel.IsValid())
            {
                foreach(var erro in viewModel.Notifications)
                {
                    Notificacao.Add(new ResponsemMensagem
                    {
                        Codigo = 400,
                        Mensagem = erro
                    } );
                }
            }
        }

        public class APIResponse
        {
            public Object? Conteudo { get; set; }

            public int? Codigo { get; set; }

            public List<ResponsemMensagem>? Erros { get; set; } = new();

            protected bool IsValid()
            {
                return !(Erros?.Count > 0);
            }

            public void AddInformation(int cod, string mensagem)
            {
                Codigo = cod;

                Erros.Add(new ResponsemMensagem
                {
                    Codigo = cod,

                    Mensagem = mensagem
                });
            }

            public void SetContent(ViewModelTableCore content)
            {
                if(!content.IsValid())
                {
                    foreach (var mensagem in content.Notifications)
                    {
                        AddInformation(400, mensagem);
                    }

                    Codigo = 400;
                }

                if (this.IsValid())
                {
                    Codigo = 200;

                    Conteudo = content;
                }
            }

            public APIResponse Response() 
            {
                return this;
            }
        }

        public class ResponsemMensagem
        {
            public int Codigo { get; set; }

            public string? Mensagem { get; set; }
        }
    }
}