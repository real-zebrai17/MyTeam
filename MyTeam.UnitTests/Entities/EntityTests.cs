using MyTeam.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTeam.UnitTests.Entities
{
    [TestFixture]
    public class EntityTests
    {
        [Test]
        public void AreNotTheSameWhenTwoEntitiesHaveDifferentIds()
        {
            var entityA = new Entity { Id = Guid.NewGuid() };
            var entityB = new Entity { Id = Guid.NewGuid() };

            Assert.False(entityA.SameAs(entityB));
        }

        [Test]
        public void AreTheSameWhenTwoEnitiesHaveSameIds()
        {
            var entityA = new Entity { Id = Guid.NewGuid() };
            var entityB = new Entity { Id = entityA.Id };

            Assert.True(entityA.SameAs(entityB));
        }

        [Test]
        public void AreNotTheSameWhenTheyAreBothNullIds()
        {
            var entityA = new Entity { Id = null };
            var entityB = new Entity { Id = null };

            Assert.False(entityA.SameAs(entityB));
        }


        [Test]
        public void AreNotTheSameOtherIsNull()
        {
            var entityA = new Entity { Id = Guid.NewGuid() };
            Entity entityB = null;

            Assert.False(entityA.SameAs(entityB));
        }
    }
}
