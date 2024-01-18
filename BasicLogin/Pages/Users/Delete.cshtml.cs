using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BasicLogin.Data;
using BasicLogin.Models;

namespace BasicLogin.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly BasicLogin.Data.BasicLoginContext _context;

        public DeleteModel(BasicLogin.Data.BasicLoginContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserAccount UserAccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var useraccount = await _context.UserAccount.FirstOrDefaultAsync(m => m.Id == id);

            if (useraccount == null)
            {
                return NotFound();
            }
            else
            {
                UserAccount = useraccount;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var useraccount = await _context.UserAccount.FindAsync(id);
            if (useraccount != null)
            {
                UserAccount = useraccount;
                _context.UserAccount.Remove(UserAccount);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
