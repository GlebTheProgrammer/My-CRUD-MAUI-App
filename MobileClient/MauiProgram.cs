using Microsoft.Extensions.Logging;
using MobileClient.Services;
using MobileClient.ViewModels;
using MobileClient.Views;

namespace MobileClient
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            // Services
            builder.Services.AddSingleton<IStudentService, StudentService>();

            // Views
            builder.Services.AddSingleton<StudentsListPage>();
            builder.Services.AddTransient<AddUpdateStudentDetail>();

            // View Models
            builder.Services.AddSingleton<StudentListPageViewModel>();
            builder.Services.AddTransient<AddUpdateStudentDetailViewModel>();

            return builder.Build();
        }
    }
}