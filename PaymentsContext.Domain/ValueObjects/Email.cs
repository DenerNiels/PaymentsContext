using Flunt.Validations;
using PaymentsContext.Shared.ValueObjects;

namespace PaymentsContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string adress)
        {
            Adress = adress;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Adress, "Email.Address", "E-mail inválido")
            );
        }

        public string Adress { get; private set; }
    }
}

