using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using SampleUniversity.Data;
using SampleUniversity.Models;

namespace SampleUniversity.Pages.Students {
    public class DetailsModel : PageModel {
        private readonly IStudentContext _context;

        public DetailsModel(IStudentContext context) {
            _context = context;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(string id) {
            if (id == null) {
                return NotFound();
            }

            Student = await _context.Students.FindSync(m => m.Id == id).FirstOrDefaultAsync();

            if (Student == null) {
                return NotFound();
            }

            return Page();
        }
    }
}