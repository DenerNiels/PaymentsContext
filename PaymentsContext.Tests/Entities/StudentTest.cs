using Flunt.Notifications;
using PaymentsContext.Domain.Entities;
using PaymentsContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Document = PaymentsContext.Domain.ValueObjects.Document;

namespace PaymentsContext.Tests.Entities
{
    [TestClass]
    public class StudentTest
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Adress _adress;
        private readonly Email _email;
        private readonly Student _student;
        private readonly Subscription _subscription;
        

        public StudentTest()
        {
            _name = new Name("Vito", "Rovaris");
            _document = new Document("475.880.170-31", Domain.Enums.EDocumentType.CPF);
            _email = new Email("gorinho@senai.com");
            _adress = new Adress("Morro do senai", "42", "1 de maio", "BQ", "SC", "BR", "Rovalandia");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
            
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Rovaland", _document, _adress, _email);

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);


            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSucessWhenHadSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSucessWhenHadAddSubscription()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Rovaland", _document, _adress, _email);

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Valid);
        }
    }
}

