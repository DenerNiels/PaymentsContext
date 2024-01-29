using PaymentsContext.Shared.ValueObjects;

namespace PaymentsContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string adress)
        {
            Adress = adress;

            AddNotifications(new Flunt.Validations.Contract()
                .Requires()
                .IsEmail(Adress, "Email.Adress", "E-mail inválido"));
        }

        public string Adress { get; private set; }
    }
}
