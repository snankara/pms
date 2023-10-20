using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Titles.Queries.GetByName;

public record GetByNameTitleResponse(Guid Id, string Name);
