using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace PaymentAPI.Models
{
    public class PaymentDetail
    {
        [Key]
        public int PaymentDetailId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [StringLength(50, MinimumLength = 2)]
        [Required]
        public string CardNumber { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        [Required]
        public string ExpirationDate { get; set; }

        [Column(TypeName = "nvarchar(3)")]
        [Required]
        public string CVVCode { get; set; }


        public static bool IsCreditCardCardNoValid(string cardNo)
        {
            var cardCheck = new Regex(@"^(1298|1267|4512|4567|8901|8933)([\-\s]?[0-9]{4}){3}$");
            if (!cardCheck.IsMatch(cardNo)) // <1>check card number is valid
                return false;
            return true;
        }
        public static bool IsCreditCardExpiryDateValid(string expiryDate)
        {
            var monthCheck = new Regex(@"^(0[1-9]|1[0-2])$");
            var yearCheck = new Regex(@"^[0-9]{2}$");

            var dateParts = expiryDate.Split('/'); //expiry date in from MM/yy            
            if (!monthCheck.IsMatch(dateParts[0]) || !yearCheck.IsMatch(dateParts[1])) // <3 - 6>
                return false; // ^ check date format is valid as "MM/yy"

            var year = 2000 + int.Parse(dateParts[1]);
            var month = int.Parse(dateParts[0]);
            var lastDateOfExpiryMonth = DateTime.DaysInMonth(year, month); //get actual expiry date
            var cardExpiry = new DateTime(year, month, lastDateOfExpiryMonth, 23, 59, 59);

            //check expiry greater than today & within next 6 years <7, 8>>
            return (cardExpiry > DateTime.Now && cardExpiry < DateTime.Now.AddYears(6));
        }


        public static bool IsCreditCardCVVInfoValid(string cvv)
        {
            var cvvCheck = new Regex(@"^\d{3}$");

            
            if (!cvvCheck.IsMatch(cvv)) // <2>check cvv is valid as "999"
                return false;
            return true;
        }
    }
}
