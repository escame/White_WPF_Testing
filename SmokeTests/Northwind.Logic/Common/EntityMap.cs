using System;

using FluentNHibernate.Mapping;


namespace Northwind.Logic.Common
{
    public class EntityMap<T> : ClassMap<T>
        where T : Entity
    {
        public EntityMap()
        {
            Id(x => x.Id);
        }
    }
}