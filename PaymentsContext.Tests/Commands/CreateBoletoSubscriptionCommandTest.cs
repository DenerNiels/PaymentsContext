using PaymentsContext.Domain.Enums;
using PaymentsContext.Domain.ValueObjects;
using PaymentsContext.Domain.Enums;
using PaymentsContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentsContext.Domain.Commands;

namespace PaymentsContext.Tests.Commands
{
    [TestClass]
    public class CreateBoletoSubscriptionCommandTest
    {

        [TestMethod]
        public void ShouldReturnErrorWhenNameIsInvalid()
        {
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "";

            command.Validate();
            Assert.AreEqual(false, command.Valid);

        }
        

    }
}
