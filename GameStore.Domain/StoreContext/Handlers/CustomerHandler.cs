using System;
using FluentValidator;
using GameStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using GameStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using GameStore.Domain.StoreContext.Entities;
using GameStore.Domain.StoreContext.Respositories;
using GameStore.Domain.StoreContext.Services;
using GameStore.Domain.StoreContext.ValueObjects;
using GameStore.Shared.Commands;

namespace GameStore.Domain.StoreContext.Handlers
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
            //verificar se o cpf já está cadastrado
            if (_repository.CheckDocument(command.Document))
                AddNotification("Document", "Esse CPF já está cadastrado");

            //verificar se o e-mail já está cadastrado
            if (_repository.CheckEmail(command.Email))
                AddNotification("Email", "Esse E-mail já está cadastrado");

            //criar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            //criar entidades
            var customer = new Customer(name, document, email, command.Phone);

            //validar entidades e VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
                return null;

            //persistir o cliente
            _repository.Save(customer);

            //enviar um e-mail de boas vindas
            _emailService.Send(email.Address, "teste@gmail.com", "Bem-vindo", "Seja bem vindo a Game Store");

            //retornar o resultado para a tela
            return new CreateCustomerCommandResult(Guid.NewGuid(), name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}