﻿using Flunt.Validations;
using PaymentsContext.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsContext.Domain.ValueObjects
{
    public class Adress : ValueObject
    {
        public Adress(string street, string number, string neighborhood, string city, string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Street, 3, "Adress.Street", "O nome da rua deve conter pelo menos 3 caracteres")
                );
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }


    }
}
