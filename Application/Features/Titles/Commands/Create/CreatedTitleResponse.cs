using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Titles.Commands.Create;

public record CreatedTitleResponse(Guid Id, string Name, DateTime CreatedDate);