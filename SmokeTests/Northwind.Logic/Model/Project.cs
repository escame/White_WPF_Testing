using System;
using System.Collections.Generic;
using System.Linq;

using Northwind.Logic.Common;


namespace Northwind.Logic.Model
{
    public class Project : Entity
    {
        public virtual string Name { get; set; }
        public virtual ProjectStage Stage { get; set; }
        public virtual int Price { get; set; }

        protected virtual IList<ProjectInvolement> InvolementsInternal { get; set; }
        public virtual IReadOnlyList<ProjectInvolement> Involements
        {
            get { return InvolementsInternal.ToList(); }
        }


        public Project()
        {
            Stage = ProjectStage.Presale;
        }


        public virtual void Promote()
        {
            switch (Stage)
            {
                case ProjectStage.Presale:
                    Stage = ProjectStage.Development;
                    break;

                case ProjectStage.Development:
                    Stage = ProjectStage.Closed;
                    break;
            }
        }
    }
}
