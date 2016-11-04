using System;
using System.Collections.Generic;
using System.Linq;

using Northwind.Logic.Common;
using Northwind.Logic.Utils;


namespace Northwind.Logic.Model
{
    public class EmployeeRepository : Repository<Employee>
    {
        public EmployeeDto GetEmployeeDto(long id)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                Employee employee = unitOfWork
                    .Query<Employee>()
                    .Single(x => x.Id == id);

                return new EmployeeDto(employee);
            }
        }


        public IReadOnlyList<EmployeeDto> GetEmployeeDtoList()
        {
            return GetEmployeeList()
                .Select(x => new EmployeeDto(x))
                .ToList();
        }


        public IReadOnlyList<Employee> GetEmployeeList()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                return unitOfWork.Query<Employee>()
                    .ToList();
            }
        }


        public IReadOnlyList<Employee> GetPossiblesHeads(Employee currentHead)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                IList<Employee> employees = unitOfWork.Query<Employee>()
                    .ToList()
                    .Where(x => !x.Projects.Any())
                    .ToList();

                List<Employee> heads = unitOfWork.Query<Department>()
                    .ToList()
                    .Where(x => x.Head != null)
                    .Select(x => x.Head)
                    .ToList();

                List<Employee> result = employees.Except(heads).ToList();
                if (currentHead != null)
                {
                    result.Add(currentHead);
                }

                return result;
            }
        }


        public bool IsEmployeeHeadOfDepartment(Employee employee)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                return unitOfWork.Query<Department>()
                    .Any(x => x.Head != null && x.Head == employee);
            }
        }
    }
}
