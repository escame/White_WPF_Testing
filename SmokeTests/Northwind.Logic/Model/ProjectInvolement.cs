using System;

using Northwind.Logic.Common;


namespace Northwind.Logic.Model
{
    public class ProjectInvolement : Entity
    {
        public virtual Project Project { get; protected set; }
        public virtual Employee Employee { get; protected set; }
        public virtual Role Role { get; protected set; }
        public virtual bool IsMainForEmployee { get; protected set; }


        protected ProjectInvolement()
        {
        }


        public ProjectInvolement(Project project, Employee employee, Role role, bool isMainForEmployee)
            : this()
        {
            Project = project;
            Employee = employee;
            Role = role;
            IsMainForEmployee = isMainForEmployee;
        }
    }
}
