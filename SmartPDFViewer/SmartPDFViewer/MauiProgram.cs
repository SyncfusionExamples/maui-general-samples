using ChatGptNet;
using ChatGptNet.Models;
using ChatGptNet.ServiceConfigurations;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;


namespace SmartPDFViewer;

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

		builder.ConfigureSyncfusionCore();

        builder.Services.AddChatGpt(options =>
        {

			options.UseOpenAI("", null);
            options.DefaultModel = OpenAIChatGptModels.Gpt35Turbo; // Default: ChatGptModels.Gpt35Turbo
            options.MessageLimit = 10; // Default: 10
            options.MessageExpiration = TimeSpan.FromMinutes(5); // Default: 1 hour
        });

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
