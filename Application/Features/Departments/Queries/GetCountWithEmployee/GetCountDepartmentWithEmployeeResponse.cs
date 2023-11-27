using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments.Queries.GetCountWithEmployee;

public record GetCountDepartmentWithEmployeeResponse(
    int ActiveCount, 
    int DeletedCount, 
    int TotalCount, 
    int TotalEmployeeCount
);
