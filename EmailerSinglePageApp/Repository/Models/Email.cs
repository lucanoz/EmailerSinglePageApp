namespace EmailerSinglePageApp.Repository.Models
{
    public enum Importance
    {
        Low,
        Normal,
        High
    }

    public class Email
    {
        public int Id { get; set; }
        public required string FromAddress { get; set; }
        public required string ToAddress { get; set; }
        public string? CcAddresses { get; set; }
        public required string Subject { get; set; }
        public Importance Importance { get; set; }
        public required string Body { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
