using System.Threading.Tasks;
using Moq;
using Xunit;
using PaymentAPI.Controllers;
using PaymentAPI.Models;
using PaymentAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace PaymentAPI.Test
{
    public class PaymentAPITest
    {
        [Fact]
        public async System.Threading.Tasks.Task Should_Return_Same_IdAsync()
        {
            // Arrange
            var mockRepository = new Mock<IPaymentDetailService>();
            mockRepository.Setup(x => x.GetById(42).Result)
                .Returns(new PaymentDetail { PaymentDetailId = 42 });

            var controller = new PaymentDetailController(mockRepository.Object);

            // Act
            var actionResult = await controller.GetPaymentDetail(42);
            var contentResult = GetObjectResultContent<PaymentDetail>(actionResult);


            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.NotNull(contentResult);
            Assert.Equal(42, contentResult.PaymentDetailId);
        }

        [Fact]
        public async Task PaymentDetail_Post_ReturnsBadRequestResult_WhenModelStateIsNull()
        {
            // Arrange
            var mockRepository = new Mock<IPaymentDetailService>();
            mockRepository.Setup(repo => repo.Add(It.IsAny<PaymentDetail>()))
                .Returns(Task.CompletedTask);
            var controller = new PaymentDetailController(mockRepository.Object);

            // Act
            var result = await controller.PostPaymentDetail(null);
            
            // Assert
            Assert.IsType<BadRequestResult>(result.Result);

        }

        [Fact]
        public async Task PaymentDetail_Post_ReturnsBadRequestResult_WhenCardNumberIsInvalid()
        {
            // Arrange
            var mockRepository = new Mock<IPaymentDetailService>();
            mockRepository.Setup(repo => repo.Add(It.IsAny<PaymentDetail>()))
                .Returns(Task.CompletedTask);
            var controller = new PaymentDetailController(mockRepository.Object);

            // Act
            var result = await controller.PostPaymentDetail(new PaymentDetail()
            {
                CardNumber = "ddd",
                CVVCode = "999",
                ExpirationDate = "12/21"
            });

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
            var modelState = controller.ModelState;

            Assert.Single(modelState.Keys);
            Assert.Equal("Card Number is not valid!", modelState["CardNumber"].Errors[0].ErrorMessage);

        }

        [Fact]
        public async Task PaymentDetail_Post_ReturnsBadRequestResult_WhenCVVIsInvalid()
        {
            // Arrange
            var mockRepository = new Mock<IPaymentDetailService>();
            mockRepository.Setup(repo => repo.Add(It.IsAny<PaymentDetail>()))
                .Returns(Task.CompletedTask);
            var controller = new PaymentDetailController(mockRepository.Object);

            // Act
            var result = await controller.PostPaymentDetail(new PaymentDetail()
            {
                CardNumber = "1298002078700521",
                CVVCode = "0",
                ExpirationDate = "12/21"
            });

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
            var modelState = controller.ModelState;

            Assert.Single(modelState.Keys);
            Assert.Equal("CVV is not valid!", modelState["CVV"].Errors[0].ErrorMessage);

        }

        [Fact]
        public async Task PaymentDetail_Post_ReturnsBadRequestResult_WhenExpiryDateIsInvalid()
        {
            // Arrange
            var mockRepository = new Mock<IPaymentDetailService>();
            mockRepository.Setup(repo => repo.Add(It.IsAny<PaymentDetail>()))
                .Returns(Task.CompletedTask);
            var controller = new PaymentDetailController(mockRepository.Object);

            // Act
            var result = await controller.PostPaymentDetail(new PaymentDetail()
            {
                CardNumber = "1298002078700521",
                CVVCode = "111",
                ExpirationDate = "22/21"
            });

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
            var modelState = controller.ModelState;

            Assert.Single(modelState.Keys);
            Assert.Equal("Expiry Date is not valid!", modelState["ExpirationDate"].Errors[0].ErrorMessage);

        }

        private static T GetObjectResultContent<T>(ActionResult<T> result)
        {
            return (T)((ObjectResult)result.Result).Value;
        }
    }
}
