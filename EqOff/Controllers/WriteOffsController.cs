using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EqOff.Data;
using EqOff.Models;

namespace EqOff.Controllers
{
    public class WriteOffsController : Controller
    {
        private readonly ApplContext _context;

        public WriteOffsController(ApplContext context)
        {
            _context = context;
        }

        // GET: WriteOffs
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null || _context.WriteOffs == null)
            {
                return NotFound();
            }

            ViewData["Fio"] = _context.Employees.Select(d => new { id = d.EmployeeId, Fio = d.Surname + " " + d.Name + " " + d.Patronymic }).FirstOrDefault(d => d.id == id).Fio;

            ViewData["IdEmployee"] = id;

            var docRegContext = _context.WriteOffs.Where(d => d.EmployeeId == id).Include(d => d.Equipment).Include(d => d.Employee);
            return View(await docRegContext.ToListAsync());
        }

        // GET: WriteOffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WriteOffs == null)
            {
                return NotFound();
            }

            var writeOff = await _context.WriteOffs
                .Include(w => w.Employee)
                .Include(w => w.Equipment)
                .FirstOrDefaultAsync(m => m.WriteOffId == id);
            if (writeOff == null)
            {
                return NotFound();
            }

            return View(writeOff);
        }

        // GET: WriteOffs/Create
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = id;
            ViewData["EquipmentId"] = new SelectList(_context.Equipments, "EquipmentId", "EqName");
            return View();
        }

        // POST: WriteOffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WriteOffId,EquipmentId,Reason,DateOff,EmployeeId,Number,DateReg")] WriteOff writeOff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(writeOff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = writeOff.EmployeeId });
            }
            ViewData["EmployeeId"] = writeOff.EmployeeId;
            ViewData["EquipmentId"] = new SelectList(_context.Equipments, "EquipmentId", "EqName", writeOff.EquipmentId);
            return View(writeOff);
        }

        // GET: WriteOffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WriteOffs == null)
            {
                return NotFound();
            }

            var writeOff = await _context.WriteOffs.FindAsync(id);
            if (writeOff == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = writeOff.EmployeeId;
            ViewData["EquipmentId"] = new SelectList(_context.Equipments, "EquipmentId", "EqName", writeOff.EquipmentId);
            return View(writeOff);
        }

        // POST: WriteOffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WriteOffId,EquipmentId,Reason,DateOff,EmployeeId,Number,DateReg")] WriteOff writeOff)
        {
            if (id != writeOff.WriteOffId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(writeOff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WriteOffExists(writeOff.WriteOffId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = writeOff.EmployeeId});
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Name", writeOff.EmployeeId);
            ViewData["EquipmentId"] = new SelectList(_context.Equipments, "EquipmentId", "EqName", writeOff.EquipmentId);
            return View(writeOff);
        }

        // GET: WriteOffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WriteOffs == null)
            {
                return NotFound();
            }

            var writeOff = await _context.WriteOffs
                .Include(w => w.Employee)
                .Include(w => w.Equipment)
                .FirstOrDefaultAsync(m => m.WriteOffId == id);
            if (writeOff == null)
            {
                return NotFound();
            }

            return View(writeOff);
        }

        // POST: WriteOffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WriteOffs == null)
            {
                return Problem("Entity set 'ApplContext.WriteOffs'  is null.");
            }
            var writeOff = await _context.WriteOffs.FindAsync(id);
            if (writeOff != null)
            {
                _context.WriteOffs.Remove(writeOff);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = writeOff.EmployeeId });
        }

        private bool WriteOffExists(int id)
        {
          return (_context.WriteOffs?.Any(e => e.WriteOffId == id)).GetValueOrDefault();
        }
    }
}
