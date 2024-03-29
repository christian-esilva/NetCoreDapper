﻿using FluentValidator;
using FluentValidator.Validation;

namespace GameStore.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new ValidationContract()
                .Requires()
                .IsEmail(Address,"Email","O e-mail é inválido")
            );
        }

        public string Address { get; set; }

        public override string ToString()
        {
            return Address;
        }
    }
}
