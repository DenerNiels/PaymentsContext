﻿using PaymentsContext.Domain.ValueObjects;

namespace PaymentsContext.Domain.Entities
{

    public class BoletoPayment : Payment
    {
        public BoletoPayment(
            string barCode, 
            string boletoNumber, 
            DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            string payer,
            Document document,
            Adress adress,
            Email email) : base(
                paidDate,
                expireDate,
                total, 
                totalPaid, 
                payer, 
                document, 
                adress, 
                email)
        {
            BarCode = barCode;
            BoletoNumber = boletoNumber;
        }

        public string BarCode { get; private set; }
        public string BoletoNumber { get; private set; }
    }

}
