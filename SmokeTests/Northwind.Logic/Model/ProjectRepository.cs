using System;
using System.Collections.Generic;
using System.Linq;

using Northwind.Logic.Common;
using Northwind.Logic.Utils;


namespace Northwind.Logic.Model
{
    public class ProjectRepository : Repository<Project>
    {
        public ProjectDto GetProjectDto(long id)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                Project project = unitOfWork
                    .Query<Project>()
                    .Single(x => x.Id == id);

                return new ProjectDto(project);
            }
        }


        public IReadOnlyList<ProjectDto> GetProjectDtoList()
        {
            return GetProjectList()
                .Select(x => new ProjectDto(x))
                .ToList();
        }


        public IReadOnlyList<Project> GetProjectList()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                return unitOfWork.Query<Project>()
                    .ToList();
            }
        }
    }
}
