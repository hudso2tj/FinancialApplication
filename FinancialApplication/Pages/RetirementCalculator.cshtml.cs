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
        [Required]
        [Range(62, 70, ErrorMessage = "Enter age 62-70")]
        public int retirement_age { get; set; }

        [BindProperty]
        [Range(0, int.MaxValue)]
        public int current_investments { get; set; }

        [BindProperty]
        [Range(0, int.MaxValue)]
        public int contributions { get; set; }

        [BindProperty]
        public double annual_returns { get; set; }

        public int time { get; set; }
        public double future_value { get; set; }
        public void OnPost()
        {
            time = (retirement_age - age) * 12;
            annual_returns = (annual_returns / 100) / 12;
            future_value = contributions * ((Math.Pow(1 + annual_returns, time) - 1) / annual_returns) +
        current_investments * Math.Pow(1 + annual_returns, time);
        }
    }
}
