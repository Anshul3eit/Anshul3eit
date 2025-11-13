using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginPage.Pages;

public class LoginModel : PageModel
{
    [BindProperty]
    public InputModel Input { get; set; } = new();

    public string? ErrorMessage { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Demo credentials - replace with real auth logic
        if (Input.Email == "user@example.com" && Input.Password == "Pass123!")
        {
            return RedirectToPage("/Index");
        }

        ErrorMessage = "Invalid credentials";
        return Page();
    }

    public class InputModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
