using System;
using System.Collections.Generic;

using Northwind.Logic.Model;
using Northwind.UI.Common;


namespace Northwind.UI.Employees
{
    public class EmployeeProjectListViewModel : ViewModel
    {
        private EmployeeRepository _repository;
        private readonly Employee _employee;

        public Command AddProjectCommand { get; private set; }
        public Command<ProjectInvolement> DeleteProjectCommand { get; private set; }

        public IReadOnlyList<ProjectInvolement> Projects
        {
            get { return _employee.Involements; }
        }

        public override string Caption
        {
            get { return "Projects"; }
        }


        public EmployeeProjectListViewModel(Employee employee)
        {
            _repository = new EmployeeRepository();
            _employee = employee;

            AddProjectCommand = new Command(AddProject);
            DeleteProjectCommand = new Command<ProjectInvolement>(x => x != null, DeleteProject);
        }


        private void AddProject()
        {
            if (_repository.IsEmployeeHeadOfDepartment(_employee))
            {
                CustomMessageBox.ShowError("The employee is a Head of Department. A Head of Department can't have projects assigned.");
                return;
            }

            var viewModel = new NewEmployeeProjectViewModel(_employee);

            if (_dialogService.ShowDialog(viewModel) == true)
            {
                _employee.AddProject(viewModel.ProjectInvolement);

                Notify(() => Projects);
            }
        }


        private void DeleteProject(ProjectInvolement project)
        {
            _employee.DeleteProject(project);

            Notify(() => Projects);
        }
    }
}
