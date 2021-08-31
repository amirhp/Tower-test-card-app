using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Service;
using System.Threading.Tasks;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace PaymentAPI.Models
{
    public class PaymentDetailContext:DbContext , IContext
    {
        public PaymentDetailContext(DbContextOptions<PaymentDetailContext> options):base(options)
        {

        }

        public IDbSet<PaymentDetail> PaymentDetail { get; set; }

        public Task SaveAsyncChanges()
        {
            return base.SaveChangesAsync();
        }
    }
}
