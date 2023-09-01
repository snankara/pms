using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Titles.Queries.GetById;

public class GetByIdTitleResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
