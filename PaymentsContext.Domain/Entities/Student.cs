using PaymentsContext.Domain.ValueObjects;
using PaymentsContext.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;
        public Student(Name name, Document document, Email email)
        {
            Name= name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
            
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Adress Adress { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions => _subscriptions.ToArray(); 
        public void AddSubscription (Subscription subscription)
        {
            foreach (var sub in Subscriptions)
                sub.Inactivate();
            
            _subscriptions.Add(subscription);
        }

    }
}
