using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace FinancialApplication.Pages
{
    public class RetirementCalculatorModel : PageModel
    {
        //Model binding to pass to view
        [BindProperty]
        [Required]
        [Range(16, 99, ErrorMessage = "Enter age 16-99")]
        public int age { get; set; }

        [BindProperty]
        [Required]
        [Range(25, 70, ErrorMessage = "Enter age 62-70")]
        public int retirement_age { get; set; }

        [BindProperty]
        [Range(0, int.MaxValue, ErrorMessage ="Enter a postitive number")]
        public int current_investments { get; set; }

        [BindProperty]
        [Range(0, int.MaxValue, ErrorMessage ="Enter a positive number")]
        public int contributions { get; set; }

        [BindProperty]
        [Required]
        [Range(int.MinValue, int.MaxValue)]
        public double annual_returns { get; set; }

        [BindProperty]
        [Required]
        [Range(0, 100, ErrorMessage = "Enter a number 0-100")]
        public double withdraw_percentage { get; set; }

        [BindProperty]
        [Required]
        [Range(20, 120, ErrorMessage = "Enter a number 20-120")]
        public int life_expectancy { get; set; }

        public int time { get; set; }
        public double future_value { get; set; }
        public int retirement_years { get; set; }
        public double display_withdraw_amount { get; set; }
        public void OnPost()
        {
            //Variables used in retirement table
            display_withdraw_amount = withdraw_percentage;
            retirement_years = retirement_age + 1;

            //Retirement formula calculations
            time = (retirement_age - age) * 12;
            annual_returns = (annual_returns / 100) / 12;
            future_value = contributions * ((Math.Pow(1 + annual_returns, time) - 1) / annual_returns) +
            current_investments * Math.Pow(1 + annual_returns, time);
        }
    }
}
