using EmailerSinglePageApp.Repository.Models;

namespace EmailerSinglePageApp.Repository
{
	public interface IEmailRepository
	{
		public Task InsertEmail(Email email);
		public Task<List<Email>> GetAllEmails();
	}
}
