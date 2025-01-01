using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace FinancialApplication.Pages
{
    public class RetirementCalculatorModel : PageModel
    {
        [BindProperty]
        [Required]
        [Range(16, 99, ErrorMessage = "Enter age 16-99")]
        public int age { get; set; }

        [BindProperty]
        public int retirement_age { get; set; }
        public void OnPost()
        {

        }
    }
}
