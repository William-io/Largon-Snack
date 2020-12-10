using System;
using FluentValidator;
using Largon_Snack.Shared.Commands;

namespace Largon_Snack.Domain.StoreContext.Commands.CustomerCommands.Outputs
{

    public class CreateCustomerCommandResult : Notifiable, ICommandResult
    {
        public CreateCustomerCommandResult() { }//Sem parametro
        public CreateCustomerCommandResult(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

}
//Modifico o CreateCustomerCommand deixando apenas o Name,Id e Email