using Evento.Models.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.BLL.ServiceInterfaces
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
