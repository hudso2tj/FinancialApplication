using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace FinancialApplication.Pages
{
    public class NetWorthCalculatorModel : PageModel
    {
        // Model binding for Asset variables
        [BindProperty]
        [Range(0, double.MaxValue, ErrorMessage = "Must be a positive number.")]
        public double Cash { get; set; }

        [BindProperty]
        [Range(0, double.MaxValue, ErrorMessage = "Must be a positive number.")]
        public double Investments { get; set; }

        [BindProperty]
        [Range(0, double.MaxValue, ErrorMessage = "Must be a positive number.")]
        public double RealEstate { get; set; }

        [BindProperty]
        [Range(0, double.MaxValue, ErrorMessage = "Must be a positive number.")]
        public double PersonalProperty { get; set; }

        [BindProperty]
        [Range(0, double.MaxValue, ErrorMessage = "Must be a positive number.")]
        public double BusinessOwnership { get; set; }

        [BindProperty]
        [Range(0, double.MaxValue, ErrorMessage = "Must be a positive number.")]
        public double OtherAssets { get; set; }

        // Model binding for liability variables
        [BindProperty]
        [Range(0, double.MaxValue, ErrorMessage = "Must be a positive number.")]
        public double ShortTermLiability { get; set; }

        [BindProperty]
        [Range(0, double.MaxValue, ErrorMessage = "Must be a positive number.")]
        public double LongTermLiability { get; set; }

        [BindProperty]
        [Range(0, double.MaxValue, ErrorMessage = "Must be a positive number.")]
        public double OtherLiability { get; set; }

        // Property to hold the calculated Net Worth
        public double NetWorth { get; set; }

        public NetWorthCalculatorModel()
        {
            NetWorth = double.MinValue;
        }

        public void OnPost()
        {
            //Calculations
            double Assets = Cash + Investments + RealEstate + PersonalProperty + OtherAssets + BusinessOwnership;
            double Liabilities = ShortTermLiability + LongTermLiability + OtherLiability;
            NetWorth = Assets - Liabilities;
        }
    }
}
