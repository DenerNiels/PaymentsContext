using PaymentsContext.Domain.Entities;

namespace PaymentsContext.Tests.Repositories
{
    public interface IStudentRepository
    {
        bool DocumentExists(string document);
        bool EmailExists(string email);
        void CreateSubscription(Student student);
    }
}
