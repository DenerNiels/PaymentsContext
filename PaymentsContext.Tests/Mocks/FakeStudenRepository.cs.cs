using PaymentsContext.Domain.Entities;
using PaymentsContext.Tests.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsContext.Tests.Mocks
{
    public class FakeStudenRepository : IStudentRepository
    {
        public void CreateSubscription(Student student)
        {
        }

        public bool DocumentExists(string document)
        {
            if (document == "12345678910")
                return true;

            return false;
        }

        public bool EmailExists(string email)
        {
            if (email == "rovinha@senai.com")
                return true;

            return false;
        }
    }
}
