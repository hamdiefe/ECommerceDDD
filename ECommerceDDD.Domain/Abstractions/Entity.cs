using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDDD.Domain.Abstractions
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Entity(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; init; }
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is not Entity entity)
            {
                return false;
            }
            if (obj.GetType() != GetType())
            {
                return false;
            }

            return entity.Id == Id;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }       
        public bool Equals(Entity? other)
        {
            if (other == null)
            {
                return false;
            }
            if (other is not Entity entity)
            {
                return false;
            }
            if (other.GetType() != GetType())
            {
                return false;
            }

            return entity.Id == Id;
        }
    }
}
