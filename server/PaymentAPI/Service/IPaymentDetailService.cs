using System.Collections.Generic;
using System.Threading.Tasks;
using PaymentAPI.Models;

namespace PaymentAPI.Service
{
    public interface IPaymentDetailService
    {
        public Task<IEnumerable<PaymentDetail>> GetAll();
    }
}