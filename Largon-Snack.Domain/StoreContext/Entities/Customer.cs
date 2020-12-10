﻿using FluentValidator;
using Largon_Snack.Domain.StoreContext.ValueObjects;
using Largon_Snack.Shared.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Largon_Snack.Domain.StoreContext.Entities
{
    public class Customer : Entity
    {
        private readonly IList<Address> _addresses;
        public Customer(
            Name name,
            Document document,
            Email email,
            string phone)
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            _addresses = new List<Address>();
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Address => _addresses.ToArray();

        //Adicionar endereço 
        public void AddAddress(Address address)
        {
            _addresses.Add(address); 
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
