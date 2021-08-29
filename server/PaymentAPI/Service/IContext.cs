using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PaymentAPI.Models;

namespace PaymentAPI.Service
{
    public interface IContext
    {
        IDbSet<PaymentDetail> PaymentDetail { get; set; }
        Task SaveAsyncChanges();
    }

}
