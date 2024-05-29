using EmailerSinglePageApp.Controller.Models;

namespace EmailerSinglePageApp.Service
{
    public interface IEmailService
    {
        public Task SendEmail(EmailRequestModel email);
        public Task<List<EmailResponseModel>> GetAllEmails();
    }
}
