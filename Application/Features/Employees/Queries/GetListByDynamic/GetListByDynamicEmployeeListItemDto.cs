namespace Application.Features.Employees.Queries.GetListByDynamic;

public class GetListByDynamicEmployeeListItemDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TitleName { get; set; }
    public string DepartmentName { get; set; }

}
