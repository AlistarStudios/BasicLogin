using BasicLogin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BasicLogin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BasicLogin.Data.BasicLoginContext _context;
        public string ErrorMessage { get; set; }

        [BindProperty]
        public UserAccount Input { get; set; }

        public IndexModel(BasicLogin.Data.BasicLoginContext context)
        {
            _context = context;
        }

        public void OnGet()
        {

        }

        //public IActionResult OnSignUpClick()
        //{
        //    return RedirectToPage("/Users/Create");
        //}

        public async Task<IActionResult> OnPostAsync()
        {
            var propertyToValidate = ModelState["Input.Email"];

            if (propertyToValidate is null || propertyToValidate.Errors.Any())
            {
                return Page();
            }
            propertyToValidate = ModelState["Input.Password"];

            if (propertyToValidate is null || propertyToValidate.Errors.Any())
            {
                return Page();
            }

            var user = 
                await _context.UserAccount.FirstOrDefaultAsync(
                    u => u.Email == Input.Email && u.Password == Input.Password);

            if (user == null) 
            {
                ErrorMessage = "Email or Password not recognized";
                return Page();
            }

            return RedirectToPage("/Users/Details", new {id = user.Id});
        }
    }
}
