using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BasicLogin.Data;
using BasicLogin.Models;

namespace BasicLogin.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly BasicLogin.Data.BasicLoginContext _context;

        public CreateModel(BasicLogin.Data.BasicLoginContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UserAccount UserAccount { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UserAccount.Add(UserAccount);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Users/Details", new {id = UserAccount.Id});
        }
    }
}
