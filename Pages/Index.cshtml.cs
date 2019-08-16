using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SampleUniversity.Data;
using SampleUniversity.Models;

namespace SampleUniversity.Pages {
    public class IndexModel : PageModel {
        private readonly IStudentContext _context;

        public IndexModel(IStudentContext context) {
            _context = context;
        }

        public void OnGet() {
        }
    }
}