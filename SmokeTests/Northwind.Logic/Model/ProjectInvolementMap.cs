using System;

using Northwind.Logic.Common;


namespace Northwind.Logic.Model
{
    public class ProjectInvolementMap : EntityMap<ProjectInvolement>
    {
        public ProjectInvolementMap()
        {
            Map(x => x.Role).CustomType<int>();
            Map(x => x.IsMainForEmployee);

            References(x => x.Employee).Not.LazyLoad();
            References(x => x.Project).Not.LazyLoad();
        }
    }
}
