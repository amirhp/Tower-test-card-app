using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Models;
using PaymentAPI.Service;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PaymentDetailController : ControllerBase
    {
        private readonly IPaymentDetailService _paymentService;

        public PaymentDetailController(IPaymentDetailService paymentService)
        {
            _paymentService = paymentService;
        }

        // GET: api/PaymentDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetail>>> GetPaymentDetails()
        {
            var paymentDetails = await _paymentService.GetAll();
            return Ok(paymentDetails);
        }

        // GET: api/PaymentDetail/1
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetail>> GetPaymentDetail(int id)
        {
            var paymentDetail = await _paymentService.GetById(id);

            if (paymentDetail == null)
            {
                return NotFound();
            }

            return Ok(paymentDetail);
        }


        // POST: api/PaymentDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentDetail>> PostPaymentDetail(PaymentDetail paymentDetail)
        {
            if (paymentDetail == null)
            {
                return BadRequest();
            }
            if (!PaymentDetail.IsCreditCardCardNoValid(paymentDetail.CardNumber))
            {
                ModelState.AddModelError("CardNumber","Card Number is not valid!");
            }
            if (!PaymentDetail.IsCreditCardExpiryDateValid(paymentDetail.ExpirationDate))
            {
                ModelState.AddModelError("ExpirationDate", "Expiry Date is not valid!");
            }
            if (!PaymentDetail.IsCreditCardCVVInfoValid(paymentDetail.CVVCode))
            {
                ModelState.AddModelError("CVV", "CVV is not valid!");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _paymentService.Add(paymentDetail);
            return CreatedAtAction("GetPaymentDetail", new {id = paymentDetail.PaymentDetailId}, paymentDetail);
        }



    }
}
