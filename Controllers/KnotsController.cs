using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TreeStructureIdeo.Data;
using TreeStructureIdeo.Models;

namespace TreeStructureIdeo.Controllers
{
    public class KnotsController : Controller
    {
        private readonly TreeStructureIdeoContext _context;

        public KnotsController(TreeStructureIdeoContext context)
        {
            _context = context;
        }

        // GET: Knots


        public async Task<IActionResult> Index(string SearchString)
        {
            return View(await _context.Knots.ToListAsync());
        }

        public async Task<IActionResult> Index_z_wartosciami_id()
        {
            return View(await _context.Knots.ToListAsync());
        }

        // GET: Knots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knots = await _context.Knots
                .FirstOrDefaultAsync(m => m.Id == id);
            if (knots == null)
            {
                return NotFound();
            }

            return View(knots);
        }

        // GET: Knots/Create
        public IActionResult Create(string Text)
        {
            return View();
        }

        // POST: Knots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ParentId,Text")] Knots knots)
        {
            if (ModelState.IsValid)
            {
                _context.Add(knots);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(knots);
        }

        // GET: Knots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knots = await _context.Knots.FindAsync(id);
            if (knots == null)
            {
                return NotFound();
            }
            return View(knots);
        }

        // POST: Knots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ParentId,Text")] Knots knots)
        {
            if (id != knots.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(knots);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KnotsExists(knots.Id))
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
            return View(knots);
        }

        // GET: Knots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knots = await _context.Knots
                .FirstOrDefaultAsync(m => m.Id == id);
            if (knots == null)
            {
                return NotFound();
            }

            return View(knots);
        }

        // POST: Knots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var knots = await _context.Knots.FindAsync(id);
            _context.Knots.Remove(knots);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KnotsExists(int id)
        {
            return _context.Knots.Any(e => e.Id == id);
        }
    }
}
