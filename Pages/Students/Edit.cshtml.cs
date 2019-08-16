using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using SampleUniversity.Data;
using SampleUniversity.Models;

namespace SampleUniversity.Pages_Students {
    public class EditModel : PageModel {
        private readonly IStudentContext _context;

        public EditModel(IStudentContext context) {
            _context = context;
        }

        [BindProperty] public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(string id) {
            if (id == null) {
                return NotFound();
            }

            var filter = Builders<Student>.Filter.Empty;
            Student = await _context.Students.FindSync(m => m.Id == id).FirstOrDefaultAsync();

            if (Student == null) {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            try {
                await _context.Students.FindOneAndReplaceAsync<Student>(
                    Builders<Student>.Filter.Eq(s => s.Id, Student.Id), Student);
            }
            catch (DbUpdateConcurrencyException) {
                if (!StudentExists(Student.Id)) {
                    return NotFound();
                }
                else {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StudentExists(string id) {
            return _context.Students.FindSync(e => e.Id == id).FirstOrDefault() != null;
        }
    }
}