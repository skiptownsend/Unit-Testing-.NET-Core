using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class CustomerNUnitTests
    {
        [Test]
        public void GreetAndCombineNames_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange
            Customer customer = new();
            
            //Act
            string fullName = customer.GreetAndCombineNames("Ben", "Spark");

            //Assert
            Assert.That(fullName, Is.EqualTo("Hello, Ben Spark"));
        }
    }
}
