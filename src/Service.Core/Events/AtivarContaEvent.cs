using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Events
{
    public class AtivarContaEvent
    {
        public AtivarContaEvent(string emailNotificacao, string linkAtivacao)
        {
            EmailNotificacao = emailNotificacao;
            LinkAtivacao = linkAtivacao;
        }

        public string? EmailNotificacao { get; set; }

        public string? LinkAtivacao { get; set; }
    }
}
