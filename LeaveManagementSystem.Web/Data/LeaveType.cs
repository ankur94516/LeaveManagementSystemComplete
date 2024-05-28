

namespace LeaveManagementSystem.Web.Data;

public class LeaveType
{
    public int Id { get; set; }

    [MaxLength(50, ErrorMessage = "Length out of bound")]
    public string Name { get; set; }
    public int NumberOfDays { get; set; }
}
