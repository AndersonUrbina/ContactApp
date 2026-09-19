using ContactApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactApp.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public Contact Contact { get; set; }
        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                // Show contact contact page again
                return Page();
            }
            else
            {
                // Save contact to database
                List<Contact> contacts = System.Text.Json.JsonSerializer.Deserialize<List<Contact>>(System.IO.File.ReadAllText("data/contacts.json")) ?? new List<Contact>();
                contacts.Add(Contact);
                var json = System.Text.Json.JsonSerializer.Serialize(contacts);
                System.IO.File.WriteAllText("data/contacts.json", json);

                // Redirect to thank you page
                return RedirectToPage("ThankYou");
            }
        }

    }
}