using System;
using System.Collections.ObjectModel;

using Northwind.Logic.Model;
using Northwind.UI.Common;


namespace Northwind.UI.Employees
{
    public class EmployeeListViewModel : ViewModel
    {
        private readonly EmployeeRepository _repository;
        public Command AddEmployeeCommand { get; private set; }
        public Command<EmployeeDto> EditEmployeeCommand { get; private set; }
        public Command<EmployeeDto> DeleteEmployeeCommand { get; private set; }
        public ObservableCollection<EmployeeDto> Employees { get; private set; }

        public override string Caption
        {
            get { return "Employees"; }
        }


        public EmployeeListViewModel()
        {
            _repository = new EmployeeRepository();
            RefreshAll();

            AddEmployeeCommand = new Command(AddEmployee);
            EditEmployeeCommand = new Command<EmployeeDto>(x => x != null, EditEmployee);
            DeleteEmployeeCommand = new Command<EmployeeDto>(x => x != null, DeleteEmployee);
        }


        public override void RefreshAll()
        {
            Employees = new ObservableCollection<EmployeeDto>(_repository.GetEmployeeDtoList());
        }


        private void AddEmployee()
        {
            var viewModel = new NewEmployeeViewModel();

            if (_dialogService.ShowDialog(viewModel) == true)
            {
                EmployeeDto employeeDto = _repository.GetEmployeeDto(viewModel.Employee.Id);
                Employees.Add(employeeDto);

                EditEmployee(employeeDto);
            }
        }


        private void EditEmployee(EmployeeDto employeeDto)
        {
            Employee employee = _repository.GetById(employeeDto.Id);
            var viewModel = new ExistingEmployeeViewModel(employee);

            if (_dialogService.ShowDialog(viewModel) == true)
            {
                int index = Employees.IndexOf(employeeDto);
                Employees[index] = _repository.GetEmployeeDto(viewModel.Employee.Id);
            }
        }


        private void DeleteEmployee(EmployeeDto employeeDto)
        {
            _repository.Delete(employeeDto.Id);
            Employees.Remove(employeeDto);
        }
    }
}
