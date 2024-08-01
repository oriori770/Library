using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Models;

namespace Library.Controllers
{
    public class BookcasesController : Controller
    {
        private readonly LibraryContext _context;

        public BookcasesController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Bookcases
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bookcase.ToListAsync());
        }

        // GET: Bookcases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookcase = await _context.Bookcase //.Include(bc => bc.shelflist)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookcase == null)
            {
                return NotFound();
            }

            return View(bookcase);
        }

        // GET: Bookcases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bookcases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,genre")] Bookcase bookcase)
        {
            ModelState.Remove("");
            if (ModelState.IsValid)
            {
                _context.Add(bookcase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookcase);
        }

        // GET: Bookcases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookcase = await _context.Bookcase.FindAsync(id);
            if (bookcase == null)
            {
                return NotFound();
            }
            return View(bookcase);
        }

        // POST: Bookcases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,genre")] Bookcase bookcase)
        {
            if (id != bookcase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookcase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookcaseExists(bookcase.Id))
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
            return View(bookcase);
        }

        // GET: Bookcases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookcase = await _context.Bookcase
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookcase == null)
            {
                return NotFound();
            }

            return View(bookcase);
        }

        // POST: Bookcases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookcase = await _context.Bookcase.FindAsync(id);
            if (bookcase != null)
            {
                _context.Bookcase.Remove(bookcase);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookcaseExists(int id)
        {
            return _context.Bookcase.Any(e => e.Id == id);
        }
    }
}
