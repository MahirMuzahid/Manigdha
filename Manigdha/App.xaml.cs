﻿using Manigdha.Model;

namespace Manigdha;

public partial class App : Application
{
	public App()
	{
        InitializeComponent();
        Current.UserAppTheme = AppTheme.Dark;
        MainPage = new AppShell();
	}
}
