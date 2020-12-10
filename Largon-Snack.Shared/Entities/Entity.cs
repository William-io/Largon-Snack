using FluentValidator;
using System;

namespace Largon_Snack.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }   
        public Guid Id { get; private set; }

    }

}