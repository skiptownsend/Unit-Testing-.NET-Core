using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class CustomerXUnitTests
    {
        private Customer customer;
        public CustomerXUnitTests()
        {
            customer = new();
        }

        [Fact]
        public void GreetAndCombineNames_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange
            //Customer customer = new ();

            //Act
            customer.GreetAndCombineNames("Ben", "Spark");

            //Assert
            Assert.Equal("Hello, Ben Spark", customer.GreetMessage);
            Assert.Contains("ben Spark".ToLower(), customer.GreetMessage.ToLower());
            Assert.StartsWith("Hello,", customer.GreetMessage);
            Assert.EndsWith("Spark",customer.GreetMessage);
            Assert.Matches("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", customer.GreetMessage);
        }

        [Fact]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            //Arrange
            //Customer customer = new();

            //Act

            //Assert
            Assert.Null(customer.GreetMessage);
        }

        [Fact]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            int result = customer.Discount;

            Assert.InRange(result, 10, 25); //Test to confirm that the discount is only ever between 10 and 25 percent
        }

        [Fact]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            customer.GreetAndCombineNames("ben", "");

            Assert.NotNull(customer.GreetMessage);
            Assert.False(string.IsNullOrEmpty(customer.GreetMessage));
        }

        [Fact]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Spark"));
            Assert.Equal("Empty First Name", exceptionDetails.Message);

            //Next two lines not available in Xunit
            //Assert.That(() => customer.GreetAndCombineNames("", "spark"),
            //    Throws.ArgumentException.With.Message.EqualTo("Empty First Name"));

            //Test whether exception is thrown without worrying about what the exception string is
            Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Spark"));
            
            //Next two lines not available in Xunit
            //Assert.That(() => customer.GreetAndCombineNames("", "spark"),
            //    Throws.ArgumentException);
        }

        [Fact]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.IsType<BasicCustomer>(result);
        }

        [Fact]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnPlatinumCustomer()
        {
            customer.OrderTotal = 200;
            var result = customer.GetCustomerDetails();
            Assert.IsType<PlatinumCustomer>(result);
        }
    }
}
