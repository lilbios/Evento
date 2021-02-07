﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Interfaces
{
    public interface ISubscriptionService<T> where T : class
    {
        public Task<IEnumerable<T>> GetSubscriptionsCurrentUser(string id);
        public Task Subscribe(T subscription);
        public Task Unsubscribe(int id);


    }
}
