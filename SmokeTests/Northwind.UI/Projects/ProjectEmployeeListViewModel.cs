using System;
using System.Collections.Generic;

using Northwind.Logic.Model;
using Northwind.UI.Common;


namespace Northwind.UI.Projects
{
    public class ProjectEmployeeListViewModel : ViewModel
    {
        private readonly Project _project;

        public IReadOnlyList<ProjectInvolement> Employees
        {
            get { return _project.Involements; }
        }

        public override string Caption
        {
            get { return "Employees"; }
        }


        public ProjectEmployeeListViewModel(Project project)
        {
            _project = project;
        }
    }
}
