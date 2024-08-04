using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Models;
using Library.ViewModels;

namespace Library.Controllers
{
    public class SetBooksController : Controller
    {
        private readonly LibraryContext _context;

        public SetBooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: SetBooks
        public async Task<IActionResult> Index()
        {
            return View(await _context.SetBooks.ToListAsync());
        }

        // GET: SetBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setBooks = await _context.SetBooks
                .FirstOrDefaultAsync(m => m.id == id);
            if (setBooks == null)
            {
                return NotFound();
            }

            return View(setBooks);
        }

        // GET: SetBooks/Create
        public IActionResult Create()
        {
            ViewData["BookcaseId"] = new SelectList(_context.Bookcase, "Id", "genre");
            return View();
        }

        // POST: SetBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,setName,Height,bookListModel")] SetOfBook setOfBook)
        {
            ModelState.Remove("Bookcase");
            ModelState.Remove("SetBooksId");
            if (ModelState.IsValid)
            {
                SetBooks setBooks = new SetBooks { setName = setOfBook.setName, Height = setOfBook.Height, BookcaseId = setOfBook.BookcaseId };
                _context.Add(setBooks);
                await _context.SaveChangesAsync();

                // עיבוד הנתונים של הספרים
                foreach (var book in setOfBook.bookListModel)
                {
                    Book onebook = new Book { BooksName = book.Name, Width = book.Width, Height = setBooks.Height, SetBooksId = setBooks.id, BookcaseId = setBooks.BookcaseId };
                    setBooks.bookList.Add(onebook);
                    _context.Add(onebook);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(setOfBook);
        }

        // GET: SetBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setBooks = await _context.SetBooks.FindAsync(id);
            if (setBooks == null)
            {
                return NotFound();
            }
            return View(setBooks);
        }

        // POST: SetBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,setName,Height")] SetBooks setBooks)
        {
            if (id != setBooks.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(setBooks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SetBooksExists(setBooks.id))
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
            return View(setBooks);
        }

        // GET: SetBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setBooks = await _context.SetBooks
                .FirstOrDefaultAsync(m => m.id == id);
            if (setBooks == null)
            {
                return NotFound();
            }

            return View(setBooks);
        }

        // POST: SetBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var setBooks = await _context.SetBooks.FindAsync(id);
            if (setBooks != null)
            {
                _context.SetBooks.Remove(setBooks);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SetBooksExists(int id)
        {
            return _context.SetBooks.Any(e => e.id == id);
        }
    }
}
