
namespace LeaveManagementSystem.Web.Services;

public interface ILeaveTypeService
{
    Task<bool> CheckLeaveTypeNameExists(string name);
    Task<bool> CheckLeaveTypeNameExistsForEdit(LeaveTypeEditVM leaveTypeEdit);
    Task CreateAsync(LeaveTypeCreateVM leaveTypeVM);
    Task DeleteByIdAsync(int id);
    Task EditAsync(LeaveTypeEditVM leaveTypeVM);
    Task<IEnumerable<LeaveTypeReadOnlyVM>> GetAllAsync();
    Task<T?> GetByIdAsync<T>(int id) where T : class;
    Task<bool> LeaveTypeExists(int id);
}