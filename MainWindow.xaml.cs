using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.Web.WebView2.Core;
using System.Threading.Tasks;
using Windows.Web.Http;
using HtmlAgilityPack;
using Windows.System;
using Windows.UI.Core;
using WindowActivatedEventArgs = Microsoft.UI.Xaml.WindowActivatedEventArgs;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Arcademics
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            ExtendsContentIntoTitleBar = true;
            MyWebView2.Visibility = Visibility.Collapsed;

            MyWebView2.NavigationCompleted += myWebView_NavigationCompleted;
            this.Content.KeyDown += Grid_KeyDown;
        }
        private async void myWebView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                string script = "document.querySelector('button.fullscreen').click();";
                await MyWebView2.CoreWebView2.ExecuteScriptAsync(script);
                MyWebView2.Visibility = Visibility.Visible;

               

            }
        }
        private void Grid_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            // Check if the Escape key is pressed
            if (e.Key == VirtualKey.Escape)
            {
                // Mark the event as handled to block the Escape key
                e.Handled = true;
            }
        }



    }


}
