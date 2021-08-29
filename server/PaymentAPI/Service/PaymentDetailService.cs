using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;

namespace PaymentAPI.Service
{
   
    public class PaymentDetailService : IPaymentDetailService
    {
        private IContext _context;

        public PaymentDetailService(IContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PaymentDetail>> GetAll()
        {
            return  _context.PaymentDetail.AsEnumerable();
        }

        public async Task<PaymentDetail> GetById(int id)
        {
            return await _context.PaymentDetail.Where(x => x.PaymentDetailId.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task Add(PaymentDetail paymentDetail)
        {
            _context.PaymentDetail.Add(paymentDetail); 
            await _context.SaveAsyncChanges();
        }

    }

}
