using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.Create;

public record CreatedUserResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    bool Status
    );
