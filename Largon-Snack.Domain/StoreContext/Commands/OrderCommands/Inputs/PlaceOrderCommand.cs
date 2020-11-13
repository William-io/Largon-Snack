using FluentValidator;
using FluentValidator.Validation;
using Largon_Snack.Shared.Commands;
using System;
using System.Collections.Generic;


namespace Largon_Snack.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {

        public PlaceOrderCommand()
        {
            OrderItems = new List<OrderItemCommand>();
        }

        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()               
                .HasLen(Customer.ToString(), 36, "Customer", "Identificador do Cliente invalido")
                .IsGreaterThan(OrderItems.Count, 0, "Items", "Nenhum item do pedido foi encontrado")
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
