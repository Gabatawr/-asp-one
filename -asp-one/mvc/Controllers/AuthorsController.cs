using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.ViewModels.Authors;

namespace mvc.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AuthorsController(ApplicationDbContext context) => _context = context;

        // GET: Authors
        public IActionResult Index() => View(_context.Author.AsAsyncEnumerable());

        // GET: Authors/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var author = await _context.Author
                .FirstOrDefaultAsync(m => m.Id == id);
            if (author == null) return NotFound();

            return View(author);
        }

        // GET: Authors/Create
        public IActionResult Create() => View();

        // POST: Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Birthday")] Author author)
        {
            if (ModelState.IsValid)
            {
                author.Id = Guid.NewGuid();
                _context.Add(author);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Authors/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var author = await _context.Author.FindAsync(id);
            if (author == null) return NotFound();
            
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,LastName,Email,Birthday")] Author author)
        {
            if (id != author.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(author);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_context.Author.Any(e => e.Id == id) is false) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var author = await _context.Author
                .FirstOrDefaultAsync(m => m.Id == id);

            if (author == null) return NotFound();

            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var author = await _context.Author.FindAsync(id);
            _context.Author.Remove(author);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Authors/{authorId}/Books
        [Route("[controller]/{id:guid}/Books")]
        public async Task<IActionResult> Books(Guid id)
        {
            List<Book> books = await _context.Books.Include(b => b.Authors).ToListAsync();
            return View(books.Select(b =>
                new SelectedBook
                {
                    Book = b,
                    IsSelected = b.Authors.Any(a => a.Id == id)
                }).ToList());
        }

        // GET: Authors/{authorId}/Books
        [HttpPost("[controller]/{id:guid}/Books")]
        public async Task<IActionResult> Books(Guid id, IList<SelectedBook> selectedBooks)
        {
            var author = await _context.Author.Include(a => a.Books)
                                              .FirstOrDefaultAsync(a => a.Id == id);

            if (author == null) return NotFound();

            author.Books.Clear();
            var selectedList = selectedBooks.Where(b => b.IsSelected)
                                            .Select(b => b.Book);
            foreach (var book in selectedList)
                author.Books.Add(await _context.Books.FirstAsync(b => b.Id == book.Id));
                
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = id });
        }
    }
}
