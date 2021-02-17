using MyTeam.Entities;
using System;
using System.Collections.Generic;

namespace MyTeam.TestUtilities.Gateways
{
    public class InMemoryGateway<T> where T : Entity
    {
        protected Dictionary<Guid, T>  Entities;
        public InMemoryGateway()
        {
            Entities = new Dictionary<Guid, T>();
        }

        public T Save(T entity)
        {
            var clone = EstablishId((T)entity.Clone());
            Entities[clone.Id.Value] = clone;
            return clone;
        }

        private T EstablishId(T entity)
        {
            if (!entity.Id.HasValue)
                entity.Id = Guid.NewGuid();
            return entity;
        }
    }
}