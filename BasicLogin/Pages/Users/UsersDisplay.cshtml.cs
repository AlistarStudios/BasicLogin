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
    public class IndexModel : PageModel
    {
        private readonly BasicLogin.Data.BasicLoginContext _context;

        public IndexModel(BasicLogin.Data.BasicLoginContext context)
        {
            _context = context;
        }

        public IList<UserAccount> UserAccount { get;set; } = default!;

        public async Task OnGetAsync()
        {
            UserAccount = await _context.UserAccount.ToListAsync();
        }
    }
}
