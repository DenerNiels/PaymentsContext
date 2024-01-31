using PaymentsContext.Domain.Enums;
using PaymentsContext.Domain.ValueObjects;

namespace PaymentsContext.Tests.ValueObjects
{

    [TestClass]
    public class DocumentTest
    {
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);

        }
        [TestMethod]
        public void ShouldReturnSucessWhenCNPJIsValid()
        {
            var doc = new Document("19241293000127", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);

        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);

        }
        [TestMethod]
        public void ShouldReturnSucessWhenCPFIsValid()
        {
            var doc = new Document("55171065012", EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);

        }
    }
}
