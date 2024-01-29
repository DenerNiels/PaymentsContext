﻿using PaymentsContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsContext.Domain.Entities
{
    public abstract class Payment
    {
        protected Payment( 
            DateTime paidDate, 
            DateTime expireDate, 
            decimal total,
            decimal totalPaid,
            string payer, 
            Document document,
            Adress adress,
            Email email)
        {
            Number = Guid.NewGuid().ToString().Replace("-","").Substring(0,10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Payer = payer;
            Document = document;
            Adress = adress;
            Email = email;
        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total {  get; private set; }
        public decimal TotalPaid { get; private set; }
        public string Payer { get; private set; }
        public Document Document { get; private set; }
        public Adress Adress { get; private set; }
        public Email Email { get; private set; }
    }
}