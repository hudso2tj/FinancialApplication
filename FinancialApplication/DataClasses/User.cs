using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace FinancialApplication.DataClasses

{
    public class User
    {
        [BindProperty]
        [Required(ErrorMessage = "Must enter a username")]
        public string username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Must enter a password")]
        public string password { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Must enter a first name")]
        public string fname { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Must enter a last name")]
        public string lname { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Must enter an email")]
        public string email { get; set; }

        [BindProperty] 
        public string phone { get; set; }

        [BindProperty]
        public string address { get; set; }

    }
}
