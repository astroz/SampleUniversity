using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using SampleUniversity.Data;
using SampleUniversity.Models;
using IAsyncCursorExtensions = MongoDB.Driver.IAsyncCursorExtensions;

namespace SampleUniversity.Pages_Students {
    public class DeleteModel : PageModel {
        private readonly StudentContext _context;

        public DeleteModel(StudentContext context) {
            _context = context;
        }

        [BindProperty] public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(string id) {
            if (id == null) {
                return NotFound();
            }

            Student = await _context.Student.FindSync(m => m.Id == id).FirstOrDefaultAsync();

            if (Student == null) {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id) {
            if (id == null) {
                return NotFound();
            }

            _context.Student.FindOneAndDelete(s => s.Id == id);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}