using LeaveManagementSystem.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Controllers;

public class LeaveTypesController(ILeaveTypeService leaveTypeService) : Controller
{
    // private readonly ApplicationDbContext _context;
    // private readonly IMapper _mapper;
    private readonly ILeaveTypeService _leaveTypeService = leaveTypeService;
    private const string NameExistsValidationMessage = "Name already exists";

    // GET: LeaveTypes
    public async Task<ViewResult> Index()
    {
        IEnumerable<LeaveTypeReadOnlyVM> leaveTypes = await _leaveTypeService.GetAllAsync();
        return View(leaveTypes);
    }

    // GET: LeaveTypes/Details/5
    [HttpGet]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        LeaveTypeReadOnlyVM? leaveType = await _leaveTypeService.GetByIdAsync<LeaveTypeReadOnlyVM>(id.Value);
        
        if (leaveType == null)
        {
            return NotFound();
        }
        
        return View(leaveType);
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
        // check if the name already exists in the database
        if (await _leaveTypeService.CheckLeaveTypeNameExists(leaveTypeCreate.Name))
        {
            ModelState.AddModelError(nameof(leaveTypeCreate.Name), NameExistsValidationMessage);
        }

        // adding custom validation and model state error.
        if (leaveTypeCreate.Name.Contains("vacation"))
        {
            ModelState.AddModelError(nameof(leaveTypeCreate.Name), "The name should not contain vacation.");
        }

        if (!ModelState.IsValid)
        {
            return View(leaveTypeCreate);
        }

        await _leaveTypeService.CreateAsync(leaveTypeCreate);
        
        return RedirectToAction(nameof(Index));
    }

    // GET: LeaveTypes/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        LeaveTypeEditVM leaveType = await _leaveTypeService.GetByIdAsync<LeaveTypeEditVM>(id.Value);

        if (leaveType is null)
        {
            return NotFound();
        }
        return View(leaveType);
    }

    // POST: LeaveTypes/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, LeaveTypeEditVM leaveTypeEdit)
    {
        if (await _leaveTypeService.CheckLeaveTypeNameExistsForEdit(leaveTypeEdit))
        {
            ModelState.AddModelError(nameof(leaveTypeEdit.Name), NameExistsValidationMessage);
        }
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
            await _leaveTypeService.EditAsync(leaveTypeEdit);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (! await _leaveTypeService.LeaveTypeExists(leaveTypeEdit.Id))
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

        LeaveTypeReadOnlyVM leaveType = await _leaveTypeService.GetByIdAsync<LeaveTypeReadOnlyVM>(id.Value);
        
        if(leaveType is null)
        {
            return NotFound();
        }

        return View(leaveType);
    }

    // POST: LeaveTypes/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _leaveTypeService.DeleteByIdAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
