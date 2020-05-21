using Evento.Models.Message;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.ServiceInterfaces
{
    public interface IEmailSender
    {
        Task SendEmail(Message message);
    }
}
