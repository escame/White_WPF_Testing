using System;
using System.Collections.ObjectModel;

using Northwind.Logic.Model;
using Northwind.UI.Common;


namespace Northwind.UI.Departments
{
    public class DepartmentListViewModel : ViewModel
    {
        private readonly DepartmentRepository _repository;
        public Command AddDepartmentCommand { get; private set; }
        public Command<DepartmentDto> EditDepartmentCommand { get; private set; }
        public Command<DepartmentDto> DeleteDepartmentCommand { get; private set; }
        public ObservableCollection<DepartmentDto> Departments { get; private set; }

        public override string Caption
        {
            get { return "Departments"; }
        }


        public DepartmentListViewModel()
        {
            _repository = new DepartmentRepository();
            RefreshAll();

            AddDepartmentCommand = new Command(AddDepartment);
            EditDepartmentCommand = new Command<DepartmentDto>(x => x != null, EditDepartment);
            DeleteDepartmentCommand = new Command<DepartmentDto>(x => x != null, DeleteDepartment);
        }


        public override void RefreshAll()
        {
            Departments = new ObservableCollection<DepartmentDto>(_repository.GetDepartmentDtoList());
        }


        private void AddDepartment()
        {
            var viewModel = new DepartmentViewModel(new Department());

            if (_dialogService.ShowDialog(viewModel) == true)
            {
                Departments.Add(_repository.GetDepartmentDto(viewModel.Department.Id));
            }
        }


        private void EditDepartment(DepartmentDto departmentDto)
        {
            Department department = _repository.GetById(departmentDto.Id);
            var viewModel = new DepartmentViewModel(department);

            if (_dialogService.ShowDialog(viewModel) == true)
            {
                int index = Departments.IndexOf(departmentDto);
                Departments[index] = _repository.GetDepartmentDto(viewModel.Department.Id);
            }
        }


        private void DeleteDepartment(DepartmentDto departmentDto)
        {
            _repository.Delete(departmentDto.Id);
            Departments.Remove(departmentDto);
        }
    }
}
