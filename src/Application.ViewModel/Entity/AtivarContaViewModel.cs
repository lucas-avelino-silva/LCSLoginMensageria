using Application.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Entity
{
    public class AtivarContaViewModel : ViewModelTableCore
    {
        ~AtivarContaViewModel() => Dispose();

        public override void Dispose()
        {
            base.Dispose();
            GC.SuppressFinalize(this);
        }

        public AtivarContaViewModel( Guid idLogin, Guid codigo)
        {
            IdLogin = idLogin;
            Codigo = codigo;
            DataCriacao = DateTime.Now;
            DataExpiracao = DataCriacao.AddDays(1);
        }

        public override bool IsValid()
        {
            bool valid = true;

            if(IdLogin == Guid.Empty)
            {
                AddNotifications($"Campo \"IdLogin\" inválido.");

                valid = false;
            }

            if (Codigo == Guid.Empty)
            {
                AddNotifications($"Campo \"Codigo\" inválido.");

                valid = false;
            }

            if (DataCriacao.Date == new DateTime().Date)
            {
                AddNotifications($"Campo \"DataCriacao\" inválido.");

                valid = false;
            }

            if (DataExpiracao.Date == new DateTime().Date)
            {
                AddNotifications($"Campo \"DataExpiracao\" inválido.");

                valid = false;
            }

            return valid;
        }

        public Guid IdLogin { get; set; }

        public Guid Codigo { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataExpiracao { get; set; }
    }
}
