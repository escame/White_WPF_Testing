using System;
using System.Collections.Generic;

using Northwind.Logic.Model;
using Northwind.UI.Common;


namespace Northwind.UI.Departments
{
    public class DepartmentViewModel : ViewModel
    {
        private readonly DepartmentRepository _repository;

        public IReadOnlyList<Employee> PossiblesHeads { get; private set; }
        public Department Department { get; private set; }
        public Command OkCommand { get; private set; }
        public Command CancelCommand { get; private set; }

        public string Name
        {
            get { return Department.Name; }
            set { Department.Name = value; }
        }

        public Employee Head
        {
            get { return Department.Head; }
            set { Department.Head = value; }
        }

        public override string Caption
        {
            get { return Department.IsTransient() ? "New department" : "Department: " + Department.Name; }
        }

        public override double Height
        {
            get { return 146; }
        }


        public DepartmentViewModel(Department department)
        {
            _repository = new DepartmentRepository();
            PossiblesHeads = new EmployeeRepository().GetPossiblesHeads(department.Head);
            Department = department;
            
            OkCommand = new Command(() => !string.IsNullOrWhiteSpace(Name), Save);
            CancelCommand = new Command(() => DialogResult = false);
        }


        private void Save()
        {
            _repository.Save(Department);
            DialogResult = true;
        }
    }
}
