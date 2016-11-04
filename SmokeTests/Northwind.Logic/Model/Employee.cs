using System;
using System.Collections.Generic;
using System.Linq;

using Northwind.Logic.Common;


namespace Northwind.Logic.Model
{
    public class Employee : Entity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string About { get; set; }
        public virtual Department Department { get; set; }
        public virtual bool IsFullTimer { get; set; }
        
        protected virtual IList<ProjectInvolement> InvolementsInternal { get; set; }
        public virtual IReadOnlyList<ProjectInvolement> Involements
        {
            get { return InvolementsInternal.ToList(); }
        }

        public virtual IReadOnlyList<Project> Projects
        {
            get { return InvolementsInternal.Select(x => x.Project).ToList(); }
        }

        public virtual string Name
        {
            get { return FirstName + " " + LastName; }
        }

        public virtual Project MainProject
        {
            get
            {
                ProjectInvolement involement = InvolementsInternal.SingleOrDefault(x => x.IsMainForEmployee);
                
                if (involement == null)
                    return null;
                
                return involement.Project;
            }
        }


        public Employee()
        {
            IsFullTimer = true;
        }


        public virtual void DeleteProject(ProjectInvolement project)
        {
            if (!Involements.Contains(project))
                return;

            InvolementsInternal.Remove(project);
        }


        public virtual void AddProject(ProjectInvolement project)
        {
            if (Involements.Contains(project))
                return;

            InvolementsInternal.Add(project);
        }


        public virtual bool HasMainProject()
        {
            return MainProject != null;
        }
    }
}
