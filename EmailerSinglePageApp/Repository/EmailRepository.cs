using EmailerSinglePageApp.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailerSinglePageApp.Repository
{
	public class EmailRepository : IEmailRepository
	{
		private EmailDbContext EmailContext { get; }

		public EmailRepository(EmailDbContext emailContext)
		{
			EmailContext = emailContext;
		}

		public async Task InsertEmail(Email email)
		{
			EmailContext.Emails.Add(email);

			await EmailContext.SaveChangesAsync();
		}

		public Task<List<Email>> GetAllEmails()
		{
			return EmailContext.Emails.ToListAsync();
		}
	}
}
