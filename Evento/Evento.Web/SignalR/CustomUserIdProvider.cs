
using Microsoft.AspNetCore.SignalR;

namespace Evento.Web.SignalR
{

        public class CustomUserIdProvider : IUserIdProvider
        {
            public virtual string GetUserId(HubConnectionContext connection)
            {
                return connection.User?.Identity.Name;
               
            }
        }
    
}
