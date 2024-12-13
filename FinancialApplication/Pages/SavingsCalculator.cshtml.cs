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
        public int years { get; set; }

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

        // List to store balances over time
        public List<double> BalanceOverTime { get; private set; } = new List<double>();

        public void OnPost()
        {
            annual_interest = annual_interest / 100;
            BalanceOverTime.Clear();

            if (compound_frequency == 1) // Monthly compounding
            {
                eb1 = (1 + annual_interest / 12);
                eb2 = 12 * years;

                for (int i = 1; i <= eb2; i++)
                {
                    double balance = Math.Pow(eb1, i) * starting_balance;
                    BalanceOverTime.Add(balance);
                }

                ending_balance = BalanceOverTime.Last();
            }
            else if (compound_frequency == 2) // Yearly compounding
            {
                eb1 = (1 + annual_interest / 1);
                eb2 = 1 * years;

                for (int i = 1; i <= eb2; i++)
                {
                    double balance = Math.Pow(eb1, i) * starting_balance;
                    BalanceOverTime.Add(balance);
                }

                ending_balance = BalanceOverTime.Last();
            }
        }
    }
}
