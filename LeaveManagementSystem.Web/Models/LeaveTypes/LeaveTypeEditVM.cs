using System.ComponentModel;

namespace LeaveManagementSystem.Web.Models.LeaveTypes;

public class LeaveTypeEditVM : BaseLeaveType
{
    
    [Required]
    [Length(4, 150, ErrorMessage = "The length should be within 4 to 150 characters.")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(1, 90, ErrorMessage = "The days should be within 1 to 90 days.")]
    
    [DisplayName("Maximum Allocation of Days")]
    public int Days { get; set; }
}
