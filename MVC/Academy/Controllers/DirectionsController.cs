
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Academy.Models;

public class DirectionsController : Controller
{
    private readonly AcademyContext _context;

    public DirectionsController(AcademyContext context)
    {
        _context = context;
    }

    // GET: DIRECTIONS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Direction.ToListAsync());
    }

    // GET: DIRECTIONS/Details/5
    public async Task<IActionResult> Details(int? direction_id)
    {
        if (direction_id == null)
        {
            return NotFound();
        }

        var direction = await _context.Direction
            .FirstOrDefaultAsync(m => m.direction_id == direction_id);
        if (direction == null)
        {
            return NotFound();
        }

        return View(direction);
    }

    // GET: DIRECTIONS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: DIRECTIONS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("direction_id,direction_name,Groups")] Direction direction)
    {
        if (ModelState.IsValid)
        {
            _context.Add(direction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(direction);
    }

    // GET: DIRECTIONS/Edit/5
    public async Task<IActionResult> Edit(int? direction_id)
    {
        if (direction_id == null)
        {
            return NotFound();
        }

        var direction = await _context.Direction.FindAsync(direction_id);
        if (direction == null)
        {
            return NotFound();
        }
        return View(direction);
    }

    // POST: DIRECTIONS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? direction_id, [Bind("direction_id,direction_name,Groups")] Direction direction)
    {
        if (direction_id != direction.direction_id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(direction);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectionExists(direction.direction_id))
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
        return View(direction);
    }

    // GET: DIRECTIONS/Delete/5
    public async Task<IActionResult> Delete(int? direction_id)
    {
        if (direction_id == null)
        {
            return NotFound();
        }

        var direction = await _context.Direction
            .FirstOrDefaultAsync(m => m.direction_id == direction_id);
        if (direction == null)
        {
            return NotFound();
        }

        return View(direction);
    }

    // POST: DIRECTIONS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? direction_id)
    {
        var direction = await _context.Direction.FindAsync(direction_id);
        if (direction != null)
        {
            _context.Direction.Remove(direction);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DirectionExists(int? direction_id)
    {
        return _context.Direction.Any(e => e.direction_id == direction_id);
    }
}
