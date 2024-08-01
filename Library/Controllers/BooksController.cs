using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Books   string? message = null
        public async Task<IActionResult> Index(int? FreeSpace = null)
        {
            ViewData["FreeSpace"] = FreeSpace;
            var libraryContext = _context.Book.Include(b => b.Bookcase).Include(b => b.shelf).ThenInclude(s => s.Bookcase);
            return View(await libraryContext.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Bookcase)
                .Include(b => b.shelf)
                .FirstOrDefaultAsync(m => m.id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            var libraryContext = _context.Book.Include(b => b.Bookcase).Include(b => b.shelf).ThenInclude(s => s.Bookcase);
            ViewData["BookcaseId"] = new SelectList(_context.Bookcase, "Id", "genre");
            ViewData["ShelfId"] = new SelectList(_context.Shelf, "BookcaseId", "Id");
            return View();
            //return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,BooksName,Height,Width,BookcaseId,IsSet,ShelfId")] Book book)
            {
            
            int Shelfid = (int)book.ShelfId;
            Shelf shelf = FindShelfById(Shelfid);
            int FreeSpace = AvailableWeidthInShelf(shelf);
            ModelState.Remove("IsSet");
            ModelState.Remove("shelf");
            ModelState.Remove("Bookcase");
            ModelState.Remove("SetBooksId");
            ModelState.Remove("setBooks");

            if (book.Width > FreeSpace)
            {
                return View(book);
            }
            if (book.Height > shelf.Height)
            {
                return View(book);
            }          
            if (book.Height <= shelf.Height -10 && ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new
                {
                    FreeSpace = shelf.Height - book.Height

                });
              
            }
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookcaseId"] = new SelectList(_context.Bookcase, "Id", "Id", book.BookcaseId);
            ViewData["ShelfId"] = new SelectList(_context.Shelf, "Id", "Id", book.ShelfId);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["BookcaseId"] = new SelectList(_context.Bookcase, "Id", "Id", book.BookcaseId);
            ViewData["ShelfId"] = new SelectList(_context.Shelf, "Id", "Id", book.ShelfId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,BooksName,Height,Width,BookcaseId,IsSet,ShelfId")] Book book)
        {
            if (id != book.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.id))
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
            ViewData["BookcaseId"] = new SelectList(_context.Bookcase, "Id", "Id", book.BookcaseId);
            ViewData["ShelfId"] = new SelectList(_context.Shelf, "Id", "Id", book.ShelfId);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Bookcase)
                .Include(b => b.shelf)
                .FirstOrDefaultAsync(m => m.id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Book.FindAsync(id);
            if (book != null)
            {
                _context.Book.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.id == id);
        }

        public int AvailableWeidthInShelf(Shelf shelf)
        {
            int FreeSize = shelf.Weidth;
            foreach (Book book in shelf.Books)
            {
                FreeSize -= book.Width;
            }
            return FreeSize;
        }
        public Shelf FindShelfById(int id)
        {
            Shelf oneShelf = _context.Shelf.Find(id);
            return oneShelf;
        }

    }
}
