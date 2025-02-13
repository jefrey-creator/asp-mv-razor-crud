using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace WebApp.Pages.Book
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext context;

        public DeleteModel(AppDbContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Books Books { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) {
                return RedirectToPage("./Index");
            }

            var books = await context.Books.FirstOrDefaultAsync(x => x.BookId == id);
            if (books == null) {
                return RedirectToPage("./Index");
            }
            else
            {
                Books = books;
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("./Index");
            }

            var books = await context.Books.FirstOrDefaultAsync(x => x.BookId == id);
            if (books == null) {
                return RedirectToPage("./Index");
            }
            else
            {
                Books = books;
                context.Books.Remove(Books);
                await context.SaveChangesAsync();
                TempData["Message"] = $"{Books.BookTitle} deleted successfully.";
                return RedirectToPage("./Index");
            }
        }
    }
}
