using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Titles.Commands.Create;

public class CreatedTitleResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
