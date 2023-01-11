using Infrastructure.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Shared.Services
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
