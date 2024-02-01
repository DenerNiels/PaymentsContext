using PaymentsContext.Domain.Commands;
using PaymentsContext.Domain.Entities;
using PaymentsContext.Domain.Enums;
using PaymentsContext.Domain.Handlers;
using PaymentsContext.Domain.Queries;
using PaymentsContext.Domain.ValueObjects;
using PaymentsContext.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsContext.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTest
    {
        private IList<Student> _students;
        public StudentQueriesTest()
        {
            for (int i = 0; i < 10; i++)
            {
                _students.Add(
                    new Student(new Name("Iargo", i.ToString()),
                    new Document("12343212354" + i.ToString(), EDocumentType.CPF),
                    new Email(i.ToString() + "@rovaladia.com")
                    ));
            }
        }
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentNotExists()
        {
            var exp = StudentQueries.GetStudent("12343212123354");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, studn);

        }
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var exp = StudentQueries.GetStudent("12343212354");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, studn);
        }
    }
}
