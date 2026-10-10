
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Academy.Models;

public class DisciplinesController : Controller
{
    private readonly AcademyContext _context;

    public DisciplinesController(AcademyContext context)
    {
        _context = context;
    }

    // GET: DISCIPLINES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Disciplines.ToListAsync());
    }

    // GET: DISCIPLINES/Details/5
    public async Task<IActionResult> Details(int? discipline_id)
    {
        if (discipline_id == null)
        {
            return NotFound();
        }

        var discipline = await _context.Disciplines
            .FirstOrDefaultAsync(m => m.discipline_Id == discipline_id);
        if (discipline == null)
        {
            return NotFound();
        }

        return View(discipline);
    }

    // GET: DISCIPLINES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: DISCIPLINES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("discipline_Id,discipline_Name,number_of_lessons")] Discipline discipline)
    {
        if (ModelState.IsValid)
        {
            _context.Add(discipline);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(discipline);
    }

    // GET: DISCIPLINES/Edit/5
    public async Task<IActionResult> Edit(int? discipline_id)
    {
        if (discipline_id == null)
        {
            return NotFound();
        }

        var discipline = await _context.Disciplines.FindAsync(discipline_id);
        if (discipline == null)
        {
            return NotFound();
        }
        return View(discipline);
    }

    // POST: DISCIPLINES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? discipline_id, [Bind("discipline_Id,discipline_Name,number_of_lessons")] Discipline discipline)
    {
        if (discipline_id != discipline.discipline_Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(discipline);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisciplineExists(discipline.discipline_Id))
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
        return View(discipline);
    }

    // GET: DISCIPLINES/Delete/5
    public async Task<IActionResult> Delete(int? discipline_id)
    {
        if (discipline_id == null)
        {
            return NotFound();
        }

        var discipline = await _context.Disciplines
            .FirstOrDefaultAsync(m => m.discipline_Id == discipline_id);
        if (discipline == null)
        {
            return NotFound();
        }

        return View(discipline);
    }

    // POST: DISCIPLINES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? discipline_id)
    {
        var discipline = await _context.Disciplines.FindAsync(discipline_id);
        if (discipline != null)
        {
            _context.Disciplines.Remove(discipline);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DisciplineExists(int? discipline_id)
    {
        return _context.Disciplines.Any(e => e.discipline_Id == discipline_id);
    }
}
