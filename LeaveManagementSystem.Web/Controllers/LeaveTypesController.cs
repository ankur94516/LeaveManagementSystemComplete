using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Controllers;

public class LeaveTypesController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public LeaveTypesController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: LeaveTypes
    public async Task<ViewResult> Index()
    {
        IEnumerable<LeaveType> leaveTypes = await _context.LeaveTypes
                                                          .AsNoTracking()
                                                          .ToListAsync();

        // populate the view model and pass the view model to the view

        // code written for practice purpose only
        IEnumerable<LeaveTypeReadOnlyVM> indexVM_practice = from lt in leaveTypes
                                                            select new LeaveTypeReadOnlyVM
                                                            {
                                                                Id = lt.Id,
                                                                Name = lt.Name,
                                                                Days = lt.NumberOfDays,
                                                            };

        indexVM_practice = leaveTypes.Select(leaveType => new LeaveTypeReadOnlyVM
        {
            Id = leaveType.Id,
            Name = leaveType.Name,
            Days = leaveType.NumberOfDays,
        });

        // conversion via IMapper
        // IMapper.Map<DestinationType>(sourceDataObj);
        IEnumerable<LeaveTypeReadOnlyVM> indexVM = _mapper.Map<IEnumerable<LeaveTypeReadOnlyVM>>(leaveTypes);

        return View(indexVM);
    }

    // GET: LeaveTypes/Details/5
    [HttpGet]
    public async Task<ActionResult<LeaveType>> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        LeaveType? leaveType = await _context.LeaveTypes
                                             .AsNoTracking()
                                             .FirstOrDefaultAsync(leaveType => leaveType.Id == id);
        if (leaveType == null)
        {
            return NotFound();
        }

        // convert leaveType to View Model
        LeaveTypeReadOnlyVM viewModelData = _mapper.Map<LeaveTypeReadOnlyVM>(leaveType);

        return View(viewModelData);
    }

    // GET: LeaveTypes/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: LeaveTypes/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(LeaveTypeCreateVM leaveTypeCreate)
    {
        // adding custom validation and model state error.
        if (leaveTypeCreate.Name.Contains("vacation"))
        {
            ModelState.AddModelError(nameof(leaveTypeCreate.Name), "The name should not contain vacation.");
        }

        if (!ModelState.IsValid)
        {
            return View(leaveTypeCreate);
        }

        // conversion from view model to entity

        LeaveType leaveType = _mapper.Map<LeaveType>(leaveTypeCreate);

        _context.Add(leaveType);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // GET: LeaveTypes/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        LeaveType? leaveType = await _context.LeaveTypes.FindAsync(id);
        if (leaveType == null)
        {
            return NotFound();
        }

        // convert the LeaveType Entity to LeaveTypeEditVM
        LeaveTypeEditVM leaveTypeViewData = _mapper.Map<LeaveTypeEditVM>(leaveType);

        return View(leaveTypeViewData);
    }

    // POST: LeaveTypes/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, LeaveTypeEditVM leaveTypeEdit)
    {
        if (id != leaveTypeEdit.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(leaveTypeEdit);
        }

        try
        {
            // convert from view model to entity
            LeaveType leaveType = _mapper.Map<LeaveType>(leaveTypeEdit);

            // _context.Entry(leaveType).State = EntityState.Modified;
            _context.Update(leaveType);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LeaveTypeExists(leaveTypeEdit.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: LeaveTypes/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        LeaveType? leaveType = await _context.LeaveTypes
                                             .FirstOrDefaultAsync(m => m.Id == id);
        if (leaveType == null)
        {
            return NotFound();
        }

        // convert from Entity to View Model
        LeaveTypeReadOnlyVM leaveTypeViewData =  _mapper.Map<LeaveTypeReadOnlyVM>(leaveType);

        return View(leaveTypeViewData);
    }

    // POST: LeaveTypes/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var leaveType = await _context.LeaveTypes.FindAsync(id);
        if (leaveType != null)
        {
            _context.LeaveTypes.Remove(leaveType);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool LeaveTypeExists(int id)
    {
        return _context.LeaveTypes.Any(e => e.Id == id);
    }
}
