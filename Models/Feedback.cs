namespace MvcStartApp.Models
{
    public class Feedback
    {
        public string From { get; set; }
        public string Text { get; set; }
        public Feedback()
        {
            From = string.Empty;
            Text = string.Empty;
        }
    }
}
