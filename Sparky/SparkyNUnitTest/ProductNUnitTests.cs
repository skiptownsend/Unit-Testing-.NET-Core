using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class ProductNUnitTests
    {
        [Test]
        public void GetProductPrice_PlatinumCustomer_ReturnPricewith20Discount()
        {
            Product product = new Product() { Price = 50 };

            var result = product.GetPrice(new Customer() { IsPlatinum = true }); //No interface for Customer object, so no need to use Moq

            Assert.That(result, Is.EqualTo(50 * 0.8));
        }
    }
}
