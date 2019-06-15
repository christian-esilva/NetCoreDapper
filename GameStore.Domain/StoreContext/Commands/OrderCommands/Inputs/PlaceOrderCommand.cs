using System;
using System.Collections.Generic;
using FluentValidator;
using FluentValidator.Validation;
using GameStore.Shared.Commands;

namespace GameStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {
        public PlaceOrderCommand()
        {
            OrdemItems = new List<OrderItemCommand>();
        }

        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrdemItems { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .HasLen(Customer.ToString(), 36, "Customer", "Id do cliente inválido")
                .IsGreaterThan(OrdemItems.Count, 0, "Items", "Nenhum item no pedido")
            );
            return IsValid;
        }
    }

    public class OrderItemCommand
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}