namespace FinancialApplication.Pages.Data_Classes
{
    public class Suggestions
    {
        public int SuggestionID { get; set; }
        public string SugContent { get; set; }
        public DateTime SubmittedDate { get; set; } = DateTime.Now;
    }
}
