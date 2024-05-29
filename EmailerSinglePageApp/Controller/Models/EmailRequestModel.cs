using System.ComponentModel.DataAnnotations;

namespace EmailerSinglePageApp.Controller.Models
{
    public enum Importance
    {
        Low,
        Normal,
        High
    }

    public class EmailRequestModel
    {
        [Required]
        [EmailAddress]
        public string FromAddress { get; set; }

        [Required]
        [EmailAddress]
        public string ToAddress { get; set; }

        public string? CcAddresses { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public Importance Importance { get; set; }

        [Required]
        public string Body { get; set; }
    }
}
