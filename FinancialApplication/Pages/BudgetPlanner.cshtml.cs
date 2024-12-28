using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinancialApplication.Pages
{
    public class BudgetPlannerModel : PageModel
    {
        [BindProperty]
        public int monthly_income { get; set; }

        [BindProperty]
        public int other_income { get; set; }

        [BindProperty]
        public int mortgage { get; set; }

        [BindProperty]
        public int property_tax { get; set; }

        [BindProperty]
        public int groceries { get; set; }

        [BindProperty]
        public int homeowners_insurance { get; set; }

        [BindProperty]
        public int utilities { get; set; }

        [BindProperty]
        public int child_care { get; set; }

        [BindProperty]
        public int other_housing_expenses { get; set; }

        [BindProperty]
        public int car_loans { get; set; }

        [BindProperty]
        public int auto_insurance { get; set; }

        [BindProperty]
        public int public_transportation { get; set; }

        [BindProperty]
        public int fuel { get; set; }

        [BindProperty]
        public int other_auto_expenses { get; set; }

        [BindProperty]
        public int health_insurance { get; set; }

        [BindProperty]
        public int medical_dental_expenses { get; set; }

        [BindProperty]
        public int other_medical_expenses { get; set; }

        [BindProperty]
        public int tuition { get; set; }

        [BindProperty]
        public int textbooks { get; set; }

        [BindProperty]
        public int supplies { get; set; }

        [BindProperty]
        public int other_education_expenses { get; set; }

        [BindProperty]
        public int student_loans { get; set; }

        [BindProperty]
        public int credit_cards { get; set; }

        [BindProperty]
        public int other_loan_expenses { get; set; }

        [BindProperty]
        public int college_savings { get; set; }

        [BindProperty]
        public int investments { get; set; }

        [BindProperty]
        public int other_savings_expenses { get; set; }

        [BindProperty]
        public int gifts { get; set; }

        [BindProperty]
        public int donations { get; set; }

        [BindProperty]
        public int entertainment { get; set; }

        [BindProperty]
        public int travel { get; set; }

        [BindProperty]
        public int clothing { get; set; }

        [BindProperty]
        public int personal_care { get; set; }

        [BindProperty]
        public int general_purchases { get; set; }

        [BindProperty]
        public int other_misc_expenses { get; set; }

        public int income { get; set; }
        public int housing_expenses { get; set; }
        public int transportation_expenses { get; set; }
        public int medical_expenses { get; set; }
        public int education_expenses { get; set; }
        public int loans_cc_expenses { get; set; }
        public int investing_expenses { get; set; }
        public int giving_expenses { get; set; }
        public int miscellaneous_expenses { get; set; }
        public int monthly_net_income { get; set; }
        public int monthly_expenses { get; set; }
        public void OnPost()
        {
            income = monthly_income + other_income;
            housing_expenses = mortgage + property_tax + groceries + homeowners_insurance + utilities + child_care + other_housing_expenses;
            transportation_expenses = car_loans + auto_insurance + public_transportation + fuel + other_auto_expenses;
            medical_expenses = health_insurance + medical_dental_expenses + other_medical_expenses;
            education_expenses = tuition + textbooks + supplies + other_education_expenses;
            loans_cc_expenses = student_loans + credit_cards + other_loan_expenses;
            investing_expenses = college_savings + investments + other_savings_expenses;
            giving_expenses = gifts + donations;
            miscellaneous_expenses = entertainment + travel + clothing + personal_care + general_purchases + other_misc_expenses;

            monthly_expenses = housing_expenses + transportation_expenses + medical_expenses +
                education_expenses + loans_cc_expenses + investing_expenses + giving_expenses + miscellaneous_expenses;
            monthly_net_income = income - monthly_expenses;
        }
    }
}
