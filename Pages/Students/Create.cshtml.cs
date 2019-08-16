using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SampleUniversity.Data;
using SampleUniversity.Models;

namespace SampleUniversity.Pages_Students {
    public class CreateModel : PageModel {
        private readonly IStudentContext _context;

        public CreateModel(IStudentContext context) {
            _context = context;
        }

        public IActionResult OnGet() {
            return Page();
        }

        [BindProperty] public Student Student { get; set; }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            await _context.Students.InsertOneAsync(Student);

            return RedirectToPage("./Index");
        }
    }
}