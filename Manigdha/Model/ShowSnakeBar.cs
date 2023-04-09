using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using SharedModal.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manigdha.Model
{
    public class ShowSnakeBar
    {
        public async Task Show(string msg, SnakeBarType.Type snakeBarType, SnakeBarType.Time time)
        {
            SnakeBarType snakebarToColor = new SnakeBarType();
     
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            var snackbarOptions = new SnackbarOptions
            {
                BackgroundColor = Color.FromRgba(snakebarToColor.TypeToColor(snakeBarType)),
                TextColor = Colors.White,
                ActionButtonTextColor = Colors.White,
                CornerRadius = new CornerRadius(10),
                Font = Microsoft.Maui.Font.SystemFontOfSize(12),
                ActionButtonFont = Microsoft.Maui.Font.SystemFontOfSize(12),
                CharacterSpacing = 0.1
            };

            string text = msg;
            string actionButtonText = "Exit";
           
            TimeSpan duration = TimeSpan.FromSeconds(((int)time));

            var snackbar = Snackbar.Make(text, null, actionButtonText, duration, snackbarOptions);

            await snackbar.Show(cancellationTokenSource.Token);
        }
    }
}
