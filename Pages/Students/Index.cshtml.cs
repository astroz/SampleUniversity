using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using SampleUniversity.Data;
using SampleUniversity.Models;

namespace SampleUniversity.Pages.Students {
    public class IndexModel : PageModel {
        private readonly IStudentContext _context;

        public IndexModel(IStudentContext context) {
            _context = context;
        }

        public IList<Student> Student { get; set; }

        public async Task OnGetAsync() {
            var filter = FilterDefinition<Student>.Empty;
            Student = await _context.Students.FindSync<Student>(filter).ToListAsync();
        }
    }
}