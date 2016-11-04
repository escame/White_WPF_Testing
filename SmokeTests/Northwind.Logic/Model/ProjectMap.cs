using System;

using FluentNHibernate;

using Northwind.Logic.Common;


namespace Northwind.Logic.Model
{
    public class ProjectMap : EntityMap<Project>
    {
        public ProjectMap()
        {
            Map(x => x.Name);
            Map(x => x.Stage).CustomType<int>();
            Map(x => x.Price);

            HasMany<ProjectInvolement>(Reveal.Member<Project>("InvolementsInternal"))
                .Not.LazyLoad()
                .Inverse()
                .Cascade.None();
        }
    }
}
