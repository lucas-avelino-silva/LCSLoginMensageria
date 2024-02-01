using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.EmailService
{
    public interface IEmailSettings
    {
        string? PrimaryDomain { get; set; }

        int PrimaryPort { get; set; }

        string? UsernameEmail { get; set; }

        string? UsernamePassword { get; set; }

        string? FromEmail { get; set; }

        string? ToEmail { get; set; }

        string? CcEmail { get; set; }
    }
}
