using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Titles.Commands.Update;

public record UpdatedTitleResponse(Guid Id, string Name);