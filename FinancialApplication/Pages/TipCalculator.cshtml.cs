using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace FinancialApplication.Pages
{
    public class TipCalculatorModel : PageModel
    {
        // Model binding for user input
        [BindProperty]
        [Range(1, double.MaxValue, ErrorMessage = "Total must be a positive number.")]
        public double? Total { get; set; }

        [BindProperty]
        [Range(0, double.MaxValue, ErrorMessage = "Tip percentage must be a positive number.")]
        public double? TipPercentage { get; set; }

        [BindProperty]
        [Range(1, int.MaxValue, ErrorMessage = "Must be a positive whole number.")]
        public int? NumPeople { get; set; }

        // Properties to store calculated values
        public double TipAmount { get; set; }
        public double TotalAfterTip { get; set; }
        public double TotalPerPerson { get; set; }

        public void OnPost()
        {
            if (Total.HasValue && NumPeople.HasValue && TipPercentage.HasValue)
            {
                TipAmount = (double)((Total.Value * TipPercentage) / 100);
                TotalAfterTip = TipAmount + Total.Value;
                TotalPerPerson = TotalAfterTip / NumPeople.Value;
            }
        }
    }
}
