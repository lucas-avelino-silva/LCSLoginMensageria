using Application.Core.ViewModel;

namespace Application.ViewModel.Entity
{
    public class LoginViewModel : ViewModelTableCore
    {
        ~LoginViewModel() => Dispose();

        public override void Dispose()
        {
            base.Dispose();
            GC.SuppressFinalize(this);
        }

        public override bool IsValid()
        {
            bool valid = true;

            if (this.Notifications!.Count > 0)
            {
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

            return valid;
        }

        public string? Email { get; set; }

        public string? Senha { get; set; }
    }
}