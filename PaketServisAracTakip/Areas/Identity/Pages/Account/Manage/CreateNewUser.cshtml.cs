using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PaketServisAracTakip.Areas.Identity.Data;

namespace PaketServisAracTakip.Areas.Identity.Pages.Account.Manage
{
    public class CreateNewUserModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateNewUserModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "{0} alan� bo� b�rak�lamaz.")]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "{0} alan� bo� b�rak�lamaz.")]
            [StringLength(100, ErrorMessage = "{0} en az {2} ve en fazla {1} karakter uzunlu�unda olmal�d�r.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "�ifre")]
            public string Password { get; set; }
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var findByEmail = await _userManager.FindByEmailAsync(Input.Email);
            var findByName = await _userManager.FindByNameAsync(Input.Email);

            if(findByEmail != null || findByName != null)
            {
                StatusMessage = "Bu email adresiyle zaten bir kullan�c� sisteme kay�tl�.";
                return RedirectToPage();
            }

            var user = new ApplicationUser();
            user.Email = Input.Email;
            user.UserName = Input.Email;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, Input.Password);

            await _userManager.CreateAsync(user);

            StatusMessage = Input.Email + " email adresine sahip hesap olu�turuldu.";
            return RedirectToPage();
        }
    }
}
