using System.ComponentModel;

namespace LeaveManagementSystem.Web.Models.LeaveTypes;

public class LeaveTypeReadOnlyVM : BaseLeaveType
{
    public string Name { get; set; } = string.Empty;

    [DisplayName("Maximum Allocation of Days")]
    public int Days { get; set; }
}
