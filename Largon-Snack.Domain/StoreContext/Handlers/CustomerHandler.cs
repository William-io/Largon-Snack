using FluentValidator;
using Largon_Snack.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Largon_Snack.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using Largon_Snack.Domain.StoreContext.Entities;
using Largon_Snack.Domain.StoreContext.Repositories;
using Largon_Snack.Domain.StoreContext.Services;
using Largon_Snack.Domain.StoreContext.ValueObjects;
using Largon_Snack.Shared.Commands;
using System;

namespace Largon_Snack.Domain.StoreContext.Handlers
{
    public class CustomerHandler : 
    Notifiable, 
    ICommandHandler<CreateCustomerCommand>,
    ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;

     
        public CustomerHandler(ICustomerRepository repository, IEmailService emailService) 
        {
            
            _repository = repository;
            _emailService = emailService;   
            
        }
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            //Verificar se o CPF já existe na base
            if(_repository.CheckDocument(command.Document))
            AddNotification("Document", "Este CPF já está em uso"); 

            //Verificar se o e-mail ja existe na base
            if(_repository.CheckEmail(command.Email))
            AddNotification("Email", "Este E-mail já está em uso");

            //Criar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            //Criar a entidade
            var customer = new Customer(name, document, email, command.Phone);

            //Validar entidades e VOs (Value Objects)
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if(Invalid)
            return null; //não vai ser Persistido no banco 

            //Persistir o cliente caso tenha dado certo
            _repository.Save(customer);


            //Enviar um e-mail de boas vindas
            _emailService.Send(email.Address, "Capuletos@live.com", "Bem-Vindo", "Seja bem vindo ao Largão Merenda!");
            //Retornar o resultado para tela

            return new CreateCustomerCommandResult(customer.Id, name.ToString(),email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}