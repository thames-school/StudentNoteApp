using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentNoteApp.Data;
using StudentNoteApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentNoteApp.Pages
{
    public class AddNoteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public Note Note { get; set; }  // To hold the form data

        public List<Student> Students { get; set; }  // To display students
        public List<Subject> Subjects { get; set; }  // To display subjects

        public AddNoteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // This method is called when the page loads
        public async Task OnGetAsync()
        {
            // Fetch all students and subjects to populate the dropdowns
            Students = await _context.Students.ToListAsync();
            Subjects = await _context.Subjects.ToListAsync();
        }

        // This method is called when the form is submitted
        public async Task<IActionResult> OnPostAsync()
        {
            // Ensure the data is valid
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Assign the TeacherId from the logged-in user (this can be done via User.Claims)
            Note.TeacherId = User.Identity.Name; // Adjust based on how you handle authentication

            // Add the note to the database
            _context.Notes.Add(Note);
            await _context.SaveChangesAsync();

            // Redirect to another page or display a success message
            return RedirectToPage("/Index");  // Redirect to the home page or a confirmation page
        }
    }
}
