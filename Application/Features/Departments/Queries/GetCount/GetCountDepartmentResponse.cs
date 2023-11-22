using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments.Queries.GetCount;

public record GetCountDepartmentResponse(int ActiveCount, int DeletedCount, int TotalCount);
