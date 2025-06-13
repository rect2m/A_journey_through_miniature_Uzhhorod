using A_journey_through_miniature_Uzhhorod.Database;
using A_journey_through_miniature_Uzhhorod.MVVM.Model;
using A_journey_through_miniature_Uzhhorod.MVVM.Model.Notification;
using A_journey_through_miniature_Uzhhorod.MVVM.Model.Service;
using A_journey_through_miniature_Uzhhorod.MVVM.View;
using A_journey_through_miniature_Uzhhorod.MVVM.ViewModel;
using A_journey_through_miniature_Uzhhorod.MVVM.ViewModel.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Windows;

namespace A_journey_through_miniature_Uzhhorod
{
    public partial class App : Application
    {
        public static IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    // Add configuration for AzureBlobStorage section
                    services.Configure<AzureBlobStorageOptions>(
                        context.Configuration.GetSection("AzureBlobStorage"));

                    // Add EF Core DB context factory
                    services.AddDbContextFactory<AppDbContext>(options =>
                        options.UseNpgsql(context.Configuration.GetConnectionString("DefaultConnection")));

                    // Application services
                    services.AddScoped<IAppDbContextFactory, AppDbContextFactory>();
                    services.AddScoped<AchievementService>();
                    services.AddScoped<QuestService>();
                    services.AddScoped<BlobStorageService>(); // NEW: Blob service registration

                    // ViewModels
                    services.AddTransient<MainViewModel>();
                    services.AddScoped<EventsViewModel>();
                    services.AddScoped<HomeViewModel>();
                    services.AddScoped<MapeViewModel>();
                    services.AddScoped<MiniaturesViewModel>();
                    services.AddScoped<MiniatureDetailsViewModel>();
                    services.AddScoped<PersonalOfficeViewModel>();
                    services.AddScoped<FeedbackViewModel>();
                    services.AddScoped<QuestViewModel>();
                    services.AddScoped<AchievementViewModel>();
                    services.AddScoped<HelpViewModel>();

                    // Admin ViewModels
                    services.AddScoped<AdminHomeViewModel>();
                    services.AddScoped<EditEventsViewModel>();
                    services.AddScoped<EditFeedbackViewModel>();
                    services.AddScoped<EditSculptureViewModel>();
                    services.AddScoped<MiniatureEditDetailsViewModel>();
                    services.AddScoped<EditUsersViewModel>();
                    services.AddScoped<EditHelpViewModel>();

                    // UI
                    services.AddSingleton<ToastManager>();
                    services.AddScoped<AuthViewModel>();
                    services.AddTransient<AuthWindowView>();
                    services.AddTransient<MainWindowView>(provider =>
                        new MainWindowView(
                            provider.GetRequiredService<MainViewModel>(),
                            provider.GetRequiredService<IAppDbContextFactory>().CreateContext()));
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            string tempPath = Path.GetTempPath();
            foreach (var dir in Directory.GetDirectories(tempPath, "Model_*"))
            {
                if (File.Exists(Path.Combine(dir, "delete_me.txt")))
                {
                    try { Directory.Delete(dir, true); } catch { }
                }
            }

            using var scope = _host.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<IAppDbContextFactory>().CreateContext();
            await context.Database.MigrateAsync();
            DbInitializer.Seed(context);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using var scope = _host.Services.CreateScope();
            await _host.StopAsync();
            _host.Dispose();
            base.OnExit(e);
        }
    }
}
