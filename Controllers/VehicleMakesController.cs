using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mono.Data;
using Mono.Models;

namespace Mono.Controllers
{
    public class VehicleMakesController : Controller
    {
        private readonly VehicledbContext _context;
        private readonly YourService _yourService;

        public VehicleMakesController(VehicledbContext context, YourService yourService)
        {
            _context = context;
            _yourService = yourService;
        }

        public async Task<IActionResult> Index()
        {
            return _context.VehicleMakes != null ?
                View(await _context.VehicleMakes.ToListAsync()) :
                Problem("Entity set 'VehicledbContext.VehicleMakes'  is null.");
        }

public async Task<IActionResult> Details(int? id)
{
    if (id == null || _context.VehicleMakes == null)
    {
        return NotFound();
    }

    var vehicleMake = await _context.VehicleMakes
        .FirstOrDefaultAsync(m => m.Id == id);
    if (vehicleMake == null)
    {
        return NotFound();
    }

    return View(vehicleMake);
}

public IActionResult Create()
{
    return View();
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Id,Name,Abrv")] VehicleMake vehicleMake)
{
    if (ModelState.IsValid)
    {
        _context.Add(vehicleMake);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    return View(vehicleMake);
}

public async Task<IActionResult> Edit(int? id)
{
    if (id == null || _context.VehicleMakes == null)
    {
        return NotFound();
    }

    var vehicleMake = await _context.VehicleMakes.FindAsync(id);
    if (vehicleMake == null)
    {
        return NotFound();
    }
    return View(vehicleMake);
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Abrv")] VehicleMake vehicleMake)
{
    if (id != vehicleMake.Id)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        try
        {
            _context.Update(vehicleMake);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VehicleMakeExists(vehicleMake.Id))
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
    return View(vehicleMake);
}

public async Task<IActionResult> Delete(int? id)
{
    if (id == null || _context.VehicleMakes == null)
    {
        return NotFound();
    }

    var vehicleMake = await _context.VehicleMakes
        .FirstOrDefaultAsync(m => m.Id == id);
    if (vehicleMake == null)
    {
        return NotFound();
    }

    return View(vehicleMake);
}

[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    if (_context.VehicleMakes == null)
    {
        return Problem("Entity set 'VehicledbContext.VehicleMakes'  is null.");
    }
    var vehicleMake = await _context.VehicleMakes.FindAsync(id);
    if (vehicleMake != null)
    {
        _context.VehicleMakes.Remove(vehicleMake);
    }

    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
}

private bool VehicleMakeExists(int id)
{
    return (_context.VehicleMakes?.Any(e => e.Id == id)).GetValueOrDefault();
}
    }
