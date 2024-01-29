using Application.Core.ViewModel;

namespace Application.ViewModel.Entity
{
    public class LoginCadastroViewModel : ViewModelTableCore
    {
        ~LoginCadastroViewModel() => Dispose();

        public override void Dispose()
        {
            base.Dispose();
            GC.SuppressFinalize(this);
        }

        public LoginCadastroViewModel()
        {
            DataCriacao = DateTime.Now;
        }

        public override bool IsValid()
        {
            bool valid = true;

            if (string.IsNullOrWhiteSpace(CPF))
            {
                AddNotifications($"Campo \"CPF\" inválido.");

                valid = false;
            }

            if (string.IsNullOrWhiteSpace(Nome))
            {
                AddNotifications($"Campo \"Nome\" inválido.");

                valid = false;
            }

            if (string.IsNullOrWhiteSpace(Email))
            {
                AddNotifications($"Campo \"Email\" inválido.");

                valid = false;
            }

            if (string.IsNullOrWhiteSpace(Senha))
            {
                AddNotifications($"Campo \"Senha\" inválido.");

                valid = false;
            }

            if(this.Notifications.Count > 0)
            {
                valid = false;
            }

            return valid;
        }

        public string? CPF { get; set; }

        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? Senha { get; set; }

        public DateTime? DataCriacao { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public bool? Ativado { get; set; } = false;
    }
}