
namespace LeaveManagementSystem.Web.Services;

public interface ILeaveTypeService
{
    Task CreateAsync(LeaveTypeCreateVM leaveTypeVM);
    Task DeleteByIdAsync(int id);
    Task EditAsync(LeaveTypeEditVM leaveTypeVM);
    Task<IEnumerable<LeaveTypeReadOnlyVM>> GetAllAsync();
    Task<T?> GetByIdAsync<T>(int id) where T : class;
}