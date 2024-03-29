﻿using CommunityToolkit.Maui;
using Manigdha.View;
using Manigdha.ViewModel;
using SharedModal.ClientServerConnection;
using SharedModal.ClientServerConnection.City_Server_Connection;

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
        builder.Services.AddScoped<IUserServerConnection, UserServerConnection>();
        builder.Services.AddScoped<ICityServerConnectio, CityServerConnection>();
        builder.Services.AddSingleton<BuyPostViewModal>();
        return builder.Build();
	}
}
