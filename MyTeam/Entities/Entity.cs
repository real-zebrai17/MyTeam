using System;

namespace MyTeam.Entities
{
    public class Entity : ICloneable
    {
        public Guid? Id { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public bool SameAs(Entity entityB)
        {
            return Id.HasValue && Id == entityB?.Id;
        }
    }
}