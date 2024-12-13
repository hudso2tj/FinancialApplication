using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace FinancialApplication.Pages
{
    public class SavingsCalculatorModel : PageModel
    {

        [BindProperty]
        [Required]
        [Range(0.0, double.MaxValue, ErrorMessage = "Please enter a number greater than 0")]
        public double starting_balance { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please enter a number greater than 0")]
        public int years {  get; set; }

        [BindProperty]
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a number greater than 0")]
        public double annual_interest { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please select a compound frequency")]
        public int compound_frequency { get; set; }
        public double ending_balance { get; set; }
        public double eb1 { get; set; }
        public double eb2 { get; set; }

        public void OnPost()
        {
            annual_interest = annual_interest / 100;

            //Calculations for monthly compounding interest
            if (compound_frequency == 1)
            {
                eb1 = (1 + annual_interest / 12);
                eb2 = (12 * years);
                ending_balance = Math.Pow(eb1, eb2) * starting_balance;

            }
            // Calculations for yearly compounding interest
            else if (compound_frequency == 2)
            {
                eb1 = (1 + annual_interest / 1);
                eb2 = (1 * years);
                ending_balance = Math.Pow(eb1, eb2) * starting_balance;
            }
            //Will likely add support for more compounding frequencies

        }
    }
}
