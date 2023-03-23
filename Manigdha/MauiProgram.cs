using CommunityToolkit.Maui;
using Manigdha.View;
using Manigdha.ViewModel;

namespace Manigdha;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().UseMauiCommunityToolkit();
        builder
			.UseMauiApp<App>().UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Montserrat-Bold.ttf", "MontserratBold");
            });
		builder.Services.AddSingleton<BuyPost>();
        builder.Services.AddSingleton<BuyPostViewModal>();
        return builder.Build();
	}
}
