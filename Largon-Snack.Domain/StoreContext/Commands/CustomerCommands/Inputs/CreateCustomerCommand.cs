using FluentValidator;
using FluentValidator.Validation;
using Largon_Snack.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Largon_Snack.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        //FailFastValidation
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 40, "FirstName", "O nome deve conter no maximo 40 caracteres")
                .HasMinLen(LastName, 3, "LastName", "O sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(LastName, 40, "FirstName", "O sobrenome deve conter no maximo 40 caracteres")
                .IsEmail(Email, "Email", "O E-mail e invalido")
                .HasLen(Document, 11, "Document", "CPF invalido")
           );
            return IsValid;
        }

    }
}
