using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Threading.Tasks;

namespace Arcademics
{
    public sealed partial class GamePage : Page
    {
        public GamePage()
        {
            this.InitializeComponent();
            GameWebView.NavigationCompleted += GameWebView_NavigationCompleted;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Retrieve the URL passed as a parameter and set it to the WebView
            if (e.Parameter is string url)
            {
                GameWebView.Source = new Uri(url);
            }
        }

        private async void GameWebView_NavigationCompleted(WebView2 sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs args)
        {
            if (args.IsSuccess)
            {
                // JavaScript to click the fullscreen button
                string script = "document.querySelector('.fullscreen').click();";
                await sender.ExecuteScriptAsync(script);

                // Now that the fullscreen action is done, make the grid visible
                GameGrid.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
            }
        }
    }
}
