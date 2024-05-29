using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services;

public class LeaveTypeService(IMapper mapper, ApplicationDbContext context) : ILeaveTypeService
{
    private readonly IMapper _mapper = mapper;
    private readonly ApplicationDbContext _context = context;

    // get list of leaveTypes
    public async Task<IEnumerable<LeaveTypeReadOnlyVM>> GetAllAsync()
    {
        IEnumerable<LeaveType> leaveTypes = await _context.LeaveTypes
                                                          .AsNoTracking()
                                                          .ToListAsync();

        // mapt entity to viewModel
        return _mapper.Map<IEnumerable<LeaveTypeReadOnlyVM>>(leaveTypes);
    }

    // get list type by Id
    public async Task<T?> GetByIdAsync<T>(int id) where T : class
    {
        // await _context.LeaveTypes.FindAsync(id);
        LeaveType? leaveType = await _context.LeaveTypes.FirstOrDefaultAsync(lt => lt.Id == id);
        if (leaveType is null)
        {
            return null;
        }

        // map the entity to view model
        return _mapper.Map<T>(leaveType);
    }

    // create leave type
    public async Task CreateAsync(LeaveTypeCreateVM leaveTypeVM)
    {
        // convert the view model to entity
        LeaveType leaveType = _mapper.Map<LeaveType>(leaveTypeVM);

        // add the entity to the database
        await _context.AddAsync(leaveType);
        await _context.SaveChangesAsync();
    }

    public async Task EditAsync(LeaveTypeEditVM leaveTypeVM)
    {
        // convert the view model to entity
        LeaveType leaveType = _mapper.Map<LeaveType>(leaveTypeVM);

        // update and savechanges
        _context.Update(leaveType);
        await _context.SaveChangesAsync();
    }

    // edit leave type

    // delete leave type
    public async Task DeleteByIdAsync(int id)
    {
        // get the leave type
        LeaveType? leaveType = await _context.LeaveTypes.FindAsync(id);
        if (leaveType is null)
        {
            return;
        }
        _context.Remove(leaveType);
        await _context.SaveChangesAsync();
    }


    // bool if exists leave type

    // private methods goes here

    public async Task<bool> LeaveTypeExists(int id)
    {
        return await _context.LeaveTypes.AnyAsync(e => e.Id == id);
    }

    public async Task<bool> CheckLeaveTypeNameExists(string name)
    {
        return await _context.LeaveTypes
                       .AnyAsync(leaveType => leaveType.Name.ToLower()
                                                .Contains(name.ToLower()));
    }

    public async Task<bool> CheckLeaveTypeNameExistsForEdit(LeaveTypeEditVM leaveTypeEdit)
    {
        return await _context.LeaveTypes
                             .AnyAsync(lt => lt.Name.ToLower().Contains(leaveTypeEdit.Name.ToLower())
                                                        && lt.Id != leaveTypeEdit.Id);
    }

}
