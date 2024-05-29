using EmailerSinglePageApp.Controller.Models;
using EmailerSinglePageApp.Repository;
using EmailerSinglePageApp.Repository.Models;

namespace EmailerSinglePageApp.Service
{
	public class EmailService : IEmailService
    {
		private IEmailRepository EmailRepository { get; }

		public EmailService(IEmailRepository emailRepository)
		{
			EmailRepository = emailRepository;
		}

		public async Task SendEmail(EmailRequestModel emailRequest)
        {
            var email = new Email()
            {
                FromAddress = emailRequest.FromAddress,
                ToAddress = emailRequest.ToAddress,
                CcAddresses = emailRequest.CcAddresses,
                Importance = (Repository.Models.Importance)emailRequest.Importance,
                Subject = emailRequest.Subject,
                Body = emailRequest.Body,
				CreatedOn = DateTime.UtcNow
			};

            await EmailRepository.InsertEmail(email);
		}

		public async Task<List<EmailResponseModel>> GetAllEmails()
		{
			var result = await EmailRepository.GetAllEmails();

			return result.ConvertAll(x => new EmailResponseModel()
			{
				FromAddress = x.FromAddress,
				ToAddress = x.ToAddress,
				CcAddresses = x.CcAddresses,
				Importance = (Controller.Models.Importance)x.Importance,
				Subject = x.Subject,
				Body = x.Body,
				CreatedOn = x.CreatedOn
			});
		}
	}
}
