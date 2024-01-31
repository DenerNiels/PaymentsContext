using Flunt.Notifications;
using Flunt.Validations;
using PaymentsContext.Domain.Commands;
using PaymentsContext.Domain.Entities;
using PaymentsContext.Domain.Enums;
using PaymentsContext.Domain.Services;
using PaymentsContext.Domain.ValueObjects;
using PaymentsContext.Shared.Commands;
using PaymentsContext.Shared.Handlers;
using PaymentsContext.Tests.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable, IHandler<CreateBoletoSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _emailService;
        public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }
        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            //Fail fast validation
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possivel realizar sua assinatura");
            };

            //Verificar se o documento ja é cadastrado
            if (_repository.DocumentExists(command.Number));
            AddNotification("Document", "Este CPF ja esta em uso");

            //Verifica se o email ja é cadastrado
            if (_repository.EmailExists(command.Email)) ;
            AddNotification("Email", "Este email ja esta em uso");
            
            //Gerar VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Number, EDocumentType.CPF);
            var email = new Email(command.Email);
            var adress = new Adress(command.Street,
                command.Number,
                command.Neighborhood,
                command.City, command.State,
                command.Country,
                command.ZipCode);

            //Gerar entidades
            var _student = new Student(name, document, email);
            var _subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(command.BarCode,
                command.BoletoNumber, command.PaidDate,
                command.ExpireDate,
                command.Total,
                command.TotalPaid, 
                command.Payer, 
                new Document(command.PayerDocument, command.PayerDocumentType),
                adress, 
                email);

            //Relacionamentos
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);

            //Agrupar as validaçoes
            AddNotifications(name, document, email, adress, _student, _subscription, payment);

            //salvar informacoes
            _repository.CreateSubscription(_student);

            //enviar email de boas vindas
            _emailService.Send(_student.Name.ToString(), _student.Email.Adress, "Bem vindo a Rovalandia", "Sua assinatura foi criada");

            //Retornar informaçoes
            return new CommandResult(true, "assinatura realizada com sucesso");

        }
    }
}
