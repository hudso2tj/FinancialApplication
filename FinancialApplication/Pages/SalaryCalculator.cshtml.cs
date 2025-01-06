using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace FinancialApplication.Pages
{
    public class SalaryCalculatorModel : PageModel
    {
        //Model binding to send data to view
        [BindProperty]
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Must be a positive number")]
        public double hourly_pay { get; set; }

        [BindProperty]
        [Required]
        [Range(1, 100, ErrorMessage = "Must be a number from 1 - 100")]
        public double fed_tax { get; set; }

        [BindProperty]
        [Required]
        [Range(1, 100, ErrorMessage = "Must be a number from 1 - 100")]
        public double state_tax { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please select a retirement plan")]
        public int retirement_plan { get; set; }

        [BindProperty]
        [Required]
        [Range(0, 100, ErrorMessage = "Must be from 0 - 100")]
        public double retirement_withholding { get; set; }

        // Properties to store calculated values
        public double yearly_gross_pay { get; set; }
        public double biweekly_gross_pay { get; set; }
        public double weekly_gross_pay { get; set; }

        public double yearly_fedtax_total { get; set; }
        public double yearly_statetax_total { get; set; }
        public double yearly_social_security { get; set; }
        public double yearly_medicare_tax { get; set; }
        public double yearly_medicare_surtax { get; set; }
        public double yearly_retirement { get; set; }
        public double yearly_total_deductions { get; set; }
        public double yearly_net_pay { get; set; }

        public double biweekly_fedtax_total { get; set; }
        public double biweekly_statetax_total { get; set; }
        public double biweekly_social_security { get; set; }
        public double biweekly_medicare_tax { get; set; }
        public double biweekly_retirement { get; set; }
        public double biweekly_total_deductions { get; set; }
        public double biweekly_net_pay { get; set; }

        public double weekly_fedtax_total { get; set; }
        public double weekly_statetax_total { get; set; }
        public double weekly_social_security { get; set; }
        public double weekly_medicare_tax { get; set; }
        public double weekly_retirement { get; set; }
        public double weekly_total_deductions { get; set; }
        public double weekly_net_pay { get; set; }

        public double display_fedtax {  get; set; }
        public double display_statetax { get; set; }
        public double display_retirement { get; set; }
        public string display_retirement_type { get; set; }


        public void OnPost()
        {
            // Adjust percentages
            retirement_withholding /= 100;
            fed_tax /= 100;
            state_tax /= 100;
            double social_security_rate = 0.062;
            double medicare_tax_rate = 0.0145;
            double medicare_surtax_rate = 0.009;
            display_fedtax = fed_tax * 100;
            display_statetax = state_tax * 100;
            display_retirement = retirement_withholding * 100;

            // Yearly calculations
            int yearly_hours_worked = 2080;
            yearly_gross_pay = hourly_pay * yearly_hours_worked;
            yearly_social_security = social_security_rate * yearly_gross_pay;
            yearly_medicare_tax = medicare_tax_rate * yearly_gross_pay;
            yearly_medicare_surtax = yearly_gross_pay >= 200000 ? medicare_surtax_rate * yearly_gross_pay : 0;
            yearly_fedtax_total = fed_tax * yearly_gross_pay;
            yearly_statetax_total = state_tax * yearly_gross_pay;
            yearly_retirement = yearly_gross_pay * retirement_withholding;
            yearly_total_deductions = yearly_fedtax_total + yearly_statetax_total + yearly_social_security + yearly_medicare_tax + yearly_medicare_surtax + yearly_retirement;
            yearly_net_pay = yearly_gross_pay - yearly_total_deductions;

            // Bi-weekly calculations
            int biweekly_hours_worked = 80;
            biweekly_gross_pay = hourly_pay * biweekly_hours_worked;
            biweekly_social_security = social_security_rate * biweekly_gross_pay;
            biweekly_medicare_tax = medicare_tax_rate * biweekly_gross_pay;
            biweekly_fedtax_total = fed_tax * biweekly_gross_pay;
            biweekly_statetax_total = state_tax * biweekly_gross_pay;
            biweekly_retirement = biweekly_gross_pay * retirement_withholding;
            biweekly_total_deductions = biweekly_fedtax_total + biweekly_statetax_total + biweekly_social_security + biweekly_medicare_tax + biweekly_retirement;
            biweekly_net_pay = biweekly_gross_pay - biweekly_total_deductions;

            // Weekly calculations
            int weekly_hours_worked = 40;
            weekly_gross_pay = hourly_pay * weekly_hours_worked;
            weekly_social_security = social_security_rate * weekly_gross_pay;
            weekly_medicare_tax = medicare_tax_rate * weekly_gross_pay;
            weekly_fedtax_total = fed_tax * weekly_gross_pay;
            weekly_statetax_total = state_tax * weekly_gross_pay;
            weekly_retirement = weekly_gross_pay * retirement_withholding;
            weekly_total_deductions = weekly_fedtax_total + weekly_statetax_total + weekly_social_security + weekly_medicare_tax + weekly_retirement;
            weekly_net_pay = weekly_gross_pay - weekly_total_deductions;

            //Calculations for traditional retirement type
            if (retirement_plan == 2)
            {
                display_retirement_type = "Traditional";
                yearly_retirement = yearly_gross_pay * retirement_withholding;
                biweekly_retirement = biweekly_gross_pay * retirement_withholding;
                weekly_retirement = weekly_gross_pay * retirement_withholding;
                yearly_total_deductions = yearly_fedtax_total + yearly_statetax_total + yearly_social_security + yearly_medicare_tax + yearly_medicare_surtax + yearly_retirement;
                biweekly_total_deductions = biweekly_fedtax_total + biweekly_statetax_total + biweekly_social_security + biweekly_medicare_tax + biweekly_retirement;
                weekly_total_deductions = weekly_fedtax_total + weekly_statetax_total + weekly_social_security + weekly_medicare_tax + weekly_retirement;
            }
            //Calculations for roth retirement plan i.e. taxes taken each paycheck
            else if (retirement_plan == 1)
            {
                display_retirement_type = "Roth";
                yearly_net_pay = yearly_gross_pay - (yearly_fedtax_total + yearly_statetax_total + yearly_social_security + yearly_medicare_tax + yearly_medicare_surtax);
                biweekly_net_pay = biweekly_gross_pay - (biweekly_fedtax_total + biweekly_statetax_total + biweekly_social_security + biweekly_medicare_tax);
                weekly_net_pay = weekly_gross_pay - (weekly_fedtax_total + weekly_statetax_total + weekly_social_security + weekly_medicare_tax);
                yearly_retirement = yearly_net_pay * retirement_withholding;
                biweekly_retirement = biweekly_net_pay * retirement_withholding;
                weekly_retirement = weekly_net_pay * retirement_withholding;
                yearly_total_deductions = yearly_fedtax_total + yearly_statetax_total + yearly_social_security + yearly_medicare_tax + yearly_medicare_surtax + yearly_retirement;
                biweekly_total_deductions = biweekly_fedtax_total + biweekly_statetax_total + biweekly_social_security + biweekly_medicare_tax + biweekly_retirement;
                weekly_total_deductions = weekly_fedtax_total + weekly_statetax_total + weekly_social_security + weekly_medicare_tax + weekly_retirement;
            }
         
        }

    }
}
