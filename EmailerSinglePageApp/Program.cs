using EmailerSinglePageApp.Components;
using EmailerSinglePageApp.Repository;
using EmailerSinglePageApp.Service;
using Microsoft.EntityFrameworkCore;

namespace EmailerSinglePageApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents().AddInteractiveServerComponents();
            builder.Services.AddTransient<IEmailService, EmailService>();
            builder.Services.AddTransient<IEmailRepository, EmailRepository>();
			RegisterDatabaseServices(builder);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

            app.Run();
        }

		private static void RegisterDatabaseServices(WebApplicationBuilder builder)
		{
            var connectionString = builder.Configuration.GetConnectionString("EmailConnectionString");
			builder.Services.AddDbContext<EmailDbContext>(options => options.UseSqlServer(connectionString));

		}
	}
}
